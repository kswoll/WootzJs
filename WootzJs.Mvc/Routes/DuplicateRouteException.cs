using System;

namespace WootzJs.Mvc.Routes
{
    public class DuplicateRouteException : Exception
    {
        public IRouteNode ParentNode { get; set; } 
        public IRouteNode DuplicateNode { get; set; } 
        public IRouteNode DuplicatedNode { get; set; }

        public DuplicateRouteException(IRouteNode parentNode, IRouteNode duplicateNode, IRouteNode duplicatedNode)
            : base("Cannot add node " + duplicateNode + " to parent node " + parentNode + ".  Child collides with existing node " + duplicatedNode)
        {
            ParentNode = parentNode;
            DuplicateNode = duplicateNode;
            DuplicatedNode = duplicatedNode;
        }
    }         
}