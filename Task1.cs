using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_3
{
    public struct Dot
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Dot(int[] coordinates)
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
            int dx = B.X - A.X;
            int dy = B.Y - A.Y;
            int dz = B.Z - A.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public override string ToString()
        {
            return $"{A}\n{B}\nLength = {Length()}";
        }
    }

    public class Task1
    {
        private Vector[] _vectors;
        public Vector[] Vectors => _vectors;

        public Task1(Vector[] vectors)
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

        public void Sorting()
        {
            QuickSort(_vectors, 0, _vectors.Length - 1);
        }

        public override string ToString()
        {
            return string.Join("\n", _vectors.Select(v => v.ToString()));
        }
    }
}