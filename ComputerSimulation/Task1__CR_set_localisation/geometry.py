from collections import namedtuple
from typing import List
import numpy as np


class Cell:
    def __init__(self, low, high):
        self._low = low
        self._high = high

    def __eq__(self, other):
        return self._low == other._low and self._high == other._high

    def __hash__(self):
        return (self._low, self._high).__hash__()


class Domain:
    def __init__(self, low_point, high_point, row_count: int, column_count: int):
        self._low_point = low_point
        self._high_point = high_point

        self._row_count = row_count
        self._column_count = column_count

        self._row_splitting = (high_point[1] - low_point[1]) / float(row_count)
        self._column_splitting = (high_point[0] - low_point[0]) / float(column_count)

        self._grid = dict()

        for row in range(row_count):
            for column in range(column_count):
                low_point = (column * self._column_splitting, row * self._row_splitting)
                high_point = ((column + 1) * self._column_splitting, (row + 1) * self._row_splitting)

                index = np.array([row, column], dtype=int)

                self._grid[index] = Cell(low_point, high_point)
    
    @property
    def cell_size(self):
        return ...

    def get_cells_from_points(self, X: np.ndarray) -> list:
        indices = self._get_indices(X)

        return [self._grid[index] for index in indices]

    def _get_indices(self, X: np.ndarray):
        X -= np.array([self._low_point])
        X /= np.array([self._column_count, self._row_count], dtype=float)

        return X.astype(int)



class Homeomorphism:
    def apply(self, x):
        raise NotImplementedError()


class QuadraticMapping(Homeomorphism):
    def __init__(self, C: complex):
        self._C = C

    def apply(self, x: complex):
        return x * x + self._C

