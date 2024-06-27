internal class Program
{
    // Jack and his trip plan
    private static void Main(string[] args)
    {
        var s = new Solution();

        int[] a = { 0, 0, 0, 1, 6, 1, 0, 0 };
        var result = s.solution(a);
        Console.WriteLine(result);

        int[] b = { 0, 9, 0, 2, 6, 8, 0, 8, 3, 0 };
        result = s.solution(b);
        Console.WriteLine(result);
    }

    class Solution
    {
        public int solution(int[] a)
        {
            Node root = new Node { Value = a[0] };

            // making tree
            AddNextNode(a, root);

            int maxCount = 0;
            for (int i = 0; i < root.Children.Count; i++)
            {
                int count = 1; // because he has alredy visited zero node
                FindAndCountNodes(root.Children[i], ref count);
                maxCount = Math.Max(count, maxCount);
            }
            return maxCount;
        }

        void AddNextNode(int[] a, Node parentNode)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == parentNode.Value)
                {
                    Node node = new Node
                    {
                        Value = i,
                        Parent = parentNode,
                    };
                    parentNode.Children.Add(node);
                    AddNextNode(a, node);
                }
            }
        }

        private void FindAndCountNodes(Node parent, ref int count)
        {
            count++;
            if (parent.Value % 2 == 0)
            {
                for (int i = 0; i < parent.Children.Count; i++)
                {
                    int nextCount = count;
                    Node node = parent.Children[i];
                    FindAndCountNodes(node, ref nextCount);
                    count = Math.Max(nextCount, count);
                }
            }
        }

        class Node
        {
            public Node? Parent { get; set; }
            public int Value { get; set; }
            public List<Node> Children { get; set; } = new List<Node>();
        }
    }
}