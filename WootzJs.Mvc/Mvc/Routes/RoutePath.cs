using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WootzJs.Mvc.Mvc.Routes
{
    public class RoutePath
    {
        private Stack<string> remaining = new Stack<string>();
        private Stack<string> consumed = new Stack<string>();
        private Stack<int> pinning = new Stack<int>();

        public RoutePath(string path)
        {
            path = path.ChopStart("/");
            if (path != "")
            {
                var parts = path.Split('/');
                foreach (var part in parts.Reverse())
                {
                    remaining.Push(part);
                }                
            }
        }

        public IDisposable Pin()
        {
            pinning.Push(Location);
            return new Pinned(this);
        }

        public void Unpin()
        {
            Reset(pinning.Pop());
        }

        public int Location
        {
            get { return consumed.Count; }
        }

        private void Reset(int location)
        {
            if (location > consumed.Count)
            {
                throw new InvalidOperationException("Illegal location " + location + ", only " + consumed.Count + " items in the back stack.");
            }
            while (consumed.Count > location)
            {
                Back();
            }
        }

        public bool Any()
        {
            return remaining.Any();
        }

        public int Remaining 
        {
            get { return remaining.Count; }
        }

        public bool StartsWith(RoutePath routePath)
        {
            if (routePath.remaining.Count > remaining.Count)
                return false;
            if (remaining.Take(routePath.remaining.Count).SequenceEqual(routePath.remaining))
                return true;
            return false;
        }

        public string Current
        {
            get
            {
                return remaining.Any() ? remaining.Peek() : null;
            }
        }

        public string Consume()
        {
            var part = remaining.Pop();
            consumed.Push(part);
            return part;
        }

        public string ConsumeAll() 
        {
            var builder = new StringBuilder();
            while (Any())
            {
                if (builder.Length > 0)
                    builder.Append("/");
                builder.Append(Consume());
            }
            return builder.ToString();
        }

        public void Consume(RoutePath path)
        {
            for (var i = 0; i < path.remaining.Count; i++)
                Consume();
        }

        public string Back()
        {
            var part = consumed.Pop();
            remaining.Push(part);
            return part;
        }

        public void Reset()
        {
            while (consumed.Any())
            {
                var part = consumed.Pop();
                remaining.Push(part);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (consumed.Any())
            {
                builder.Append(string.Join("/", consumed.Reverse()));
            }

            if (remaining.Any())
            {
                builder.Append("/*" + remaining.Peek() + "*");

                if (remaining.Count > 1)
                {
                    builder.Append("/");
                    builder.Append(string.Join("/", remaining.Skip(1)));
                }
            }

            return builder.ToString();
        }

        private class Pinned : IDisposable
        {
            private RoutePath path;

            public Pinned(RoutePath path)
            {
                this.path = path;
            }

            public void Dispose()
            {
                path.Unpin();
            }
        }
    }
}