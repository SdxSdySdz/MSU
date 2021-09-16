import math

from CR_Localizator import CR_Localizator
from geometry import QuadraticMapping, Domain
from interface import Interface

import numpy as np


def main():
    i = Interface()
    f = QuadraticMapping(0, 0)

    low = np.array([-5, -5])
    high = np.array([5, 5])
    d = Domain(
        low,
        high,
        100,
        100,
    )

    cr_loc = CR_Localizator(
        8
    )

    d = cr_loc.solve(f, d)

    # i.view(d)


if __name__ == '__main__':
    main()
