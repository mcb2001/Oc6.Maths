using System;

namespace Oc6.Maths.Util
{
    public abstract class FibonacciHeap<T>
        where T : IComparable<T>
    {
        public int N { get; protected set; }
        public FibonacciHeapNode<T> Min { get; protected set; }

        protected abstract T MinValue { get; }
        protected abstract FibonacciHeap<T> CreateNew();

        public void Insert(ref FibonacciHeap<T> H, FibonacciHeapNode<T> x)
        {
            x.Degree = 0;
            x.Parent = null;
            x.Child = null;
            x.Left = x;
            x.Right = x;
            x.Mark = false;
            x.C = false;

            if (H.Min != null)
            {
                H.Min.Left.Right = x;
                x.Right = H.Min;
                x.Left = H.Min.Left;
                H.Min.Left = x;

                if (x.Key.CompareTo(H.Min.Key) < 0)
                {
                    H.Min = x;
                }
            }

            else
            {
                H.Min = x;
            }

            H.N++;
        }

        public FibonacciHeap<T> Union(FibonacciHeap<T> H1, FibonacciHeap<T> H2)
        {
            FibonacciHeapNode<T> np;
            FibonacciHeap<T> H = H1;
            H.Min.Left.Right = H2.Min;
            H2.Min.Left.Right = H.Min;
            np = H.Min.Left;
            H.Min.Left = H2.Min.Left;
            H2.Min.Left = np;
            return H;
        }

        public void Link(ref FibonacciHeap<T> H, FibonacciHeapNode<T> y,
            FibonacciHeapNode<T> z)
        {
            y.Left.Right = y.Right;
            y.Right.Left = y.Left;

            if (z.Right == z)
            {
                H.Min = z;
            }

            y.Left = y;
            y.Right = y;
            y.Parent = z;

            if (z.Child == null)
            {
                z.Child = y;
            }

            y.Right = z.Child;
            y.Left = z.Child.Left;
            z.Child.Left.Right = y;
            z.Child.Left = y;

            if (y.Key.CompareTo(z.Child.Key) < 0)
            {
                z.Child = y;
            }

            z.Degree++;
        }

        public void Consolidate(ref FibonacciHeap<T> H)
        {
            int d, D = 1 + (int)Math.Ceiling((Math.Log(H.N) / Math.Log(2.0)));
            FibonacciHeapNode<T>[] A = new FibonacciHeapNode<T>[D + 1];
            FibonacciHeapNode<T> x = H.Min, y, np, pt = x;

            do
            {
                pt = pt.Right;
                d = x.Degree;

                while (A[d] != null)
                {
                    y = A[d];

                    if (x.Key.CompareTo(y.Key) > 0)
                    {
                        np = x;
                        x = y;
                        y = np;
                    }

                    if (y == H.Min)
                    {
                        H.Min = x;
                    }

                    Link(ref H, y, x);

                    if (x.Right == x)
                    {
                        H.Min = x;
                    }

                    A[d] = null;
                    d++;
                }

                A[d] = x;
                x = x.Right;
            } while (x != H.Min);

            H = CreateNew();

            for (int j = 0; j <= D; j++)
            {
                if (A[j] != null)
                {
                    A[j].Left = A[j];
                    A[j].Right = A[j];

                    if (H.Min != null)
                    {
                        H.Min.Left.Right = A[j];
                        A[j].Right = H.Min;
                        A[j].Left = H.Min.Left;
                        H.Min.Left = A[j];
                        H.N++;

                        if (A[j].Key.CompareTo(H.Min.Key) < 0)
                        {
                            H.Min = A[j];
                        }
                    }

                    else
                    {
                        H.Min = A[j];
                        H.N = 1;
                    }
                }
            }
        }

        public FibonacciHeapNode<T> ExtractMin(ref FibonacciHeap<T> H)
        {
            FibonacciHeapNode<T> ptr, z = H.Min, x, np;

            if (z == null)
            {
                return z;
            }

            x = null;

            if (z.Child != null)
            {
                x = z.Child;
            }

            if (x != null)
            {
                ptr = x;

                do
                {
                    np = x.Right;
                    H.Min.Left.Right = x;
                    x.Right = H.Min;
                    x.Left = H.Min.Left;
                    H.Min.Left = x;

                    if (x.Key.CompareTo(H.Min.Key) < 0)
                    {
                        H.Min = x;
                    }

                    x.Parent = null;
                    x = np;
                } while (np != ptr);
            }

            z.Left.Right = z.Right;
            z.Right.Left = z.Left;
            H.Min = z.Right;

            if (z == z.Right && z.Child == null)
            {
                H.Min = null;
            }
            else
            {
                H.Min = z.Right;

                if (H.N > 0)
                {
                    Consolidate(ref H);
                }
            }

            return z;
        }

        private void Cut(ref FibonacciHeap<T> H, FibonacciHeapNode<T> x,
            FibonacciHeapNode<T> y)
        {
            if (x == x.Right)
            {
                y.Child = null;
            }

            x.Left.Right = x.Right;
            x.Right.Left = x.Left;

            if (x == y.Child)
            {
                y.Child = x.Right;
            }

            y.Degree--;
            x.Right = x;
            x.Left = x;
            H.Min.Left.Right = x;
            x.Right = H.Min;
            x.Left = H.Min.Left;
            H.Min.Left = x;
            x.Parent = null;
            x.Mark = false;
        }

        private void CascadingCut(ref FibonacciHeap<T> H, FibonacciHeapNode<T> y)
        {
            FibonacciHeapNode<T> z = y.Parent;

            if (z != null)
            {
                if (y.Mark == false)
                {
                    y.Mark = true;
                }
                else
                {
                    Cut(ref H, y, z);
                    CascadingCut(ref H, z);
                }
            }
        }

        public FibonacciHeapNode<T> Find(FibonacciHeapNode<T> min, T k)
        {
            FibonacciHeapNode<T> x = min, p = null;

            x.C = true;

            if (x.Key.CompareTo(k) == 0)
            {
                p = x;
                x.C = false;
                return p;

            }

            if (p == null)
            {
                if (x.Child != null)
                {
                    p = Find(x.Child, k);
                }

                if (x.Right.C != true)
                {
                    p = Find(x.Right, k);
                }
            }

            x.C = false;
            return p;
        }

        public bool DecreaseKey(ref FibonacciHeap<T> H, FibonacciHeapNode<T> x, T k)
        {
            if (k.CompareTo(x.Key) > 0)
            {
                return false;
            }

            x.Key = k;

            FibonacciHeapNode<T> y = x.Parent;

            if (y != null && x.Key.CompareTo(y.Key) < 0)
            {
                Cut(ref H, x, y);
                CascadingCut(ref H, y);
            }

            if (x.Key.CompareTo(H.Min.Key) < 0)
            {
                H.Min = x;
            }

            return true;
        }

        public void Delete(ref FibonacciHeap<T> H, FibonacciHeapNode<T> x)
        {
            if (DecreaseKey(ref H, x, MinValue))
            {
                ExtractMin(ref H);
            }
        }
    }

    public class IntFibonacciHeap : FibonacciHeap<int>
    {
        protected override int MinValue { get; } = int.MinValue;

        protected override FibonacciHeap<int> CreateNew()
        {
            return new IntFibonacciHeap();
        }
    }

    public class LongFibonacciHeap : FibonacciHeap<long>
    {
        protected override long MinValue { get; } = long.MinValue;

        protected override FibonacciHeap<long> CreateNew()
        {
            return new LongFibonacciHeap();
        }
    }

    public class FloatFibonacciHeap : FibonacciHeap<float>
    {
        protected override float MinValue { get; } = float.MinValue;

        protected override FibonacciHeap<float> CreateNew()
        {
            return new FloatFibonacciHeap();
        }
    }

    public class DoubleFibonacciHeap : FibonacciHeap<double>
    {
        protected override double MinValue { get; } = double.MinValue;

        protected override FibonacciHeap<double> CreateNew()
        {
            return new DoubleFibonacciHeap();
        }
    }
}
