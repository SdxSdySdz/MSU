import numpy as np
from matplotlib.widgets import Button
from matplotlib.patches import Rectangle
from geometry import Domain, Cell, QuadraticMapping

import matplotlib.pyplot as plt
import pylab


class Interface:
    def __init__(self):
        self._axes = None

    def view(self, domain: Domain):
        fig, self._axes = pylab.subplots()
        self._axes.grid()
        fig.subplots_adjust(left=1/5, right=4/5, top=0.9, bottom=0.1)

        # self._axes.plot([domain._low_point[0], domain._high_point[0]], [domain._low_point[1], domain._high_point[1]])
        self._axes.plot([-1, 1], [-1, 1])

        for cell in domain.get_cells():
            self._draw_cell(cell, domain.cell_size)

        pylab.show()
        self._axes = None

    def _draw_cell(self, cell: Cell, cell_size):
        rect = Rectangle(tuple(cell.low), cell_size[0], cell_size[1], edgecolor='green', fill=None)
        self._axes.add_patch(rect)


    @staticmethod
    def _on_solve_button_clicked(event):
        ...


