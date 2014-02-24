using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class JsPosition
    {
        public int StartLine { get; set; } 
        public int EndLine { get; set; }
        public int StartLinePosition { get; set; }
        public int EndLinePosition { get; set; }
        public SyntaxNode OriginalNode { get; set; }

        public JsPosition(int startLine, int endLine, int startLinePosition, int endLinePosition, SyntaxNode originalNode)
        {
            StartLine = startLine;
            EndLine = endLine;
            StartLinePosition = startLinePosition;
            EndLinePosition = endLinePosition;
            OriginalNode = originalNode;
        }
    }
}