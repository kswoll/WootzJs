using System;
using System.Linq;
using System.Text;

namespace WootzJs.Compiler
{
    public class IndentStringBuilder 
    {
        private readonly string indent;

        private string currentIndent = "";
        private int currentIndentLevel;
        private StringBuilder builder = new StringBuilder();
        private StringBuilder currentLine = new StringBuilder();
        private bool isCompacting;

        public IndentStringBuilder(int indentSize = 4)
        {
            indent = new string(' ', indentSize);
        }

        public string CurrentIndent
        {
            get { return currentIndent; }
        }

        public bool IsCompacting
        {
            get { return isCompacting; }
            set { isCompacting = value; }
        }

        public int CurrentIndentLevel
        {
            get
            {
                return currentIndentLevel;
            }
            set
            {
                if (currentIndentLevel < 0)
                    throw new InvalidOperationException("Cannot set indent to less than zero");

                currentIndentLevel = value;
                currentIndent = string.Join("", Enumerable.Repeat(indent, currentIndentLevel));
            }
        }

        public void AppendIndent()
        {
            currentLine.Append(currentIndent);
        }

        public void Append(object o)
        {
            if (currentLine.Length == 0 && currentIndent.Length > 0 && !IsCompacting)
                currentLine.Append(currentIndent);

            var s = o == null ? "null" : o.ToString();
            var lines = s.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).AsEnumerable();
            if (lines.Any())
            {
                var first = lines.First();
                currentLine.Append(first);

                lines = lines.Skip(1).ToArray();
                if (lines.Any())
                {
                    CommitCurrentLine();
                    var last = lines.Last();
                    var length = lines.Count();
                    lines = lines.Take(length - 1);
                    
                    foreach (var line in lines)
                    {
                        builder.AppendLine(line);
                    }

                    currentLine.Append(last);
                }
            }
        }

        public void AppendLine(object o)
        {
            Append(o);
            CommitCurrentLine();
        }

        public void AppendLine()
        {
            CommitCurrentLine();
        }

        public void CommitCurrentLineIfPending()
        {
            if (currentLine.Length > 0)
            {
                CommitCurrentLine();
            }
        }

        private void CommitCurrentLine()
        {
            builder.Append(currentLine);
            if (!IsCompacting)
                builder.AppendLine();
            currentLine.Length = 0;
        }

        public override string ToString()
        {
            return builder + (currentLine.Length > 0 ? Environment.NewLine + currentLine : "");
        }
    }
}
