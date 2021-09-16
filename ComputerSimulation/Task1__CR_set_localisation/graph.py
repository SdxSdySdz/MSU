from geometry import Homeomorphism, Domain
import networkx as nx


class SymbolicImageGraph:
    def __init__(self, f: Homeomorphism, domain: Domain):
        self._graph = nx.DiGraph()

        for cell in domain.get_cells():
            image_points = f.apply_to_cell(cell)
            image_cells = domain.get_cells_from_points(image_points)

            cell_id = cell.id

            self._graph.add_edges_from((cell_id, image_cell.id) for image_cell in image_cells)

    def nonreturnable_vertexes_successfully_deleted(self):
        strongly_connected_components = nx.algorithms.strongly_connected_components(self._graph)

        strongly_connected_components = list(strongly_connected_components)


        returnable_vertexes = set()
        for strongly_connected_component in strongly_connected_components:
            if len(strongly_connected_component) == 1:
                vertex_id = strongly_connected_component.pop()
                if self._graph.has_edge(vertex_id, vertex_id):
                    returnable_vertexes.add(vertex_id)
            else:
                returnable_vertexes |= strongly_connected_component

        if not returnable_vertexes:
            return False

        self._graph = self._graph.subgraph(returnable_vertexes)

        return True
