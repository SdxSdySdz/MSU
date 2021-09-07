from collections import defaultdict
from typing import List
from geometry import Homeomorphism, Compact


class CR_Localizator:
    def __init__(self, f: Homeomorphism, compact: Compact):
        # 1 constuct SymbolicImageGraph from f and compact
        # 2 find return_vertexes
        # 3 split cells
        # 4 constuct new SymbolicImageGraph
        # 5 continue from step 2 until convergence of cell diameter
        ...