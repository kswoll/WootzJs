using System.Runtime.WootzJs;
using WootzJs.JQuery;

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

        private jQuery topRow;
        private jQuery bottomRow;
        private jQuery middleRow;
        private jQuery topCell;
        private jQuery bottomCell;
        private jQuery leftCell;
        private jQuery rightCell;
        private jQuery centerCell;

        // The content divs are necessary so that the child cells may freely use padding without breaking the layout.
        private jQuery topCellContent;
        private jQuery bottomCellContent;
        private jQuery leftCellContent;
        private jQuery rightCellContent;
        private jQuery centerCellContent;

        protected override jQuery CreateNode()
        {
            var table = new jQuery("<table></table>");
            return table;
        }

        private jQuery GetTopRow()
        {
            if (topRow == null)
            {
                topRow = new jQuery("<tr></tr>");
                Node.prepend(topRow);
            }
            return topRow;
        }

        private jQuery GetMiddleRow()
        {
            if (middleRow == null)
            {
                middleRow = new jQuery("<tr></tr>");
                if (topRow != null)
                    middleRow.insertAfter(topRow);
                else
                    Node.prepend(middleRow);
            }
            return middleRow;
        }

        private jQuery GetBottomRow()
        {
            if (bottomRow == null)
            {
                bottomRow = new jQuery("<tr></tr>");
                Node.append(bottomRow);
            }
            return bottomRow;
        }

        private jQuery GetTopCell()
        {
            if (topCell == null)
            {
                topCell = new jQuery("<td></td>");
                topCell.attr("colspan", 3);
                GetTopRow().append(topCell);

                topCellContent = new jQuery("<div></div>");
                topCellContent.css("width", "100%");
                topCellContent.css("height", "100%");
                topCell.append(topCellContent);

                if (Spacing != 0 && (middleRow != null || bottomRow != null))
                {
                    topCellContent.css("padding-bottom", (JsNumber)Spacing);
                }
            }

            return topCellContent;
        }

        private jQuery GetBottomCell()
        {
            if (bottomCell == null)
            {
                bottomCell = new jQuery("<td></td>");
                bottomCell.attr("colspan", 3);
                GetBottomRow().append(bottomCell);

                bottomCellContent = new jQuery("<div></div>");
                bottomCellContent.css("width", "100%");
                bottomCellContent.css("height", "100%");
                bottomCell.append(bottomCellContent);

                if (Spacing != 0 && (middleRow != null))
                {
                    bottomCellContent.css("padding-top", Spacing);
                }
            }
            return bottomCellContent;
        }

        private void AdjustColSpan()
        {
            if (leftCell != null)
                leftCell.attr("colspan", center == null && right == null ? 3 : 1);
            if (centerCell != null)
                centerCell.attr("colspan", left != null && right != null ? 1 : left != null || right != null ? 2 : 3);
            if (rightCell != null)
                rightCell.attr("colspan", center == null && left == null ? 3 : 1);
        }

        private jQuery GetLeftCell()
        {
            if (leftCell == null)
            {
                leftCell = new jQuery("<td></td>");
                leftCell.css("height", "100%");
                AdjustColSpan();
                GetMiddleRow().prepend(leftCell);

                leftCellContent = new jQuery("<div></div>");
                leftCellContent.css("width", "100%");
                leftCellContent.css("height", "100%");
                leftCell.append(leftCellContent);

                if (Spacing != 0 && (centerCell != null || rightCell != null))
                {
                    leftCellContent.css("padding-left", Spacing);
                }
            }
            return leftCellContent;
        }

        private jQuery GetCenterCell()
        {
            if (centerCell == null)
            {
                centerCell = new jQuery("<td></td>");
                centerCell.css("height", "100%");
                centerCell.css("width", "100%");
                AdjustColSpan();
                if (leftCell != null)
                    centerCell.insertAfter(leftCell);
                else
                    GetMiddleRow().prepend(centerCell);

                centerCellContent = new jQuery("<div></div>");
                centerCellContent.css("width", "100%");
                centerCellContent.css("height", "100%");
                centerCell.append(centerCellContent);
            }
            return centerCellContent;
        }

        private jQuery GetRightCell()
        {
            if (rightCell == null)
            {
                rightCell = new jQuery("<td></td>");
                rightCell.css("height", "100%");
                AdjustColSpan();
                GetMiddleRow().append(rightCell);

                rightCellContent = new jQuery("<div></div>");
                rightCellContent.css("width", "100%");
                rightCellContent.css("height", "100%");
                rightCell.append(rightCellContent);

                if (Spacing != 0 && middleRow != null)
                {
                    rightCellContent.css("padding-left", Spacing);
                }
            }
            return rightCellContent;
        }

        private void RemoveTopRow()
        {
            if (topRow != null)
                topRow.remove();
            topRow = null;
        }

        private void RemoveMiddleRow()
        {
            if (middleRow != null)
            {
                middleRow.remove();
                if (topCell != null && bottom == null)
                    topCell.css("padding-bottom", "");
            }
            middleRow = null;
        }

        private void RemoveBottomRow()
        {
            if (bottomRow != null)
                bottomRow.remove();
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
                topCell.remove();
            topCell = null;
            topCellContent = null;
            RemoveTopRow();
        }

        private void RemoveBottomCell()
        {
            if (bottomCell != null)
                bottomCell.remove();
            bottomCell = null;
            bottomCellContent = null;
            RemoveBottomRow();
        }

        private void RemoveLeftCell()
        {
            if (leftCell != null)
                leftCell.remove();
            leftCell = null;
            leftCellContent = null;
            RemoveMiddleRowIfEmpty();
        }

        private void RemoveCenterCell()
        {
            if (centerCell != null)
            {
                centerCell.remove();
                if (leftCell != null && right == null)
                    leftCell.css("padding-right", "");
            }
            centerCell = null;
            centerCellContent = null;
            RemoveMiddleRowIfEmpty();
        }

        private void RemoveRightCell()
        {
            if (rightCell != null)
                rightCell.remove();
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
                    Add(top);
                    GetTopCell().append(value.Node);
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
                    Add(bottom);
                    GetBottomCell().append(value.Node);
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
                    Add(left);
                    GetLeftCell().append(value.Node);
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
                    Add(center);
                    GetCenterCell().append(value.Node);
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
                    Add(right);
                    GetRightCell().append(value.Node);
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
                    GetTopCell().css("padding-bottom", value);
                }
                if (Left != null && (Center != null || Right != null))
                {
                    GetLeftCell().css("padding-right", value);
                }
                if (Right != null && Center != null)
                {
                    GetRightCell().css("padding-left", value);
                }
                if (Bottom != null && (Left != null || Center != null || Right != null))
                {
                    GetBottomCell().css("padding-top", value);
                }
            }
        }
    }
}