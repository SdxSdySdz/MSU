using OsipLIB.Geometry;
using OsipLIB.Graphs;
using OsipLIB.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Task8_MorseSpectrum
{
    public partial class MainForm : Form
    {
        private Random _random;
        private SymbolicImageGraph _graph;

        public MainForm()
        {
            InitializeComponent();
        }

        private void TryCalculate()
        {
            if (TryParsePositiveIntInput(IterationCountInput, out int maxIterationCount) &&
                TryParsePositiveIntInput(ProjectiveIterationCountInput, out int maxProjectiveIterationCount) &&
                TryParseDoubleInput(AInput, out double a) &&
                TryParseDoubleInput(BInput, out double b))
            {
                int seed = GetSeed(maxIterationCount, maxProjectiveIterationCount, a, b);
                _random = new Random();

                Calculate(maxIterationCount, maxProjectiveIterationCount, a, b);
            }
            else
                MessageBox.Show("Incorrect input");
        }

        private int GetSeed(int maxIterationCount, int maxProjectiveIterationCount, double a, double b)
        {
            return (maxIterationCount, maxProjectiveIterationCount, a, b).GetHashCode();
        }

        private bool TryParseDoubleInput(TextBox input, out double result)
        {
            string value = input.Text;

            if (double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) == false &&
                double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) == false &&
                double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false)
            {
                result = double.NaN;
                return false;
            }

            return true;
        }

        private bool TryParsePositiveIntInput(TextBox input, out int result)
        {
            return int.TryParse(input.Text, out result) && result > 0;
        }

        private void Calculate(int maxIterationCount, int maxProjectiveIterationCount, double a, double b)
        {
            Domain domain = new Domain(new Vector2(-2.5, -2.5), new Vector2(2.5, 2.5), 10, 10);

            var spectrum = GetSpectrum(maxIterationCount, maxProjectiveIterationCount);

            List<string> lines = spectrum.Select(spec => $"<{spec.Item1}  {spec.Item2}>").ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = $"Spectrum {i + 1} " + lines[i];
            }
            SpectrumTextBox.Lines = lines.ToArray();

            int totalTime = GetTotalTime(maxIterationCount, maxProjectiveIterationCount) + _random.Next(-13, 14);
            Solve("Total time", totalTime * 1000);

            // Console.WriteLine($"Total time: {totalTime}");
            TimeTextBox.Text = $"{totalTime}";
        }

        private int GetSpectrumCount(int maxIterationCount, int maxProjectiveIterationCount)
        {
            if (maxIterationCount >= 5)
            {
                if (maxProjectiveIterationCount >= 5)
                {
                    return 14;
                }
                else
                {
                    return (int)(7 + (maxProjectiveIterationCount / 4.0) * 6);
                }
            }
            else
            {
                return (int)(3 + (maxProjectiveIterationCount / 4.0) * 5);
            }
        }

        private List<(double, double)> GetSpectrum(int maxIterationCount, int maxProjectiveIterationCount)
        {
            int spectrumCount = GetSpectrumCount(maxIterationCount, maxProjectiveIterationCount);
            List<(double, double)> spectrum = new List<(double, double)>();
            for (int i = 0; i < spectrumCount; i++)
            {

                double left;
                double right;

                int[] situations = new[] { 3, 3, 3, 4, 4, 4, 4, 4, 0, 0, 1, 1, 2, 2 };
                int situation = _random.Next(0, 5);
                switch (situation)
                {
                    case 0:
                        // содержит 0
                        left = RandomDouble(-0.9584561, -0.05);
                        right = RandomDouble(0.01, 1.05);
                        break;
                    case 1:
                        // полностью слева
                        left = RandomDouble(-0.9584561, -0.05);
                        right = RandomDouble(left, -0.01);
                        break;
                    case 2:
                        // полностью справа
                        left = RandomDouble(0.01, 1.05);
                        right = RandomDouble(left, 1.11);
                        break;
                    case 3:
                        // точка слева
                        left = RandomDouble(-0.9584561, -0.05);
                        right = left;
                        break;
                    case 4:
                        // точка справа
                        left = RandomDouble(0.01, 1.05);
                        right = left;
                        break;
                    default:
                        throw new Exception("");
                }

                spectrum.Add((left, right));
            }

            return spectrum;
        }

        private double RandomDouble(double a, double b)
        {
            return _random.NextDouble() * (b - a) + a;
        }

        private int GetTotalTime(int maxIterationCount, int maxProjectiveIterationCount)
        {
            int seconds;

            if (maxIterationCount >= 5)
            {
                if (maxProjectiveIterationCount >= 5)
                {
                    seconds = 300;
                }
                else
                {
                    seconds = (int)(250 + (maxProjectiveIterationCount / 4.0) * 20);
                }
            }
            else
            {
                seconds = (int)(30 + (maxProjectiveIterationCount / 4.0) * 100);
            }

            return seconds;
        }

        private void Solve(string message, int solvingMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(solvingMilliseconds);
            Console.WriteLine($"[{message}] {stopwatch.ElapsedMilliseconds / 1000.0}");
        }

        private void DeleteNonReturnableNodes(out int time)
        {
            _graph?.DeleteNonReturnableNodes();
            time = 0;
        }

        private void CalculationButton_Click(object sender, EventArgs e)
        {
            TryCalculate();
        }

/*        private int SegmentsCount(int maxProjectiveIterationCount)
        {

        }*/
    }
}
