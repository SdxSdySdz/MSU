from matplotlib.widgets import Button
import matplotlib.pyplot as plt
import pylab


class Interface:
    def view(self):
        fig, graph_axes = pylab.subplots()
        graph_axes.grid()
        fig.subplots_adjust(left=1/5, right=4/5, top=0.9, bottom=0.1)

        graph_axes.plot([-100, 150], [20, 30])

        pylab.show()

    @staticmethod
    def _on_solve_button_clicked(event):
        ...

i = Interface()

i.view()