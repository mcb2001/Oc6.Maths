using System;

namespace Oc6.Maths.Util
{
    public class FibonacciHeap<TKey, TValue>
    {


        private class Node
        {
            public TKey Key { get; }
            public TValue Value { get; }

            private Node Next { get; set; }
            private Node Previous { get; set; }
            private Node Child { get; set; }
            private Node Parent { get; set; }
            private bool Mark { get; set; }
            private int Degree { get; set; }

            public bool IsSingle => this == Next;

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
                Degree = 0;
                Mark = false;
                Parent = null;
                Child = null;
                Previous = this;
                Next = this;
            }

            public void Insert(Node node)
            {
                if (node == null)
                {
                    return;
                }

                Next.Previous = node.Previous;
                node.Previous.Next = Next;
                Next = node;
                node.Previous = this;
            }

            public void Remove()
            {
                Previous.Next = Next;
                Next.Previous = Previous;
                Next = null;
                Previous = null;
            }

            public void AddChild(Node node)
            {
                if (node == null)
                {
                    Child = node;
                }
                else
                {
                    Child.Insert(node);
                }

                node.Parent = this;
                node.Mark = false;

                ++Degree;
            }

            public void RemoveChild(Node node)
            {
                if (node.Parent != this)
                {
                    throw new ArgumentException("Cannot remove child from a node that is not its parent");
                }

                if (node.IsSingle)
                {
                    if (Child != node)
                    {
                        throw new ArgumentException("Cannot remove a node that is not a child");
                    }

                    Child = null;
                }
                else
                {
                    if (Child == node)
                    {
                        Child = node.Next;
                    }

                    node.Remove();
                }

                node.Parent = null;
                node.Mark = false;
                --Degree;
            }
        }
    }
}
