namespace Oc6.Maths.Util
{
    public class FibonacciHeapNode<T>
    {
        private bool c, mark;
        private int degree;
        private T key;
        private FibonacciHeapNode<T> parent, child, left, right;

        public bool C
        {
            get => c;

            set => c = value;
        }

        public bool Mark
        {
            get => mark;

            set => mark = value;
        }

        public int Degree
        {
            get => degree;

            set => degree = value;
        }

        public T Key
        {
            get => key;

            set => key = value;
        }

        public FibonacciHeapNode<T> Parent
        {
            get => parent;

            set => parent = value;
        }

        public FibonacciHeapNode<T> Left
        {
            get => left;

            set => left = value;
        }

        public FibonacciHeapNode<T> Right
        {
            get => right;

            set => right = value;
        }

        public FibonacciHeapNode<T> Child
        {
            get => child;

            set => child = value;
        }

        public FibonacciHeapNode() { }

        public FibonacciHeapNode(int degree, T key)
        {
            this.degree = degree;
            this.key = key;
        }

        public FibonacciHeapNode(FibonacciHeapNode<T> copy)
        {
            key = copy.key;
            child = copy.child;
            left = copy.left;
            right = copy.right;
            parent = copy.parent;
        }
    }
}
