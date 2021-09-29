function [min, max] = MinMax(f, lowerbound, upperbound)
    min = fminbnd(f, lowerbound, upperbound);
    max = fminbnd(@(x) -f(x), lowerbound, upperbound);
end