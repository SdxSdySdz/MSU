from collections import defaultdict
from typing import List
from geometry import Homeomorphism, Domain
from graph import SymbolicImageGraph


class CR_Localizator:
    def __init__(self, min_cell_size: float):
        self._min_cell_size = min_cell_size

    def solve(self, f: Homeomorphism, domain: Domain) -> Domain:
        last_domain = None
        while domain.cell_size >= self._min_cell_size:
            graph = SymbolicImageGraph(f, domain)

            if not graph.nonreturnable_vertexes_successfully_deleted():
                print('There is no any CR set')
                return None

            last_domain = domain
            domain = domain.split()

        return last_domain
