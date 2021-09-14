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

    def nonreturnable_vertexes_successfully_deleted(self):
        strongly_connected_components = nx.algorithms.strongly_connected_components(self._graph)
        if len(strongly_connected_components) == 0:
            return False

        returnable_vertexes = {}
        for strongly_connected_component in strongly_connected_components:
            returnable_vertexes += strongly_connected_component

        self._graph = self._graph.subgraph(returnable_vertexes)
        return True
