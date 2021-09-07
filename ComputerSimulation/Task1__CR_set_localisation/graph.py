from collections import defaultdict
from typing import List
from geometry import Homeomorphism, Compact


class Vertex:
    ...


class SymbolicImageGraph:
    def __init__(self, f: Homeomorphism, compact: Compact):
        self._vertexes = defaultdict(list)

        for cell in compact.get_cells():
            f_neighbours = self._find_f_neighbours()
            
            self._vertexes[vertex].append()

    def _consist(self, vertex: Vertex) -> bool:
        pass

    def _find_f_neighbours(self) -> List[Vertex]:
        ...