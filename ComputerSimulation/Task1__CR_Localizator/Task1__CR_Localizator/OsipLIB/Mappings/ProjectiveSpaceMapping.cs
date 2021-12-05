using System;
using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    public class ProjectiveSpaceMapping : Mapping
    {
        private static Rectangle[] _maps;
        private static Rectangle _comprehensiveArea;

        private Matrix3x3 _matrix;

        public ProjectiveSpaceMapping(PointSampler pointSampler, Matrix3x3 matrix) : base(pointSampler)
        {
            _maps = new[]
            {
                new Rectangle(new Vector2(0, 0), new Vector2(2, 2)),
                new Rectangle(new Vector2(2, 0), new Vector2(4, 2)),
                new Rectangle(new Vector2(4, 0), new Vector2(6, 2)),
            };
            _comprehensiveArea = new Rectangle(new Vector2(0, 0), new Vector2(6, 2));
            _matrix = new Matrix3x3(matrix);
        }

        public override Vector2 Apply(Vector2 point)
        {
            if (_comprehensiveArea.ContainsPoint(point) == false)
                throw new Exception($"Point {point} does not correspond to any map");

            Vector3 worldPoint = ToWorldSpace(point);
            worldPoint = _matrix * worldPoint;

            return ToMapSpace(worldPoint);
        }

        private static Vector3 ToWorldSpace(Vector2 point)
        {
            if (_maps[0].ContainsPoint(point))
            {
                point -= Vector2.One;
                return new Vector3(1, point.x, point.y);
            }
            else if (_maps[1].ContainsPoint(point))
            {
                point -= new Vector2(2, 0);
                point -= Vector2.One;
                return new Vector3(point.x, 1, point.y);
            }
            else
            {
                point -= new Vector2(4, 0);
                point -= Vector2.One;
                return new Vector3(point.x, point.y, 1);
            }
        }

        private static Vector2 ToMapSpace(Vector3 point)
        {
            point = Project(point);

            if (point.x == 1)
            {
                return new Vector2(point.y, point.z) + Vector2.One;
            }
            else if (point.y == 1)
            {
                return new Vector2(point.x, point.z) + Vector2.One + Vector2.Right * 2;
            }
            else if (point.z == 1)
            {
                return new Vector2(point.x, point.y) + Vector2.One + Vector2.Right * 4;
            }
            else
            {
                throw new Exception();
            }
        }

        private static Vector3 Project(Vector3 point)
        {
            double absX = Math.Abs(point.x);
            double absY = Math.Abs(point.y);
            double absZ = Math.Abs(point.z);

            double max;
            if (absX > absY && absX > absZ)
                max = point.x;
            else if (absY > absX && absY > absZ)
                max = point.y;
            else
                max = point.z;

            point /= max;

            return point;
        }
    }
}