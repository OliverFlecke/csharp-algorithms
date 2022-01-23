using System.Text;
namespace Algorithms;

public class RedBlackTree<T> where T : IComparable<T>
{
    public enum Color { Red, Black, }

    public class Node
    {
        RedBlackTree<T>.Node? left;
        RedBlackTree<T>.Node? right;

        public Node(T value, Node? parent = null, Color color = Color.Red)
        {
            this.Parent = parent;
            this.Value = value;
            this.Color = color;
        }

        internal Color Color { get; set; }

        public T Value { get; init; }

        public Node? Parent { get; set; }
        public Node? Left
        {
            get => left;
            set
            {
                left = value;
                if (value is not null)
                {
                    value.Parent = this;
                }
            }
        }
        public Node? Right
        {
            get => right;
            set
            {
                right = value;
                if (value is not null)
                {
                    value.Parent = this;
                }
            }
        }

        public override string ToString() =>
            $"{(Color == Color.Black ? "B" : "R")} {Value}";

        public static bool operator ==(Node? a, Node? b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Value.CompareTo(b.Value) == 0;
        }

        public static bool operator !=(Node? a, Node? b) => !(a == b);

        public static bool operator <(Node a, Node b) => a.Value.CompareTo(b.Value) < 0;
        public static bool operator >(Node a, Node b) => a.Value.CompareTo(b.Value) > 0;

        public bool IsLeftChild => this == Parent?.Left;

        public bool IsRightChild => this == Parent?.Right;
    }


    internal Node? Root { get; private set; }

    public static RedBlackTree<T> Build(Node root)
    {
        static void SetParents(Node root)
        {
            if (root.Left is Node left)
            {
                left.Parent = root;
                SetParents(left);
            }
            if (root.Right is Node right)
            {
                right.Parent = root;
                SetParents(right);
            }
        }

        SetParents(root);
        return new RedBlackTree<T>() { Root = root, };
    }

    public void Insert(T value)
    {
        Node? y = null;
        var temp = Root;
        var z = new Node(value);

        while (temp is not null)
        {
            y = temp;

            if (z < temp) temp = temp.Left;
            else if (z > temp) temp = temp.Right;
            else return; // Don't insert duplicates
        }

        if (y is null) Root = z;
        else if (z < y) y.Left = z;
        else y.Right = z;

        Fixup(z);

        void Fixup(Node? z)
        {
            while (z is not null && z.Parent?.Color == Color.Red)
            {
                if (z.Parent.IsLeftChild)
                {
                    var y = z.Parent?.Parent?.Right;

                    if (y?.Color == Color.Red)
                    {
                        if (z.Parent is not null) z.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        if (z.Parent?.Parent is not null) z.Parent.Parent.Color = Color.Red;
                        z = z?.Parent?.Parent;
                    }
                    else
                    {
                        if (z.IsRightChild)
                        {
                            z = z.Parent;
                            if (z is not null) LeftRotate(z);
                        }

                        if (z?.Parent is not null) z.Parent.Color = Color.Black;
                        if (z?.Parent?.Parent is not null)
                        {
                            z.Parent.Parent.Color = Color.Red;
                            RightRotate(z.Parent.Parent);
                        }
                    }
                }
                else
                {
                    var y = z.Parent?.Parent?.Left;

                    if (y?.Color == Color.Red)
                    {
                        if (z.Parent is not null) z.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        if (z.Parent?.Parent is not null)
                        {
                            z.Parent.Parent.Color = Color.Red;
                            z = z.Parent.Parent;
                        }
                    }
                    else
                    {
                        if (z.IsLeftChild)
                        {
                            z = z.Parent;
                            if (z is not null) RightRotate(z);
                        }

                        if (z?.Parent is not null) z.Parent.Color = Color.Black;
                        if (z?.Parent?.Parent is not null)
                        {
                            z.Parent.Parent.Color = Color.Red;
                            LeftRotate(z.Parent.Parent);
                        }
                    }
                }
            }

            if (Root is not null)
                Root.Color = Color.Black;
        }

        void LeftRotate(Node x)
        {
            var y = x.Right;
            x.Right = y?.Left;

            if (y is not null) y.Parent = x.Parent;

            if (x.Parent is null) Root = y;
            else if (x.IsLeftChild) x.Parent.Left = y;
            else x.Parent.Right = y;

            if (y is not null) y.Left = x;
            x.Parent = y;
        }

        void RightRotate(Node x)
        {
            var y = x.Left;
            x.Left = y?.Right;

            if (y is not null) y.Parent = x.Parent;
            if (x.Parent is null) Root = y;
            else if (!x.IsLeftChild) x.Parent.Right = y;
            else x.Parent.Left = y;

            if (y is not null) y.Right = x;
            x.Parent = y;
        }
    }

    public Node? Search(T value)
    {
        Node? Search(Node? node)
        {
            if (node is null) return null;
            else return node.Value.CompareTo(value) switch
                {
                    0 => node,
                    var x when x > 0 => Search(node.Left),
                    _ => Search(node.Right),
                };
        }

        return Search(this.Root);
    }

    public int Height()
    {
        static int Helper(Node? node)
        {
            if (node is null) return 0;

            return 1 + Math.Max(Helper(node.Left), Helper(node.Right));
        }

        return Helper(Root);
    }

    public int Count()
    {
        static int Helper(Node? node)
        {
            if (node is null) return 0;

            return 1 + Helper(node.Left) + Helper(node.Right);
        }

        return Helper(Root);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        void AddNode(Node? node, int depth = 0)
        {
            if (node is null)
            {
                builder.AppendLine("LEAF".PadLeft(5 + depth * 2));
                return;
            }

            builder.AppendLine(node.ToString().PadLeft(5 + depth * 2));
            AddNode(node.Left, depth + 1);
            AddNode(node.Right, depth + 1);
        }

        AddNode(Root);

        return builder.ToString();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is not RedBlackTree<T> other) return false;

        return Compare(Root, other.Root);

        static bool Compare(Node? a, Node? b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a == b && a.Color == b.Color
                && Compare(a?.Left, b?.Left)
                && Compare(a?.Right, b?.Right);
        }
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
