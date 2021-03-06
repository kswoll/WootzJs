﻿using System;
using System.Linq;
using WootzJs.Mvc.Utils;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class VerticalPanel : Control
    {
        public HorizontalAlignment DefaultAlignment { get; set; }

        private const int AnimationSpeed = 250;

        private Element table;
        private Element firstSpacer;
        private Element lastSpacer;
        private int spacing;

        public VerticalPanel()
        {
            DefaultAlignment = HorizontalAlignment.Fill;
        }

        public VerticalAlignment VerticalAlignment
        {
            get
            {
                if (firstSpacer == null && lastSpacer == null)
                    return VerticalAlignment.Fill;
                else if (firstSpacer != null && lastSpacer != null)
                    return VerticalAlignment.Middle;
                else if (firstSpacer != null)
                    return VerticalAlignment.Bottom;
                else if (lastSpacer != null)
                    return VerticalAlignment.Top;
                else
                    throw new InvalidOperationException();
            }
            set
            {
                EnsureNodeExists();
                if (firstSpacer != null)
                {
                    firstSpacer.Remove();
                    firstSpacer = null;
                }
                if (lastSpacer != null)
                {
                    lastSpacer.Remove();
                    lastSpacer = null;
                }
                switch (value)
                {
                    case VerticalAlignment.Fill:
                        break;
                    case VerticalAlignment.Middle:
                    {
                        firstSpacer = Browser.Document.CreateElement("tr");
                        var firstSpacerCell = Browser.Document.CreateElement("td");
                        firstSpacerCell.Style.Height = "50%";
                        firstSpacer.AppendChild(firstSpacerCell);
                        table.Prepend(firstSpacer);

                        lastSpacer = Browser.Document.CreateElement("tr");
                        var lastSpacerCell = Browser.Document.CreateElement("td");
                        lastSpacerCell.Style.Height = "50%";
                        lastSpacer.AppendChild(lastSpacerCell);
                        table.AppendChild(lastSpacer);

                        break;
                    }
                    case VerticalAlignment.Top:
                    {
                        lastSpacer = Browser.Document.CreateElement("tr");
                        var lastSpacerCell = Browser.Document.CreateElement("td");
                        lastSpacerCell.Style.Height = "100%";
                        lastSpacer.AppendChild(lastSpacerCell);
                        table.AppendChild(lastSpacer);
                        break;
                    }
                   case VerticalAlignment.Bottom:
                    {
                        firstSpacer = Browser.Document.CreateElement("tr");
                        var firstSpacerCell = Browser.Document.CreateElement("td");
                        firstSpacerCell.Style.Height = "100%";
                        firstSpacer.AppendChild(firstSpacerCell);
                        table.AppendChild(firstSpacer);
                        break;
                    }
                    default:
                        throw new InvalidOperationException();
                }                
            }
        }

        public int Spacing
        {
            get { return spacing; }
            set
            {
                EnsureNodeExists();
                var difference = value - spacing;
                spacing = value;

                for (var i = 0; i < table.Children.Length; i++)
                {
                    var row = table.Children[i];
                    var div = row.Children[0];
                    var existingMargin = div.Style.MarginTop;
                    var existingSpacing = existingMargin == "" ? 0 : int.Parse(existingMargin.Substring(0, existingMargin.Length - 2));
                    var newSpacing = existingSpacing + difference;
                    div.Style.MarginTop = newSpacing + "px";
                }
            }
        }

        protected override Element CreateNode()
        {
            table = Browser.Document.CreateElement("table");
            table.Style.Width = "100%";

            var div = Browser.Document.CreateElement("div");
            div.AppendChild(table);

            return div;
        }

        public void Add(Control child, bool animate = false)
        {
            Add(child, DefaultAlignment, 0, animate);
        }

        public void Add(Control child, HorizontalAlignment alignment, bool animate = false)
        {
            Add(child, alignment, 0, animate);
        }

        public void Add(Control child, int spaceAbove, bool animate = false)
        {
            Add(child, DefaultAlignment, spaceAbove, animate);
        }

        public virtual void Add(Control child, HorizontalAlignment alignment, int spaceAbove, bool animate = false)
        {
            EnsureNodeExists();
            table.AppendChild(InternalAdd(child, alignment, spaceAbove, animate));
        }

        private Element InternalAdd(Control child, HorizontalAlignment alignment, int spaceAbove, bool animate = false) 
        {
            if (Count > 0)
                spaceAbove += spacing;

            base.AddChild(child);

            var row = Browser.Document.CreateElement("tr");
            var cell = Browser.Document.CreateElement("td");
            var div = Browser.Document.CreateElement("div");
            cell.AppendChild(div);

            switch (alignment)
            {
                case HorizontalAlignment.Fill:
                    child.Node.Style.Width = "100%";
                    div.Style.Width = "100%";
                    break;
                case HorizontalAlignment.Left:
                    cell.SetAttribute("align", "left");
                    break;
                case HorizontalAlignment.Center:
                    cell.SetAttribute("align", "center");
                    break;
                case HorizontalAlignment.Right:
                    cell.SetAttribute("align", "right");
                    break;
            }
            
            if (spaceAbove != 0)
            {
                div.Style.MarginTop = spaceAbove + "px";   // TODO!?  Shouldn't this be padding?
            }

            div.AppendChild(child.Node);
            row.AppendChild(cell);

            if (animate)
            {
                int height = row.MeasureOffsetHeight();
                row.Style.Display = "none";
                div.Style.Overflow = "hidden";
                Animator.Animate(
                    progress =>
                    {
                        var newHeight = (int)(height * progress);
                        div.Style.Height = newHeight + "px";
                        row.Style.Display = "";
                    },
                    AnimationSpeed,
                    () =>
                    {
                        div.Style.Overflow = "";
                        div.Style.Height = "";
                    });
            }

            return row;
        }

        public void InsertBefore(Control child, Control insertBefore, int spaceAbove = 0, bool animate = false)
        {
            InsertBefore(child, insertBefore, DefaultAlignment, spaceAbove, animate);
        }

        public void InsertBefore(Control child, Control insertBefore, HorizontalAlignment alignment, int spaceAbove = 0, bool animate = false)
        {
            if (insertBefore.Parent != this)
                throw new Exception("Cannot use a reference node that is not contained by this control");

            var div = insertBefore.Node.ParentElement;
            var cell = div.ParentElement;
            var row = cell.ParentElement;
            InternalAdd(child, alignment, spaceAbove, animate).InsertBefore(row);
        }

        public void InsertAfter(Control child, Control insertAfter, HorizontalAlignment alignment, int spaceAbove = 0)
        {
            if (insertAfter.Parent != this)
                throw new Exception("Cannot use a reference node that is not contained by this control");

            var div = insertAfter.Node.ParentElement;
            var cell = div.ParentElement;
            var row = cell.ParentElement;
            InternalAdd(child, alignment, spaceAbove).InsertAfter(row);
        }

        public void Replace(Control oldChild, Control newChild)
        {
            if (oldChild.Parent != this) 
                throw new Exception("Cannot replace out a child that is not contained by this control");

            oldChild.Node.ParentElement.ReplaceChild(newChild.Node, oldChild.Node);
            RemoveChild(oldChild);
            AddChild(newChild);
        }

        public void Remove(Control child, bool animate = false)
        {
            var div = child.Node.ParentElement;
            var cell = div.ParentElement;
            var row = cell.ParentElement;

            if (animate)
            {
                int height = row.MeasureOffsetHeight();
                div.Style.Overflow = "hidden";
                Animator.Animate(
                    progress =>
                    {
                        var newHeight = (int)(height * (1 - progress));
                        div.Style.Height = newHeight + "px";
                    },
                    AnimationSpeed,
                    () =>
                    {
                        div.Style.Overflow = "";
                        div.Style.Height = "";
                        div.RemoveChild(child.Node);
                        table.RemoveChild(row);
 	                    base.RemoveChild(child);
                    });
            }
            else
            {
                div.RemoveChild(child.Node);
                table.RemoveChild(row);                
     	        base.RemoveChild(child);
            }
        }

        protected override void RemoveChild(Control child)
        {
            Remove(child);
        }

        public new void RemoveAll()
        {
            base.RemoveAll();
        }
    }
}