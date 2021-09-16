from collections import defaultdict
from typing import List
from geometry import Homeomorphism, Domain
from graph import SymbolicImageGraph
import networkx as nx

from interface import Interface

from time import time


class CR_Localizator:
    def __init__(self, n_iterations: float):
        self._n_iterations = n_iterations

    def solve(self, f: Homeomorphism, domain: Domain) -> Domain:
        last_domain = None

        iteration = 0
        while iteration < self._n_iterations:
            print(f'===Iteration {iteration}===')
            i = Interface()

            start = time()
            graph = SymbolicImageGraph(f, domain)
            print(f'Construct Symbolic Image Graph {time() - start}')

            print('nodes', len(graph._graph.nodes))

            start = time()
            if not graph.nonreturnable_vertexes_successfully_deleted():
                print('There is no any CR set')
                return None
            print(f'Delete non-returnable vertexes {time() - start}')

            start = time()
            domain.delete_nonreturnable_cells(graph)
            print(f'Delete non-returnable cellls {time() - start}')



            print(len(graph._graph.nodes))
            print(len(domain._grid.keys()))

            last_domain = domain
            i.view(last_domain)
            start = time()
            domain = domain.split()
            print(f'Split domain {time() - start}')
            iteration += 1

        return last_domain
