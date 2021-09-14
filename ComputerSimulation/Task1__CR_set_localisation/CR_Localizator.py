from collections import defaultdict
from typing import List
from geometry import Homeomorphism, Domain
from graph import SymbolicImageGraph


class CR_Localizator:
    def __init__(self, min_cell_size: float):
        self._min_cell_size = min_cell_size

    def solve(self, f: Homeomorphism, domain: Domain) -> ...:
        while domain.cell_size >= self._min_cell_size:
            graph = SymbolicImageGraph(f, domain)

            graph.delete_nonreturnable_vertexes()

            domain = domain.split()
