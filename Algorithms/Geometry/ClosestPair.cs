using System;
using System.Collections.Generic;
using System.Numerics;
using Algorithms.Sorting;

namespace Algorithms.Geometry
{
    public class ClosestPair
    {
        public static Vector2[] ClosestPairsIn2D(Vector2[] Points)
        {
            var Px = SortPointsByDimension(Points, 0);
            var Py = SortPointsByDimension(Points, 1);

            return ClosestPairsIn2DRecursive(Px, Py);
        }

        public static Vector2[] ClosestPairsIn2DRecursive(Vector2[] Px, Vector2[] Py)
        {            

            Vector2[] LeftX;
            Vector2[] LeftY;
            Vector2[] RightX;
            Vector2[] RightY;

            if(Px.Length > 2)
            {
                int midPoint = Px.Length / 2;

                int leftStart = 0;
                int leftLength = (midPoint % 2 == 0) ? midPoint : midPoint + 1;

                LeftX = new Vector2[leftLength];
                LeftY = new Vector2[leftLength];

                int rightStart = midPoint;
                int rightLength = Px.Length - midPoint;

                RightX = new Vector2[rightLength];
                RightY = new Vector2[rightLength];

                int k = 0;

                for(int i=leftStart; i<leftLength; i++)
                {
                    LeftX[k] = Px[i];
                    LeftY[k] = Py[i];
                    k++;
                }

                k = 0;

                for(int j=rightStart; j<rightStart+rightLength; j++)
                {
                    RightX[k] = Px[j];
                    RightY[k] = Py[j];
                    k++;
                }

                var Q = ClosestPairsIn2DRecursive(LeftX, LeftY);
                var R = ClosestPairsIn2DRecursive(RightX, RightY);


                double q = (Q.Length == 2) ? EuclideanDistance(Q) : double.MaxValue;
                double r = (R.Length == 2) ? EuclideanDistance(R) : double.MaxValue;

                var P = (q < r) ? Q : R; 

                double delta = Math.Min(q, r);

                var S = ClosestSplitPair(Px, Py, delta);

                return S ?? P;
            }
            else
            {
                double x = EuclideanDistance(Px);
                double y = EuclideanDistance(Py);

                return (x > y) ? Py : Px;
            }
                
        }
                       
           
        public static Vector2[] ClosestSplitPair(Vector2[] Px, Vector2[] Py, double delta)
        {
            
            Vector2[] ClosestPair = null;

            int halfway = Px.Length / 2;
            double xBar = Px[halfway - 1].X;

            double bestGuess = delta;

            Vector2[] Sy = GetSortedYSublistWithinRange(Py, xBar - delta, xBar + delta);

            for(int i=0; i<Sy.Length - 8; i++)
            {
                for(int j=0; j<7; j++)
                {
                    Vector2[] pair = new Vector2[]{ Sy[i], Sy[i+j]};
                    double distance = (pair.Length == 2) ? EuclideanDistance(pair) : double.MaxValue;

                    if (distance < bestGuess) ClosestPair = pair;
                }
            }

            return ClosestPair;
        }

        public static Vector2[] GetSortedYSublistWithinRange(Vector2[] SortedPoints, double min, double max)
        {
            var result = new List<Vector2>();

            for(var i=0; i<SortedPoints.Length; i++)
            {
                if(SortedPoints[i].Y >= min && SortedPoints[i].Y <= max)
                {
                    result.Add(SortedPoints[i]);
                }

                // todo: don't keep searching if SortedPoints[i] > max
            }

            return result.ToArray();
        }

        public static Vector2[] SortPointsByDimension(Vector2[] points, int dimension)
        {
            Vector2[] result;
            Vector2[] left;
            Vector2[] right;

            if (points.Length <= 1)
                return points;
 
            int midPoint = points.Length / 2;

            left = new Vector2[midPoint];

            if (points.Length % 2 == 0)
                right = new Vector2[midPoint];
            else
                right = new Vector2[midPoint + 1];
            for (int i = 0; i < midPoint; i++)
                left[i] = points[i];
  
            int x = 0;
            
            for (int i = midPoint; i < points.Length; i++)
            {
                right[x] = points[i];
                x++;
            }

            left = SortPointsByDimension(left, dimension);
            right = SortPointsByDimension(right, dimension);

            result = MergePointsByDimension(left, right, dimension);
            return result;
        }

        public static Vector2[] MergePointsByDimension(Vector2[] left, Vector2[] right, int dimension)
        {
            int resultLength = right.Length + left.Length;
            Vector2[] result = new Vector2[resultLength];
            
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (dimension == 0)
                    {
                        if (left[indexLeft].X <= right[indexRight].X)
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }

                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }
                    else if(dimension == 1)
                    {
                        if (left[indexLeft].Y <= right[indexRight].Y)
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }

                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }
                }

                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }

                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        public static double EuclideanDistance(Vector2[] input)
        {
            return Math.Sqrt(Math.Pow(input[0].X - input[1].X, 2) + Math.Pow(input[0].Y - input[1].Y, 2));
        }
    }
}
