using System;
using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Mvc.Routes
{
    public class RouteBuilder
    {
        private List<IRoutePart> parts = new List<IRoutePart>();
        private Stack<int> pinning = new Stack<int>();

        public Pinned Pin()
        {
            pinning.Push(parts.Count);
            return new Pinned(this);
        }

        public void Unpin()
        {
            int pin = pinning.Pop();
            while (parts.Count > pin)
            {
                parts.RemoveAt(parts.Count - 1);
            }
        }

        public IRoutePart[] ToArray()
        {
            return parts.ToArray();
        }

        public void Add(IRoutePart part) 
        {
            parts.Add(part);
        }
        
        public class Pinned : IDisposable
        {
            private RouteBuilder builder;
            private bool accepted;
            
            public Pinned(RouteBuilder builder)
            {
                this.builder = builder;
            }

            public void Accept()
            {
                accepted = true;
            }
            
            public void Dispose()
            {
                if (!accepted)
                    builder.Unpin();
            }
        }
    }
}