from typing import List
import numpy as np


class Segment:
    def __init__(self, low, high):
        for value in [low, high]:
            if not (isinstance(value, float) or isinstance(value, int)):
                raise Exception("low and high should be real number")

        if low >= high:
            raise Exception("low should be less than high")

        self._low = low
        self._high = high
        self._length = float(high - low)

    @property
    def low(self):
        return self._low

    @property
    def high(self):
        return self._high

    @property
    def length(self):
        return self._length


class Cell:
    def __init__(self, segments: List[Segment]):
        self._dim = len(segments)
        self._low_point = np.zeros(self._dim, dtype=float)
        self._high_point = np.zeros(self._dim, dtype=float)
        # self._center = np.zeros(self._dim, dtype=float)

        self._segments = []

        for i in range(self._dim):
            segment = segments[i]

            if not isinstance(segment, Segment):
                raise Exception("Parameter segments should consist only elements of type Segment")

            self._low_point[i] = segment.low
            self._high_point[i] = segment.high
            # self._center[i] = (segment.low + segment.high) / 2.0
            self._segments.append(segment)

    def __eq__(self, other):
        # return np.array_equal(self._center, other._center)
        return np.array_equal(self._low_point, other._low_point) and np.array_equal(self._high_point, other._high_point)

    def __hash__(self):
        # return self._center.__hash__()
        return (self._low_point, self._high_point).__hash__()

    @property
    def dim(self):
        return self._dim

    def get_segment(self, index) -> Segment:
        return self._segments[index]


class Domain:
    def __init__(self):
        ...









class Compact:
    def __init__(self, segments: List[Segment], split_counts: List[int]):
        self._dim = len(segments)
        self._low_point = np.zeros(self._dim, dtype=float)
        self._split_counts = np.zeros(self._dim, dtype=int)
        self._split_parameters = np.zeros(self._dim, dtype=float)
        self._index_to_number_multiplier = np.ones(self._dim, dtype=int)
        self._segments = []

        for i in range(self._dim):
            segment = segments[i]
            split_count = split_counts[i]

            if not isinstance(segment, Segment):
                raise Exception("Parameter segments should consist only elements of type Segment")

            if not isinstance(split_count, int):
                raise Exception("Parameter split_counts should consist only elements of type int")

            self._low_point[i] = segment.low
            self._split_counts[i] = split_count

            self._split_parameters[i] = segment.length / split_count

            if i > 0:
                self._index_to_number_multiplier[i] = self._index_to_number_multiplier[i - 1] * self._split_counts[i - 1]

            self._segments.append(segment)

    @property
    def dim(self):
        return self._dim

    def get_segment(self, index) -> Segment:
        return self._segments[index]

    def get_cell_number(self, x: np.ndarray) -> int:
        origin_x = x - self._low_point
        origin_x /= self._split_parameters
        cell_index = origin_x.astype(int)

        return self._cell_index_to_number(cell_index)

    def _cell_index_to_number(self, index: np.ndarray) -> int:
        return np.dot(index, self._index_to_number_multiplier) + 1


class Homeomorphism:
    def apply(self, x):
        raise NotImplementedError()


class QuadraticMapping(Homeomorphism):
    def __init__(self, C: complex):
        self._C = C

    def apply(self, x: complex):
        return x * x + self._C

