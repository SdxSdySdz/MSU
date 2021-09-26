using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.Diffeomorphisms;
using Task2__HomoclinicPoints__WinForm.Geometry;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm
{
    class CurveIterator
    {
        private Diffeomorphism _f;
        private Polyline _segmentAsPolyline;
        private double _accuracy;

        public int MaxIterationCount { get; private set; }


        public CurveIterator(Diffeomorphism f, int maxIterationCount, double accuracy)
        {
            if (maxIterationCount <= 0)
            {
                throw new Exception("Max iteration count should be > 0");
            }

            _f = f;
            MaxIterationCount = maxIterationCount;
            _accuracy = accuracy;
        }

        public Polyline Solve(Segment segment)
        {
            _segmentAsPolyline = new Polyline(segment);
            
            if (segment.Length <= _accuracy)
            {
                return _segmentAsPolyline;
            }

            // return MakeIterations(0, _segmentAsPolyline, 0);
            return MakeIterationsWithoutRecursion();
            return MakeIterationsWithoutRecursion_V2();
        }


        private Polyline MakeIterationsWithoutRecursion_V2()
        {
            /*            int lastUnsuccessIterationCount = 0;
                        Polyline lastUnsuccessPolyline = _segmentAsPolyline;
                        int lastUnsuccessSideIndex = 0;

                        bool isSuccessSplitting = false;
                        Polyline newPolyline = lastUnsuccessPolyline;*/

            List<Vector2> resultPoints = new List<Vector2>();
            int sideIndex = 0;
            bool isSlittingSuccess = true;

            int lastUnsuccessIterationCount = 0;
            Segment lastUnsuccessSide = _segmentAsPolyline.GetSide(sideIndex);

            while (sideIndex < _segmentAsPolyline.SideCount)
            {
                isSlittingSuccess = true;

                Segment side = lastUnsuccessSide;

                for (int i = lastUnsuccessIterationCount; i < MaxIterationCount; i++)
                {
                    side = _f.Apply(side);

                    if (side.Length > _accuracy)
                    {
                        isSlittingSuccess = false;

                        lastUnsuccessIterationCount = i;
                        lastUnsuccessSide = side;

                        _segmentAsPolyline.SplitSide(sideIndex);
                        break;
                    }
                }

                if (isSlittingSuccess)
                {
                    resultPoints.Add(side.Start);
                    sideIndex++;
                }
            }

/*            for (int i = 0; i < MaxIterationCount; i++)
            {
                _segmentAsPolyline = _f.Apply(_segmentAsPolyline);
            }*/
            return new Polyline(resultPoints);
        }


        private Polyline MakeIterationsWithoutRecursion()
        {
            int lastUnsuccessIterationCount = 0;
            Polyline lastUnsuccessPolyline = _segmentAsPolyline;
            int lastUnsuccessSideIndex = 0;

            bool isSuccessSplitting = false;
            Polyline newPolyline = lastUnsuccessPolyline;
            while (isSuccessSplitting == false)
            {
                _segmentAsPolyline.SplitSide(lastUnsuccessSideIndex);
                isSuccessSplitting = true;

                newPolyline = lastUnsuccessPolyline;

                if (lastUnsuccessIterationCount > 0)
                {
                    // Vector2 newPoint = _segmentAsPolyline.GetSide(lastUnsuccessSideIndex).End;
                    Vector2 newPoint = _segmentAsPolyline.GetVertex(lastUnsuccessSideIndex + 1);

                    for (int iterationCount = 0; iterationCount < lastUnsuccessIterationCount; iterationCount++)
                    {
                        newPoint = _f.Apply(newPoint);
                    }

                    newPolyline.Insert(newPoint, lastUnsuccessSideIndex);
                }

                for (int iterationCount = lastUnsuccessIterationCount; iterationCount < MaxIterationCount; iterationCount++)
                {
                    for (int sideIndex = lastUnsuccessSideIndex; sideIndex < newPolyline.SideCount; sideIndex++)
                    {
                        Segment side = newPolyline.GetSide(sideIndex);

                        if (side.Length > _accuracy)
                        {
                            lastUnsuccessPolyline = newPolyline;
                            lastUnsuccessIterationCount = iterationCount;
                            lastUnsuccessSideIndex = sideIndex;
                            isSuccessSplitting = false;
                            break;
                        }
                    }

                    if (isSuccessSplitting)
                    {
                        lastUnsuccessSideIndex = 0;
                        newPolyline = _f.Apply(newPolyline);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return newPolyline;
        }

        private Polyline MakeIterations(int lastUnsuccessIterationCount, Polyline lastUnsuccessPolyline, int lastUnsuccessSideIndex)
        {
            _segmentAsPolyline.SplitSide(lastUnsuccessSideIndex);
            Polyline newPolyline = lastUnsuccessPolyline;

            if (lastUnsuccessIterationCount > 0)
            {
                // Vector2 newPoint = _segmentAsPolyline.GetSide(lastUnsuccessSideIndex).End;
                Vector2 newPoint = _segmentAsPolyline.GetVertex(lastUnsuccessSideIndex + 1);

                for (int iterationCount = 0; iterationCount < lastUnsuccessIterationCount; iterationCount++)
                {
                    newPoint = _f.Apply(newPoint);
                }

                newPolyline.Insert(newPoint, lastUnsuccessSideIndex);
            }


            for (int iterationCount = lastUnsuccessIterationCount; iterationCount < MaxIterationCount; iterationCount++)
            {
                for (int sideIndex = lastUnsuccessSideIndex; sideIndex < newPolyline.SideCount; sideIndex++)
                {
                    Segment side = newPolyline.GetSide(sideIndex);

                    if (side.Length > _accuracy)
                    {
                        newPolyline = MakeIterations(iterationCount, newPolyline, sideIndex);
                        return newPolyline;
                    }
                }

                lastUnsuccessSideIndex = 0;
                newPolyline = _f.Apply(newPolyline);
            }

            return newPolyline;
        }
    }
}
