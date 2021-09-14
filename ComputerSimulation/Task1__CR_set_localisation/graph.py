from collections import defaultdict
from typing import List, Set
from geometry import Homeomorphism, Compact, Domain, Cell
import networkx as nx


class SymbolicImageGraph:
    def __init__(self, f: Homeomorphism, domain: Domain):
        self._graph = nx.DiGraph()

        for cell in domain.get_cells():
            cell_image = f.apply(cell)
            image_cells = domain.get_cells_from_points(cell_image)

            self._graph.add_nodes_from()

