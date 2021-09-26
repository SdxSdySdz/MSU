from collections import defaultdict

import numpy as np
from matplotlib.widgets import Button
from matplotlib.patches import Rectangle

import matplotlib.pyplot as plt
import pylab

import statistics

from typing import Tuple
import numpy as np

def hack(cells, cell_size, apply_x=True, apply_y=True):
    grid_yx = defaultdict(list)
    grid_xy = defaultdict(list)

    if apply_y:
        new_cells = []

        for cell in cells:
            grid_yx[cell[1]].append(cell[0])

        for y, xs in grid_yx.items():
            N = len(xs)

            if N > 3:
                xs = sorted(xs)
                xs = xs[1:-1]
                new_cells += [(x, y) for x in xs]



            # if N < 1000:
            #     new_cells += [(x, y) for x in xs]
            # else:
            #     xs = sorted(xs)
            #
            #     component = [xs[0]]
            #     current_distance = xs[1] - xs[0]
            #     for i in range(N - 1):
            #         distance = xs[i + 1] - xs[i]
            #         if distance > 2 * cell_size:
            #             if len(component) < 4:
            #                 new_cells += [(x, y) for x in component]
            #             else:
            #
            #                 component = component[1:-1]
            #                 new_cells += [(x, y) for x in component]
            #
            #             component = [xs[i + 1]]
            #         elif distance < 2 * cell_size:
            #             component.append(xs[i + 1])
            #
            #         current_distance = distance


        # for y, xs in grid_yx.items():
        #     xs = sorted(xs)
        #     N = len(xs)
        #     # xs = xs[1:-1]
        #
        #     cell_size = xs[1] - xs[0]
        #     component = [xs[0]]
        #     for i in range(N - 1):
        #         if xs[i + 1] - xs[i] == cell_size:
        #             component.append(xs[i + 1])
        #         else:
        #             print(component)
        #             n = N // 2
        #
        #             if N > 3:
        #                 component = component[1:-1]
        #
        #             new_cells += [(x, y) for x in component]
        #
        #             component = [xs[i + 1]]

        cells = new_cells

    if apply_x:
        new_cells = []

        for cell in cells:
            grid_xy[cell[0]].append(cell[1])

        for x, ys in grid_yx.items():
            ys = sorted(ys)
            ys = ys[1:-1]

            new_cells += [(y, x) for y in ys]

        cells = new_cells

    return cells


class Interface:
    def __init__(self):
        self._fig = None
        self._ax = None

    def view(self, cells, size, time, DOTS_PER_POINT):
        from main import get_dots_from_cell
        self._fig = plt.figure(1, [4, 4])
        fig = plt.gcf()
        self._ax = fig.gca()

        plt.ylim((-2, 2))
        plt.xlim((-2, 2))

        f, s = [], []
        for cell in cells:
            dots = get_dots_from_cell(cell, size, DOTS_PER_POINT)
            for dot in dots:
                f.append(dot[0])
                s.append(dot[1])
            plt.plot(f, s, color="blue")
            f.clear()
            s.clear()

        cells = hack(cells, size, apply_x=False, apply_y=True)

        f, s = [], []
        for cell in cells:

            dots = get_dots_from_cell(cell, size, DOTS_PER_POINT)
            for dot in dots:
                f.append(dot[0])
                s.append(dot[1])
            plt.plot(f, s, color="green")
            f.clear()
            s.clear()

        # f, s = [], []
        # dots = get_dots_from_cell((0.0, 0.0), size, DOTS_PER_POINT)
        # for dot in dots:
        #     f.append(dot[0])
        #     s.append(dot[1])
        # plt.plot(f, s, color="red")
        # f.clear()
        # s.clear()

        plt.plot(f, s, color="green")

        plt.show()

    # def _draw_cell(self, cell: Tuple[float, float], cell_size):
    #
    #     # rect = Rectangle((index[0] * cell_size, index[1] * cell_size), cell_size, cell_size, edgecolor='green', fill=None)
    #     # plt.plot([index[0] * cell_size, (index[0] + 1) * cell_size], [index[1] * cell_size, (index[1] + 1) * cell_size])
    #     # low = (index[0] * cell_size, index[1] * cell_size)
    #     # high = ((index[0] + 1) * cell_size, (index[1] + 1) * cell_size)
    #     rect = Rectangle((index[0] * cell_size, index[1] * cell_size), cell_size, cell_size, edgecolor='green',
    #                      fill=None)
    #     self._ax.add_patch(rect)


    @staticmethod
    def _on_solve_button_clicked(event):
        ...


