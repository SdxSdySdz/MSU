from collections import namedtuple
from typing import List, ValuesView
import numpy as np


class Cell:
    def __init__(self, low: np.ndarray, high: np.ndarray, id: int):
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

    @property
    def low(self):
        return self._low

    @property
    def high(self):
        return self._high

    def sample_points(self, points_count) -> np.ndarray:
        x_splitting = np.linspace(self._low[0], self._high[0], num=points_count + 2, endpoint=True)
        y_splitting = np.linspace(self._low[1], self._high[1], num=points_count + 2, endpoint=True)

        points = np.zeros((points_count, 2))
        points[:, 0] = x_splitting[1:-1]
        points[:, 1] = y_splitting[1:-1]

        return points


class Domain:
    def __init__(self, low_point: np.ndarray, high_point: np.ndarray, row_count: int, column_count: int, fill_grid=True):
        self._low_point = low_point
        self._high_point = high_point

        self._row_count = row_count
        self._column_count = column_count

        self._row_splitting = (high_point[1] - low_point[1]) / float(row_count)
        self._column_splitting = (high_point[0] - low_point[0]) / float(column_count)

        self._grid = dict()

        if fill_grid:
            id = 0

            for row in range(row_count):
                for column in range(column_count):
                    low_point = np.array(
                        (column * self._column_splitting, row * self._row_splitting)
                    )
                    high_point = np.array(
                        ((column + 1) * self._column_splitting, (row + 1) * self._row_splitting)
                    )

                    index = np.array([row, column], dtype=int)

                    # id = column + column_count * row

                    self._grid[index] = Cell(low_point, high_point, id=id)
                    id += 1
    
    @property
    def cell_size(self):
        return ...

    def get_cells(self) -> ValuesView[Cell]:
        return self._grid.values()

    def get_cells_from_points(self, X: np.ndarray) -> List[Cell]:
        indices = self._get_indices(X)
        candidates = [self._grid.get(index, None) for index in indices]

        return [candidate for candidate in candidates if candidate is not None]

    def split(self):
        new_domain = Domain(fill_grid=False)

        id = 0
        for (cell_index, cell) in self._grid.items():
            low = cell.low
            high = cell.high
            center = (high + low) / 2.0
            half_diff = (high - low) / 2.0

            top_left_low = np.array([low[0], center[1]])
            top_right_low = np.array([center[0], center[1]])
            bottom_left_low = low[:]
            bottom_right_low = np.array([center[0], low[1]])

            # top_left_id = id
            # top_right_id = id + 1
            # bottom_left_id = id + 2
            # bottom_right_id = id + 3

            # id += 4

            # top_left = Cell(low=top_left_low, high=top_left_low + half_diff, id=top_left_id)
            # top_right = Cell(low=top_right_low, high=top_right_low + half_diff, id=top_right_id)
            # bottom_left = Cell(low=bottom_left_low, high=bottom_left_low + half_diff, id=bottom_left_id)
            # bottom_right = Cell(low=bottom_right_low, high=bottom_right_low + half_diff, id=bottom_right_id)

            childs = []
            for child_low in [top_left_low, top_right_low, bottom_left_low, bottom_right_low]:
                childs.append(Cell(low=child_low, high=child_low + half_diff, id=id))
                id += 1

            row = cell_index[0]
            column = cell_index[1]

            top_left_index = 2 * cell_index
            top_right_index = np.array([2 * row, 2 * column + 1])
            bottom_left_index = np.array([2 * row + 1, 2 * column])
            bottom_right_index = 2 * cell + 1

            top_left, top_right, bottom_left, bottom_right = childs

            new_domain._grid[top_left_index] = top_left
            new_domain._grid[top_right_index] = top_right
            new_domain._grid[bottom_left_index] = bottom_left
            new_domain._grid[bottom_right_index] = bottom_right


    def _get_indices(self, X: np.ndarray) -> np.ndarray:
        X -= np.array(self._low_point)
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
