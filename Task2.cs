using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task2
    {

        public struct Dot
        {
            public double X { get; }
            public double Y { get; }
            public double Z { get; }

            public Dot(double[] coordinates)
            {
                if (coordinates.Length == 3)
                {
                    X = coordinates[0];
                    Y = coordinates[1];
                    Z = coordinates[2];
                }
                else
                {
                    X = 0;
                    Y = 0;
                    Z = 0;
                }
            }

            public override string ToString()
            {
                return $"x = {X}, y = {Y}, z = {Z}";
            }
        }

        public struct Vector
        {
            public Dot A { get; }
            public Dot B { get; }

            public Vector(Dot a, Dot b)
            {
                A = a;
                B = b;
            }

            public double Length()
            {
                double dx = B.X - A.X;
                double dy = B.Y - A.Y;
                double dz = B.Z - A.Z;
                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }

            public override string ToString()
            {
                return $"{A}\n{B}\nLength = {Length()}";
            }
        }

        public abstract class Shape
        {
            public Dot Center { get; }
            public Vector Pointer { get; private set; }

            public Shape(Dot center)
            {
                Center = center;
            }

            public void CreateVector(Dot point)
            {
                Pointer = new Vector(Center, point);
            }

            public abstract double Volume();

            public override string ToString()
            {
                return $"{GetType().Name} with V = {Volume()}";
            }
        }

        public class Sphere : Shape
        {
            public Sphere(Dot center) : base(center) { }

            public override double Volume()
            {
                double radius = Pointer.Length();
                return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
            }
        }

        public class Cube : Shape
        {
            public Cube(Dot center) : base(center) { }

            public override double Volume()
            {
                double side = Pointer.Length() * Math.Sqrt(3); // length of vector represents half-diagonal
                return Math.Pow(side, 3);
            }
        }

        public class _Task2
        {
            private Shape[] _shapes;
            public Shape[] Shapes => _shapes;

            public _Task2(Shape[] shapes)
            {
                _shapes = shapes;
            }

            private void QuickSort(Shape[] array, int low, int high)
            {
                if (low < high)
                {
                    int pi = Partition(array, low, high);

                    QuickSort(array, low, pi - 1);
                    QuickSort(array, pi + 1, high);
                }
            }

            private int Partition(Shape[] array, int low, int high)
            {
                double pivot = array[high].Volume();
                int i = (low - 1);

                for (int j = low; j < high; j++)
                {
                    if (array[j].Volume() <= pivot)
                    {
                        i++;
                        Swap(ref array[i], ref array[j]);
                    }
                }

                Swap(ref array[i + 1], ref array[high]);
                return i + 1;
            }

            private void Swap(ref Shape a, ref Shape b)
            {
                Shape temp = a;
                a = b;
                b = temp;
            }


            public void Sorting(_Task2 task)
            {
                QuickSort(task._shapes, 0, task._shapes.Length - 1);
            }

            public override string ToString()
            {
                var result = "";
                foreach (var shape in _shapes)
                {
                    result += shape.ToString() + "\n";
                }
                return result;
            }
        }

        public class _Task1
        {
            private Vector[] _vectors;
            public Vector[] Vectors => _vectors;

            public _Task1(Vector[] vectors)
            {
                _vectors = vectors;
            }

            private void QuickSort(Vector[] array, int low, int high)
            {
                if (low < high)
                {
                    int pi = Partition(array, low, high);

                    QuickSort(array, low, pi - 1);
                    QuickSort(array, pi + 1, high);
                }
            }

            private int Partition(Vector[] array, int low, int high)
            {
                double pivot = array[high].Length();
                int i = (low - 1);

                for (int j = low; j < high; j++)
                {
                    if (array[j].Length() <= pivot)
                    {
                        i++;
                        Swap(ref array[i], ref array[j]);
                    }
                }

                Swap(ref array[i + 1], ref array[high]);
                return i + 1;
            }

            private void Swap(ref Vector a, ref Vector b)
            {
                Vector temp = a;
                a = b;
                b = temp;
            }

            public void Sorting(_Task1 task)
            {
                QuickSort(task._vectors, 0, task._vectors.Length - 1);
            }

            public override string ToString()
            {
                var result = "";
                foreach (var vector in _vectors)
                {
                    result += vector.ToString() + "\n";
                }
                return result;
            }
        }
    }
}using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task2
    {
       
    }
}
