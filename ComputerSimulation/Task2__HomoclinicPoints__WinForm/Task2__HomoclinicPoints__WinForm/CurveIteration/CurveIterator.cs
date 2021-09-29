using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.Diffeomorphisms;
using Task2__HomoclinicPoints__WinForm.Geometry;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;


namespace Task2__HomoclinicPoints__WinForm.CurveIteration
{
    class CurveIterator
    {
        private Diffeomorphism _f;
        private Polyline _segmentAsPolyline;
        private double _accuracy;

        private delegate Segment Operation(Segment side);

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

        public Polyline Solve(Segment segment, IterationDirection iterationDirection)
        {
            Operation MapSide;
            if (iterationDirection == IterationDirection.Positive)
            {
                MapSide = _f.Apply;
            }
            else
            {
                MapSide = _f.ApplyReverse;
            }

            _segmentAsPolyline = new Polyline(segment);

            // return MakeIterations(0, _segmentAsPolyline, 0);
            // return MakeIterationsWithoutRecursion();
            return MakeIterationsWithoutRecursion(MapSide);
        }


        private Polyline MakeIterationsWithoutRecursion(Operation MapSide)
        {
            /*            int lastUnsuccessIterationCount = 0;
                        Polyline lastUnsuccessPolyline = _segmentAsPolyline;
                        int lastUnsuccessSideIndex = 0;

                        bool isSuccessSplitting = false;
                        Polyline newPolyline = lastUnsuccessPolyline;*/

            List<Vector2> resultPoints = new List<Vector2>();
            int lastUnsuccessIterationCount = 0;
            int sideIndex = 0;

            Segment currentSide = _segmentAsPolyline.GetSide(0);
            bool isSplittingSuccessful;
            while (sideIndex < _segmentAsPolyline.SideCount)
            {
                isSplittingSuccessful = true;
                currentSide =  _segmentAsPolyline.GetSide(sideIndex);

                for (int iteraionCount = 0; iteraionCount < MaxIterationCount; iteraionCount++)
                {
                    currentSide = MapSide(currentSide);

                    if (currentSide.Length > _accuracy)
                    {
                        isSplittingSuccessful = false;
                        _segmentAsPolyline.SplitSide(sideIndex);
                        break;
                    }
                }
                
                if (isSplittingSuccessful)
                {
                    sideIndex++;
                    resultPoints.Add(currentSide.Start);
                }
            }

            resultPoints.Add(currentSide.End);

            return new Polyline(resultPoints);
        }
    }
}
