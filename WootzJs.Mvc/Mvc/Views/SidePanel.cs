using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
{
    public class SidePanel : Control
    {
        private Control top;
        private Control bottom;
        private Control left;
        private Control right;
        private Control center;
        private int spacing;

        private Element topRow;
        private Element bottomRow;
        private Element middleRow;
        private Element topCell;
        private Element bottomCell;
        private Element leftCell;
        private Element rightCell;
        private Element centerCell;

        // The content divs are necessary so that the child cells may freely use padding without breaking the layout.
        private Element topCellContent;
        private Element bottomCellContent;
        private Element leftCellContent;
        private Element rightCellContent;
        private Element centerCellContent;

        protected override Element CreateNode()
        {
            var table = Browser.Document.CreateElement("table");
            return table;
        }

        private Element GetTopRow()
        {
            if (topRow == null)
            {
                topRow = Browser.Document.CreateElement("tr");
                Node.Prepend(topRow);
            }
            return topRow;
        }

        private Element GetMiddleRow()
        {
            if (middleRow == null)
            {
                middleRow = Browser.Document.CreateElement("tr");
                if (topRow != null)
                    middleRow.InsertAfter(topRow);
                else
                    Node.Prepend(middleRow);

                if (Spacing != 0 && topRow != null)
                {
                    topCellContent.Style.PaddingBottom = Spacing + "px";
                }
            }
            return middleRow;
        }

        private Element GetBottomRow()
        {
            if (bottomRow == null)
            {
                bottomRow = Browser.Document.CreateElement("tr");
                Node.AppendChild(bottomRow);
            }
            return bottomRow;
        }

        private Element GetTopCell()
        {
            if (topCell == null)
            {
                topCell = Browser.Document.CreateElement("td");
                topCell.SetAttribute("colspan", "3");
                GetTopRow().AppendChild(topCell);

                topCellContent = Browser.Document.CreateElement("div");
                topCellContent.Style.Width = "100%";
                topCellContent.Style.Height = "100%";
                topCell.AppendChild(topCellContent);

                if (Spacing != 0 && (middleRow != null || bottomRow != null))
                {
                    topCellContent.Style.PaddingBottom = Spacing + "px";
                }
            }

            return topCellContent;
        }

        private Element GetBottomCell()
        {
            if (bottomCell == null)
            {
                bottomCell = Browser.Document.CreateElement("td");
                bottomCell.SetAttribute("colspan", "3");
                GetBottomRow().AppendChild(bottomCell);

                bottomCellContent = Browser.Document.CreateElement("div");
                bottomCellContent.Style.Width = "100%";
                bottomCellContent.Style.Height = "100%";
                bottomCell.AppendChild(bottomCellContent);

                if (Spacing != 0 && (middleRow != null))
                {
                    bottomCellContent.Style.PaddingTop = Spacing + "px";
                }
            }
            return bottomCellContent;
        }

        private void AdjustColSpan()
        {
            if (leftCell != null)
                leftCell.SetAttribute("colspan", center == null && right == null ? "3" : "1");
            if (centerCell != null)
                centerCell.SetAttribute("colspan", left != null && right != null ? "1" : left != null || right != null ? "2" : "3");
            if (rightCell != null)
                rightCell.SetAttribute("colspan", center == null && left == null ? "3" : "1");
        }

        private Element GetLeftCell()
        {
            if (leftCell == null)
            {
                leftCell = Browser.Document.CreateElement("td");
                leftCell.Style.Height = "100%";
                AdjustColSpan();
                GetMiddleRow().Prepend(leftCell);

                leftCellContent = Browser.Document.CreateElement("div");
                leftCellContent.Style.Width = "100%";
                leftCellContent.Style.Height = "100%";
                leftCell.AppendChild(leftCellContent);

                if (Spacing != 0 && (centerCell != null || rightCell != null))
                {
                    leftCellContent.Style.PaddingLeft = Spacing + "px";
                }
            }
            return leftCellContent;
        }

        private Element GetCenterCell()
        {
            if (centerCell == null)
            {
                centerCell = Browser.Document.CreateElement("td");
                centerCell.Style.Height = "100%";
                centerCell.Style.Width = "100%";
                AdjustColSpan();
                if (leftCell != null)
                    centerCell.InsertAfter(leftCell);
                else
                    GetMiddleRow().Prepend(centerCell);

                centerCellContent = Browser.Document.CreateElement("div");
                centerCellContent.Style.Width = "100%";
                centerCellContent.Style.Height = "100%";
                centerCell.AppendChild(centerCellContent);
            }
            return centerCellContent;
        }

        private Element GetRightCell()
        {
            if (rightCell == null)
            {
                rightCell = Browser.Document.CreateElement("td");
                rightCell.Style.Height = "100%";
                AdjustColSpan();
                GetMiddleRow().AppendChild(rightCell);

                rightCellContent = Browser.Document.CreateElement("div");
                rightCellContent.Style.Width = "100%";
                rightCellContent.Style.Height = "100%";
                rightCell.AppendChild(rightCellContent);

                if (Spacing != 0 && middleRow != null)
                {
                    rightCellContent.Style.PaddingLeft = Spacing + "px";
                }
            }
            return rightCellContent;
        }

        private void RemoveTopRow()
        {
            if (topRow != null)
                topRow.Remove();
            topRow = null;
        }

        private void RemoveMiddleRow()
        {
            if (middleRow != null)
            {
                middleRow.Remove();
                if (topCell != null && bottom == null)
                    topCell.Style.PaddingBottom = "";
            }
            middleRow = null;
        }

        private void RemoveBottomRow()
        {
            if (bottomRow != null)
                bottomRow.Remove();
            bottomRow = null;
        }

        private void RemoveMiddleRowIfEmpty()
        {
            if (leftCell == null && centerCell == null && rightCell == null)
                RemoveMiddleRow();
        }

        private void RemoveTopCell()
        {
            if (topCell != null)
                topCell.Remove();
            topCell = null;
            topCellContent = null;
            RemoveTopRow();
        }

        private void RemoveBottomCell()
        {
            if (bottomCell != null)
                bottomCell.Remove();
            bottomCell = null;
            bottomCellContent = null;
            RemoveBottomRow();
        }

        private void RemoveLeftCell()
        {
            if (leftCell != null)
                leftCell.Remove();
            leftCell = null;
            leftCellContent = null;
            RemoveMiddleRowIfEmpty();
        }

        private void RemoveCenterCell()
        {
            if (centerCell != null)
            {
                centerCell.Remove();
                if (leftCell != null && right == null)
                    leftCell.Style.PaddingRight = "";
            }
            centerCell = null;
            centerCellContent = null;
            RemoveMiddleRowIfEmpty();
        }

        private void RemoveRightCell()
        {
            if (rightCell != null)
                rightCell.Remove();
            rightCell = null;
            rightCellContent = null;
            RemoveMiddleRowIfEmpty();
        }

        public Control Top
        {
            get { return top; }
            set
            {
                if (top != null)
                {
                    Remove(top);
                    RemoveTopCell();
                }
                top = value;
                if (top != null)
                {
                    GetTopCell().AppendChild(value.Node);
                    Add(top);
                }
            }
        }

        public Control Bottom
        {
            get { return bottom; }
            set
            {
                if (bottom != null)
                {
                    Remove(bottom);
                    RemoveBottomCell();
                }
                bottom = value;
                if (bottom != null)
                {
                    GetBottomCell().AppendChild(value.Node);
                    Add(bottom);
                }
            }
        }

        public Control Left
        {
            get { return left; }
            set
            {
                if (left != null)
                {
                    Remove(left);
                    RemoveLeftCell();
                }
                left = value;
                if (left != null)
                {
                    GetLeftCell().AppendChild(value.Node);
                    Add(left);
                }
            }
        }

        public Control Center
        {
            get { return center; }
            set
            {
                if (center != null)
                {
                    Remove(center);
                    RemoveCenterCell();
                }
                center = value;
                if (center != null)
                {
                    GetCenterCell().AppendChild(value.Node);
                    Add(center);
                }
            }
        }

        public Control Right
        {
            get { return right; }
            set
            {
                if (right != null)
                {
                    Remove(right);
                    RemoveRightCell();
                }
                right = value;
                if (right != null)
                {
                    GetRightCell().AppendChild(value.Node);
                    Add(right);
                }
            }
        }

        public int Spacing
        {
            get { return spacing; }
            set
            {
                spacing = value;
                if (Top != null && (Left != null || Center != null || Right != null || Bottom != null))
                {
                    GetTopCell().Style.PaddingBottom = value + "px";
                }
                if (Left != null && (Center != null || Right != null))
                {
                    GetLeftCell().Style.PaddingRight = value + "px";
                }
                if (Right != null && Center != null)
                {
                    GetRightCell().Style.PaddingLeft = value + "px";
                }
                if (Bottom != null && (Left != null || Center != null || Right != null))
                {
                    GetBottomCell().Style.PaddingTop = value + "px";
                }
            }
        }
    }
}