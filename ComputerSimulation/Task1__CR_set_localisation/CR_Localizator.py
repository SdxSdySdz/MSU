from collections import defaultdict
from typing import List
from geometry import Homeomorphism, Compact, Domain
from graph import SymbolicImageGraph


class CR_Localizator:
    def __init__(self, min_cell_size: float):
        self._min_cell_size = min_cell_size

    def solve(self, f: Homeomorphism, domain: Domain) -> ...:
        while domain.cell_size >= self._min_cell_size:
            # 1 constuct SymbolicImageGraph from f and domain
            graph = SymbolicImageGraph(f, domain)
            # 2 find return_vertexes
            return_vertexes = graph.get_return_vertexes()
            graph.delete(return_vertexes)
            # 3 split cells
            domain = domain.split(...)