namespace WootzJs.Web
{
    public static class NodeExtensions
    {
        public static void Prepend(this Node node, Node child)
        {
            node.InsertBefore(child, node.FirstChild);
        } 

        public static void InsertBefore(this Node child, Node referenceNode)
        {
            referenceNode.ParentNode.InsertBefore(child, referenceNode);
        }

        public static void InsertAfter(this Node child, Node referenceNode)
        {
            referenceNode.ParentNode.InsertAfter(child, referenceNode);
        }

        public static void InsertAfter(this Node parent, Node child, Node referenceNode)
        {
            var nextReferenceNode = referenceNode.NextSibling;
            if (nextReferenceNode == null)
                parent.AppendChild(child);
            else
                parent.InsertBefore(child, nextReferenceNode);
        }

        public static void Remove(this Node node)
        {
            node.ParentNode.RemoveChild(node);
        }

        public static void Clear(this Node node)
        {
            for (var i = node.ChildNodes.Length - 1; i >= 0; i--)
            {
                var child = node.ChildNodes[i];
                child.Remove();
            }
        }
    }
}