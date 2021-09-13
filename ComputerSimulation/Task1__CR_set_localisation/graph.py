from collections import defaultdict
from typing import List, Set
from geometry import Homeomorphism, Compact, Domain, Cell


class SymbolicImageGraph:
    def __init__(self, f: Homeomorphism, domain: Domain):
        self._vertexes = defaultdict(set)

        for cell in domain.get_cells():
            X = f.apply_to_cell(cell)

            cells = domain.get_cells(X)

            self._vertexes[cell] = {cell for cell in cells}
