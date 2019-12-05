using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace AdventOfCode2019 
{
    public class Day3A : IPuzzle 
    {
        public void Execute() {
            var wirePaths = File.ReadAllLines("day3/input.txt");

            var wireOne = ParsePath(wirePaths[0]);
            var wireTwo = ParsePath(wirePaths[1]);

            var intersections = FindIntersections(wireOne, wireTwo);

            var minDistance = int.MaxValue;
            foreach(var intersection in intersections) 
            {
                var dist = ComputeManhattanDistanceToOrigin(intersection);

                if(dist < minDistance)
                {
                    minDistance = dist;
                }
            }

            Console.WriteLine($"Shortest distance: {minDistance}");
        }

        private int ComputeManhattanDistanceToOrigin(Point p) => Math.Abs(p.X) + Math.Abs(p.Y);
        private List<Point> FindIntersections(Point[] one, Point[] two) 
        {
            var result = new List<Point>();

            for (var i = 0; i < one.Length; i++) 
            {
                var oneStart = i == 0 ? new Point(0, 0) : one[i - 1];
                var oneEnd = one[i];
                for (var j = 0; j < two.Length; j++) 
                {
                    var twoStart = j == 0 ? new Point(0,0) : two[j - 1];
                    var twoEnd = two[j];

                    var xInRange = (oneStart.X < twoStart.X && oneEnd.X > twoEnd.X)
                                    || (oneStart.X > twoStart.X && oneEnd.X < twoEnd.X);
                    var yInRange = (oneStart.Y < twoStart.Y && oneEnd.Y > twoEnd.Y)
                                    || (oneStart.Y > twoStart.Y && oneEnd.Y < twoEnd.Y);

                    if(xInRange && yInRange) 
                    {
                        var x = oneStart.X == oneEnd.X ? oneStart.X : twoStart.X;
                        var y = oneStart.Y == oneEnd.Y ? oneStart.Y : twoStart.Y;

                        result.Add(new Point(x, y));
                    }
                }
            }

            return result;
        }

        private Point[] ParsePath(string path) 
        {
            var steps = path.Split(",");
            var result = new Point[steps.Length];

            var x = 0;
            var y = 0;
            for (var s = 0; s < steps.Length; s++)
            {
                var step = steps[s];
                var dir = step[0];
                var val = int.Parse(step.Remove(0, 1));

                switch (dir)
                {
                    case 'R':
                        x += val;
                        break;
                    case 'L':
                        x -= val;
                        break;
                    case 'U':
                        y += val;
                        break;
                    case 'D':
                        y -= val;
                        break;
                }

                result[s] = new Point(x, y);
            }

            return result;
        }
    }
}