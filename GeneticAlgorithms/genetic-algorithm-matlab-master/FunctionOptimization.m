%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 
%   Alp Sayin - alp_sayin[at]ieee[dot]org
%   Matlab Genetic Algorithm
%   Spring 2012
% 
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%% CLEAN-UP
clear;close all;clc;
tic

%% PARAMETERS
low = 1;
high = 10;
populationSize = 100;
numberOfGenes = 100;
crossoverProbability = 0.75 ;
mutationProbability = 0.1;
tournamentSelectionParameter = 0.5;
% variableRange = 5.0;
numberOfGenerations = 100;
numberOfVariables = 2;
tournamentSize = 10;
numberOfReplications = 2;
verbose = true;
draw_plots = true;
% UNLESS THE FITNESS FUNCTION IS REALLY DIFFICULT TO COMPUTE, IT'S FASTER
% NOT TO USE PARALLEL COMPUTATION
runparallel = false; 


%% VARIABLES
maxFitnessForAllGenerations = zeros(numberOfGenerations, 1);
timeForAllGenerations = zeros(numberOfGenerations, 1);
accuracyForAllGenerations = zeros(numberOfGenerations, 1) + 2.21828;

fitness = zeros(populationSize, 1);

%% PLOTTING SETUP
if draw_plots
    fitnessFigureHandle = figure;
    
    drawnow;
    hold on;
    set(fitnessFigureHandle,'Position',[50,50,500,200]);
    set(fitnessFigureHandle,'DoubleBuffer','on');
    axis([1 numberOfGenerations low high]);
    bestPlotHandle = plot(1:numberOfGenerations, zeros(1,numberOfGenerations));
    textHandle = text(30,2.6, sprintf('best: %4.3f', 0.0));
    hold off;
    drawnow;

    surfaceFigureHandle= figure;
    hold on;
    set(surfaceFigureHandle,'DoubleBuffer','on');
    delta=0.1;
    limit = fix((high - low)/delta)+1 ;
    [xValues, yValues] = meshgrid(low: delta:high,low: delta:high);
    zValues= zeros(limit,limit);
    for j = 1: limit
        for k = 1: limit
            zValues(j,k) = EvaluateIndividual([xValues(j,k)]);
        end
    end
    surfl(xValues, yValues, zValues)
    plot(xValues, zValues)
    colormap 'gray';
    shading interp;
    view ([0 -10 0.1]);
    decodedPopulation = zeros(populationSize,numberOfVariables);
    populationPlotHandle = plot3(decodedPopulation(:,1),decodedPopulation(:,2),fitness(:),'kp');
    hold off;
    drawnow;
end
%% INITIATE POPULATION
population = InitializePopulation(populationSize, numberOfGenes) ;

%% RUN GENERATIONS
startTime = cputime;
for iGeneration = 1: numberOfGenerations
    
    %% FIND MAXIMUM FITNESS OF POPULATION

    decodedPopulation = DecodePopulation(population, numberOfVariables, low, high);
    fitness = EvaluatePopulation(decodedPopulation, runparallel);
    [maximumFitness, bestIndividualIndex] = max(fitness);
    
    maxFitnessForAllGenerations(iGeneration)=maximumFitness;
    
    
    xBest = decodedPopulation(bestIndividualIndex,:);

%   % Deprecated - to be deleted in the next iteration
%     maximumFitness = 0.0;
%     for i = 1: populationSize
%         chromosome = population(i,:);
%         x = DecodeChromosome(chromosome, numberOfVariables, variableRange) ;
%         decodedPopulation(i,:)= x;
%         fitness(i) = EvaluateIndividual(x);
%         if ( fitness(i)> maximumFitness)
%             maximumFitness = fitness(i);
%             bestIndividualIndex = i;
%             xBest=x ;
%         end
%     end

    % Print out
    if verbose
        fprintf('Maximum Fitness: %d\n',maximumFitness);
        fprintf('Best Solution: %d\n',xBest); 
    end
    
    %% COPY POPULATION
    newPopulation = population;

    %% NEW GENERATION
    for i = 1:tournamentSize:populationSize
        %% TOURNAMENT SELECTION
        i1 = TournamentSelect(fitness,tournamentSelectionParameter,tournamentSize);
        i2 = TournamentSelect(fitness,tournamentSelectionParameter,tournamentSize);
        chromosome1 = population(i1,:);
        chromosome2 = population(i2,:);

        %% CROSS-OVER
        r = rand;
        if ( r < crossoverProbability)
            newChromosomePair = Cross(chromosome1, chromosome2);
            newPopulation(i,:) = newChromosomePair(1,:);
            newPopulation(i+1,:) = newChromosomePair(2,:);
        else
            newPopulation(i,:) = chromosome1;
            newPopulation(i+1,:) = chromosome2;
        end
    end

    %% MUTATE
    newPopulation = Mutate(newPopulation, mutationProbability);
    
    %% PRESERVATION OF PREVIOUS BEST SOLUTION
    bestChromosome = population(bestIndividualIndex,:);
    newPopulation = InsertBestIndividual(newPopulation, bestChromosome, numberOfReplications);
        
    %% COPY THE NEW POPULATION ONTO CURRENT POPULATION
    population = newPopulation;
    
    %% PLOT CURRENT SITUATION
    if draw_plots
        plotvector = get(bestPlotHandle,'YData');
        plotvector(iGeneration)= maximumFitness;
        set(bestPlotHandle,'YData',plotvector);
        set(textHandle,'String', sprintf('best: %4.3f',maximumFitness));
        set(populationPlotHandle,'XData', decodedPopulation(:,1),'YData',decodedPopulation(:,2),'ZData', fitness(:));
        drawnow;
    end
    timeForAllGenerations(iGeneration) = cputime - startTime;
end

figure()
hold on
title(sprintf('Max fitness (mutation probability = %f)', mutationProbability) );
xlabel('Generation');
plot(1:numberOfGenerations, maxFitnessForAllGenerations)
hold off

figure()
hold on
title(sprintf('Accuracy (mutation probability = %f)', mutationProbability) );
xlabel('Generation');
plot(1:numberOfGenerations, exp(-abs(accuracyForAllGenerations - maxFitnessForAllGenerations)))
hold off


figure()
hold on
title(sprintf('Time (mutation probability = %f)', mutationProbability) );
xlabel('Generation');
plot(1:numberOfGenerations, timeForAllGenerations)
hold off


% Print out
fprintf('Maximum Fitness: %d\n',maximumFitness);
fprintf('Best Solution: %d\n',xBest); 
toc

maximumFitness
