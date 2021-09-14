from collections import namedtuple
from typing import List
import numpy as np


class Cell:
    def __init__(self, low, high, id):
        self._low = low
        self._high = high
        self._id = id

    def __eq__(self, other):
        return self._low == other._low and self._high == other._high

    def __hash__(self):
        # return (self._low, self._high).__hash__()
        return hash(self._id)

    @property
    def id(self):
        return self._id

    def sample_points(self, points_count) -> np.ndarray:
        x_splitting = np.linspace(self._low[0], self._high[0], num=points_count + 2, endpoint=True)
        y_splitting = np.linspace(self._low[1], self._high[1], num=points_count + 2, endpoint=True)

        points = np.zeros((points_count, 2))
        points[:, 0] = x_splitting[1:-1]
        points[:, 1] = y_splitting[1:-1]

        return points


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
                id = column + column_count * row

                self._grid[index] = Cell(low_point, high_point, id=id)
    
    @property
    def cell_size(self):
        return ...

    def get_cells_from_points(self, X: np.ndarray) -> List[Cell]:
        indices = self._get_indices(X)

        return [self._grid[index] for index in indices]

    def _get_indices(self, X: np.ndarray) -> np.ndarray:
        X -= np.array([self._low_point])
        X /= np.array([self._column_count, self._row_count], dtype=float)

        return X.astype(int)


class Homeomorphism:
    def apply(self, x):
        raise NotImplementedError()


class QuadraticMapping(Homeomorphism):
    def __init__(self, a: float, b: float):
        self._a = a
        self._b = b

    def _apply(self, x: np.ndarray):
        x_ = x[0]
        y_ = x[1]

        x[0] = x_**2 - y_**2 + self._a
        x[1] = 2 * x_ * y_ + self._b

        return x

    def apply(self, X: np.ndarray) -> np.ndarray:
        x_ = X[0]
        y_ = X[1]

        X[0] = x_ ** 2 - y_ ** 2 + self._a
        X[1] = 2 * x_ * y_ + self._b

        return X
