from collections import namedtuple
from typing import List, ValuesView, Tuple
import numpy as np





class Cell:
    def __init__(self, low: np.ndarray, high: np.ndarray, id: int):
        self._low = low
        self._high = high
        self._id = id
        self._center = (low + high) / 2.0

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

    @property
    def center(self):
        return self._center

    def sample_points(self, points_count) -> np.ndarray:
        return CellPointsSampler.uniform(self, n_points_in_row=int(points_count**0.5))


class CellPointsSampler:
    @classmethod
    def random(cls, cell: Cell, n_points: int):
        points = np.random.random_sample((n_points, 2))

        points[:, 0] *= cell.high[0] - cell.low[0]
        points[:, 0] += cell.low[0]

        points[:, 1] *= cell.high[1] - cell.low[1]
        points[:, 1] += cell.low[1]

        return points

    @classmethod
    def uniform(cls, cell: Cell, n_points_in_row: int):
        step = 1.0 / (n_points_in_row - 1)
        x = np.arange(0.0, 1.0 + step / 2.0, step=step)
        y = np.arange(0.0, 1.0 + step / 2.0, step=step)

        X, Y = np.meshgrid(x, y)

        grid = np.zeros((n_points_in_row, n_points_in_row, 2))
        grid[:, :, 0] = X
        grid[:, :, 1] = Y

        points = grid.reshape((n_points_in_row * n_points_in_row, 2))
        points *= cell.high - cell.low
        points += cell.low

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

                    low_point += self._low_point
                    high_point += self._low_point

                    index = (row, column)

                    # id = column + column_count * row

                    self._grid[index] = Cell(low_point, high_point, id=column + self._column_count * row)
                    id += 1
    
    @property
    def cell_size(self):
        return self._column_splitting, self._row_splitting

    def get_cells(self) -> ValuesView[Cell]:
        return self._grid.values()

    def get_cells_from_points(self, points: np.ndarray) -> List[Cell]:
        indices = self._get_indices(points)
        filter()
        candidates = [self._grid.get((index[0], index[1]), None) for index in indices]
        # candidates = [self._grid[(index[0], index[1])] for index in indices]

        return [candidate for candidate in candidates if candidate is not None]

    def delete_nonreturnable_cells(self, strongly_connected_graph):
        ids = {cell.id for cell in self.get_cells()}
        returnable_ids = strongly_connected_graph._graph.nodes

        if not returnable_ids <= ids:
            raise ValueError

        nonreturnable_ids = ids - returnable_ids
        for id in nonreturnable_ids:
            self._delete_cell_by_id(id)



    def split(self):
        new_domain = Domain(
            self._low_point,
            self._high_point,
            2 * self._row_count,
            2 * self._column_count,
            fill_grid=False
        )

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

            row = cell_index[0]
            column = cell_index[1]
            cell_index = np.array(cell_index)

            top_left_index = tuple(2 * cell_index)
            top_right_index = (2 * row, 2 * column + 1)
            bottom_left_index = (2 * row + 1, 2 * column)
            bottom_right_index = tuple(2 * cell_index + 1)

            childs = []
            for (child_low, child_index) in [(top_left_low, top_left_index), (top_right_low, top_right_index), (bottom_left_low, bottom_left_index), (bottom_right_low, bottom_right_index)]:
                child_row = child_index[0]
                child_col = child_index[1]
                childs.append(Cell(low=child_low, high=child_low + half_diff, id=child_col + new_domain._column_count * child_row))

            top_left, top_right, bottom_left, bottom_right = childs

            new_domain._grid[top_left_index] = top_left
            new_domain._grid[top_right_index] = top_right
            new_domain._grid[bottom_left_index] = bottom_left
            new_domain._grid[bottom_right_index] = bottom_right

        return new_domain

    def _get_indices(self, X: np.ndarray) -> np.ndarray:
        X_ = np.zeros(X.shape)

        X_ += X
        X_ -= self._low_point
        X_ /= np.array([self._column_splitting, self._row_splitting], dtype=float)

        return X_.astype(int)[:, ::-1]

    def _id_to_index(self, id: int) -> Tuple[int, int]:
        row = id // self._column_count
        column = id - self._column_count * row

        return row, column

    def _index_to_id(self, index: Tuple[int, int]) -> int:
        row, column = index

        return column + self._column_count * row

    def _delete_cell(self, row, column):
        del self._grid[row, column]

    def _delete_cell_by_id(self, id):
        # self._delete_cell(*self._id_to_index(id))
        for index, cell in self._grid.items():
            if cell.id == id:
                del self._grid[index]
                return

    def _get_cell_by_id(self, id):
        row, column = self._id_to_index(id)

        return self._grid.get((row, column), None)


class Homeomorphism:
    def apply_to_cell(self, cell: Cell):
        points = cell.sample_points(100)

        return self.apply(points)

    def apply(self, X: np.ndarray) -> np.ndarray:
        raise NotImplementedError()


class QuadraticMapping(Homeomorphism):
    def __init__(self, a: float, b: float):
        self._a = a
        self._b = b

    def apply(self, X: np.ndarray) -> np.ndarray:
        X_ = np.zeros(X.shape)

        x_ = X[:, 0]
        y_ = X[:, 1]

        X_[:, 0] = x_ ** 2 - y_ ** 2 + self._a
        X_[:, 1] = 2 * x_ * y_ + self._b

        # for i in range(0, len(X)):
        #     X_[i, 0] = X[i, 0]**2 - X[i, 1]**2 + self._a
        #     X_[i, 1] = 2 * X[i, 0] * X[i, 1] + self._b
        #

        return X_


