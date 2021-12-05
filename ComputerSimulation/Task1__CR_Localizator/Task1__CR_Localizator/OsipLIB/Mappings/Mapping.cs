﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    public abstract class Mapping
    {
        protected PointSampler PointSampler;


        protected Mapping(PointSampler pointSampler)
        {
            PointSampler = pointSampler;
        } 


        public abstract Vector2 Apply(Vector2 point);


        public Vector2[] Apply(Vector2[] points)
        {
            Vector2[] newPoints = new Vector2[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                newPoints[i] = Apply(points[i]);
            }

            return newPoints;
        }

        // public Vector2[] Apply(Vector2[] points) => points.AsParallel().Select(point => Apply(point)).ToArray();


        public Vector2[] ApplyToArea(Cell cell)
        {
            Vector2[] samples = PointSampler.Sample(cell);

            return Apply(samples);
        }
    }
}
