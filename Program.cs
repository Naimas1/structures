using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structures
{
    struct Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return new Vector3D(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
        }

        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public void Normalize()
        {
            double magnitude = Magnitude();
            if (magnitude != 0)
            {
                X /= magnitude;
                Y /= magnitude;
                Z /= magnitude;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }

    class Programs
    {
        static void Main()
        {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(4, 5, 6);

            Console.WriteLine("Vector1: " + vector1);
            Console.WriteLine("Vector2: " + vector2);

            Vector3D scaledVector = vector1 * 2;
            Console.WriteLine("Scaled vector: " + scaledVector);

            Vector3D sumVector = vector1 + vector2;
            Console.WriteLine("Sum vector: " + sumVector);

            Vector3D differenceVector = vector1 - vector2;
            Console.WriteLine("Difference vector: " + differenceVector);

            double magnitude = vector1.Magnitude();
            Console.WriteLine("Magnitude of vector1: " + magnitude);

            vector2.Normalize();
            Console.WriteLine("Normalized vector2: " + vector2);
        }
    }
}
