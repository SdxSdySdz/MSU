from geometry import Homeomorphism, Domain
import networkx as nx


class SymbolicImageGraph:
    def __init__(self, f: Homeomorphism, domain: Domain):
        self._graph = nx.DiGraph()

        for cell in domain.get_cells():
            cell_image = f.apply(cell)
            image_cells = domain.get_cells_from_points(cell_image)

            cell_id = cell.id

            self._graph.add_node(cell_id)
            self._graph.add_edges_from((cell_id, image_cell.id) for image_cell in image_cells)
