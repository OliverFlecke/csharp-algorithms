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

        public bool IsLeftChild => this == Parent?.Left;
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
        if (this.Root is null)
        {
            this.Root = new Node(value)
            {
                Color = Color.Black,
            };
        }
        else
        {
            var node = Root;
            while (true)
            {
                var comparision = value.CompareTo(node.Value);
                if (comparision < 0)
                {
                    if (node.Left is null)
                    {
                        node.Left = new Node(value, node);
                        node = node.Left;
                        break;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else if (comparision > 0)
                {
                    if (node.Right is null)
                    {
                        node.Right = new Node(value, node);
                        node = node.Right;
                        break;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
                else return;
            }

            RecolorAndRotate(node);
        }

        void RecolorAndRotate(Node? node)
        {
            if (node == this.Root)
            {
                node.Color = Color.Black;
                return;
            }
            if (node is null) return;
            if (node.Parent?.Color == Color.Black) return;

            var uncle = GetUncle(node);
            if (uncle is not null && Color.Red == uncle.Color)
            {
                uncle.Color = Color.Black;
                node.Parent!.Color = Color.Black;

                if (node.Parent?.Parent is Node grandparent && grandparent != this.Root)
                {
                    grandparent.Color = Color.Red;
                    RecolorAndRotate(grandparent);
                }
            }
            else if (uncle is null || Color.Black == uncle.Color)
            {
                if (node.Parent is Node p && p.Parent is Node g)
                {
                    if (node.IsLeftChild && p.IsLeftChild)
                    {
                        LeftLeftRotate(g, p);
                        if (g == Root) Root = p;
                    }
                    else if (!node.IsLeftChild && !p.IsLeftChild)
                    {
                        RightRightRotate(g, p);
                        if (g == Root) Root = p;
                    }
                    else if (!node.IsLeftChild && p.IsLeftChild)
                    {
                        var tmp = p.Left;
                        p.Right = node.Right;
                        p.Left = node.Left;
                        node.Right = tmp;
                        node.Left = p;

                        g.Left = node;
                        node.Parent = g;

                        LeftLeftRotate(g, node);
                        if (g == Root) Root = node;
                    }
                    else if (node.IsLeftChild && !p.IsLeftChild)
                    {
                        p.Left = node.Right;
                        node.Right = p;
                        g.Right = node;

                        RightRightRotate(g, node);
                        if (g == Root) Root = node;
                    }
                }
            }
        }

        Node? GetUncle(Node node)
        {
            if (node.Parent is null) return null;
            if (node.Parent.Parent is null) return null;

            if (node.Parent.Parent.Left?.Value.CompareTo(node.Parent.Value) == 0)
                return node.Parent.Parent.Right;
            else
                return node.Parent.Parent.Left;
        }

        static void SwapColors(Node a, Node b)
        {
            var tmp = a.Color;
            a.Color = b.Color;
            b.Color = tmp;
        }

        static void RightRightRotate(Node g, Node p)
        {
            p.Parent = g.Parent;
            g.Parent = p;
            g.Right = p.Left;
            p.Left = g;
            SwapColors(p, g);
        }

        static void LeftLeftRotate(Node g, Node p)
        {
            p.Parent = g.Parent;
            g.Parent = p;
            g.Left = p.Right;
            p.Right = g;
            SwapColors(p, g);
        }
    }

    public Node? Search(T value)
    {
        Node? Search(Node? node)
        {
            if (node is null)
            {
                return null;
            }
            else
            {
                return node.Value.CompareTo(value) switch
                {
                    0 => node,
                    var x when x > 0 => Search(node.Left),
                    _ => Search(node.Right),
                };
            }
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
