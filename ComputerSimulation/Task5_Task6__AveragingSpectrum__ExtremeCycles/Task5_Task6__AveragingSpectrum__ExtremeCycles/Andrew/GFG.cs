using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Task6__AveragingSpectrum__ExtremeCycles.Andrew
{
    public class GFG
    {
        static int V;
        public double min, max;
        public Dictionary<int, int> pairsValue = new Dictionary<int, int>();
        private HashSet<int> min_ver = new HashSet<int>();
        private HashSet<int> max_ver = new HashSet<int>();

        public GFG(List<int> strong_comp, List<float> weights, Dictionary<int, int[]> graph)
        {
            V = weights.Count;
            edges = new List<Edge>[V];
            for (int i = 0; i < V; i++)
                edges[i] = new List<Edge>();

            Dictionary<int, int> valuePairs = new Dictionary<int, int>();
            int u = 0;
            foreach (int g_key in strong_comp)
            {
                valuePairs.Add(g_key, u);
                pairsValue.Add(u, g_key);
                u++;
            }

            foreach (int k in graph.Keys)
            {
                if (strong_comp.Contains(k))
                {
                    foreach (int sc in graph[k])
                    {
                        if (strong_comp.Contains(sc))
                        {
                            addedge(valuePairs[k], valuePairs[sc], weights[valuePairs[k]]);
                        }
                    }
                }
            }

            min = minAvgWeight();
            max = maxAvgWeight();
        }


        // a struct to represent
        // edges
        public class Edge
        {
            public int from;
            public float weight;
            public Edge(int from,
                        float weight)
            {
                this.from = from;
                this.weight = weight;
            }
        }

        // vector to store edges 
        List<Edge>[] edges;

        public HashSet<int> Min_ver { get => min_ver; set => min_ver = value; }
        public HashSet<int> Max_ver { get => max_ver; set => max_ver = value; }

        void addedge(int u,
                            int v, float w)
        {
            edges[v].Add(new Edge(u, w));
        }

        // calculates the shortest path
        void shortestpath(float[,] dp)
        {
            // initializing all distances
            // as -1
            for (int i = 0; i <= V; i++)
                for (int j = 0; j < V; j++)
                    dp[i, j] = -1;

            // shortest distance from
            // first vertex to in tself
            // consisting of 0 edges
            dp[0, 0] = 0;

            // filling up the dp table
            for (int i = 1; i <= V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    for (int k = 0;
                             k < edges[j].Count; k++)
                    {
                        if (dp[i - 1,
                               edges[j][k].from] != -1)
                        {
                            float curr_wt = dp[i - 1,
                                             edges[j][k].from] +
                                             edges[j][k].weight;
                            if (dp[i, j] == -1)
                                dp[i, j] = curr_wt;
                            else
                                dp[i, j] = Math.Min(dp[i, j],
                                                    curr_wt);
                        }
                    }
                }
            }
        }

        void maxpath(float[,] dp)
        {
            // initializing all distances
            // as -1
            for (int i = 0; i <= V; i++)
                for (int j = 0; j < V; j++)
                    dp[i, j] = -1;

            // shortest distance from
            // first vertex to in tself
            // consisting of 0 edges
            dp[0, 0] = 0;

            // filling up the dp table
            for (int i = 1; i <= V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    for (int k = 0;
                             k < edges[j].Count; k++)
                    {
                        if (dp[i - 1,
                               edges[j][k].from] != -1)
                        {
                            float curr_wt = dp[i - 1,
                                             edges[j][k].from] +
                                             edges[j][k].weight;
                            if (dp[i, j] == -1)
                                dp[i, j] = curr_wt;
                            else
                                dp[i, j] = Math.Max(dp[i, j],
                                                    curr_wt);
                        }
                    }
                }
            }
        }

        // Returns minimum value of
        // average weight of a cycle
        // in graph.
        double minAvgWeight()
        {
            float[,] dp = new float[V + 1, V];
            shortestpath(dp);

            // array to store the
            // avg values
            float[] avg = new float[V];

            for (int i = 0; i < V; i++)
                avg[i] = -10;

            float andre = 100;

            // Compute average values for
            // all vertices using weights
            // of shortest paths store in dp.
            for (int i = 0; i < V; i++)
            {
                if (dp[V, i] != -1)
                {
                    for (int j = 0; j < V; j++)
                        if (dp[j, i] != -1)
                        {
                            avg[i] = Math.Max(avg[i],
                                             (dp[V, i] -
                                               dp[j, i]) /
                                               (V - j));
                        }
                }

                float andre_last = andre;
                if (avg[i] != -10f)
                {
                    andre = Math.Min(andre, avg[i]);
                    if (andre != andre_last)
                    {
                        min_ver.Add(pairsValue[i]);
                    }
                }
            }

            return andre;
        }
        double maxAvgWeight()
        {
            float[,] dp = new float[V + 1, V];
            maxpath(dp);

            // array to store the
            // avg values
            float[] avg = new float[V];

            for (int i = 0; i < V; i++)
                avg[i] = 15;
            float maxim = -1;
            // Compute average values for
            // all vertices using weights
            // of shortest paths store in dp.
            for (int i = 0; i < V; i++)
            {
                if (dp[V, i] != -1)
                {
                    for (int j = 0; j < V; j++)
                        if (dp[j, i] != -1)
                            avg[i] = Math.Min(avg[i],
                                             (dp[V, i] -
                                               dp[j, i]) /
                                               (V - j));
                    float last_maxim = maxim;
                    if (avg[i] != 15)
                    {
                        maxim = Math.Max(maxim, avg[i]);
                        if (maxim != last_maxim)
                        {
                            max_ver.Add(pairsValue[i]);
                        }
                    }
                }
            }

            return maxim;
        }
    }
}
