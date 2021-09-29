%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 
%   Alp Sayin - alp_sayin[at]ieee[dot]org
%   Matlab Genetic Algorithm
%   Spring 2012
% 
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

function fitnessValue = EvaluateIndividual(x)

%fitnessValue = (exp(-x(1)^2 -x(2)^2) + sqrt(5)*(sin(x(2)*x(1)*x(1))^2)+ 2*(cos(2*x(1)+ 3*x(2))^2))/( 1+x(1)^2 +x(2)^2);%
x_ = x(1);
q = log(x_) * cos(3*x_ - 15);
% fitnessValue = log(x(1)) * cos(3 * x(1) - 15) + x(2);
fitnessValue = q;
