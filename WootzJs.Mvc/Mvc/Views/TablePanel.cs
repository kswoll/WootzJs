using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class TablePanel : Control
    {
        private TableWidth[] columnWidths;
        private List<jQuery> rows = new List<jQuery>();
        private List<Control[]> cells = new List<Control[]>();
        private TableConstraint defaultConstraint = new TableConstraint();

        public TablePanel(params TableWidth[] columnWidths)
        {
            this.columnWidths = columnWidths;
        }

        public int CellSpacing
        {
            get; set;
        }

        protected override jQuery CreateNode()
        {
            var table = new jQuery("<table></table>");

            var totalNumberOfWeights = columnWidths.Where(x => x.Style == TableWidthStyle.Weight).Sum(x => x.Value);
            var totalPercent = columnWidths.Where(x => x.Style == TableWidthStyle.Percent).Sum(x => x.Value);
            var percentAvailableToWeights = 100 - totalPercent;
            if (percentAvailableToWeights < 0)
                throw new InvalidOperationException("Total amount of percent specified is greater than 100");

            var percentToEachWeight = percentAvailableToWeights / totalNumberOfWeights;
            var extraPercent = percentAvailableToWeights - percentToEachWeight*totalNumberOfWeights;

            // Define columns
            var colgroup = new jQuery("<colgroup></colgroup>");
            foreach (var width in columnWidths)
            {
                var col = new jQuery("<col></col>");
                switch (width.Style)
                {
                    case TableWidthStyle.Pixels:
                        col.css("width", width.Value + "px");
                        break;
                    case TableWidthStyle.Weight:
                        var currentWeight = percentToEachWeight * width.Value;
                        currentWeight += extraPercent;
                        extraPercent = 0;
                        col.css("width", currentWeight + "%");
                        break;
                    case TableWidthStyle.Percent:
                        col.css("width", width.Value + "%");
                        break;
                }
                colgroup.append(col);
            }
            table.append(colgroup);

            return table;
        }

        private Point GetNextEmptyCell()
        {
            var x = 0;
            var y = 0;
            foreach (var row in cells)
            {
                foreach (var cell in row)
                {
                    if (cell == null)
                        return new Point(x, y);
                    x++;
                }
                x = 0;
                y++;
            }
            return new Point(x, y);
        }

        public new void Add(Control cell)
        {
            Add(cell, null);
        }

        public void Add(Control cell, TableConstraint constraint)
        {
            base.Add(cell);

            var nextEmptyCell = GetNextEmptyCell();
            constraint = constraint ?? defaultConstraint;
            if (nextEmptyCell.X + constraint.ColumnSpan > columnWidths.Length)
                throw new InvalidOperationException(string.Format("Added a cell at position ({0},{1}), but the column ({2}) exceeds teh available remaining space in the row ({3}).", nextEmptyCell.X, nextEmptyCell.Y, constraint.ColumnSpan, columnWidths.Length - nextEmptyCell.X));

            var jsCell = new jQuery("<td></td>");
            if (constraint.ColumnSpan != 1)
                jsCell.attr("colspan", constraint.ColumnSpan);                        
            if (constraint.RowSpan != 1)
                jsCell.attr("rowspan", constraint.RowSpan);
            var jsCellDiv = new jQuery("<div></div>");
            jsCell.append(jsCellDiv);
            switch (constraint.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    jsCell.attr("align", "left");
                    break;
                case HorizontalAlignment.Center:
                    jsCell.attr("align", "center");
                    break;
                case HorizontalAlignment.Right:
                    jsCell.attr("align", "right");
                    break;
                case HorizontalAlignment.Fill:
                    jsCellDiv.css("width", "100%");
                    cell.Node.css("width", "100%");
                    break;
            }
            switch (constraint.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    jsCell.css("vertical-align", "top");
                    break;
                case VerticalAlignment.Middle:
                    jsCell.css("vertical-align", "middle");
                    break;
                case VerticalAlignment.Bottom:
                    jsCell.css("vertical-align", "bottom");
                    break;
                case VerticalAlignment.Fill:
                    cell.Node.css("height", "100%");
                    jsCellDiv.css("height", "100%");
                    break;
            }
            jsCellDiv.append(cell.Node);
                        
            for (var row = nextEmptyCell.Y; row < nextEmptyCell.Y + constraint.RowSpan; row++)
            {
                for (var col = nextEmptyCell.X; col < nextEmptyCell.X + constraint.ColumnSpan; col++)
                {
                    while (cells.Count <= row)
                    {
                        cells.Add(new Control[columnWidths.Length]);
                        var newRow = new jQuery("<tr></tr>");
                        Node.append(newRow);
                        rows.Add(newRow);
                    }
                    if (cells[row][col] != null)
                        throw new InvalidOperationException("Illegal layout: cannot add a view at row " + row + ", column " + col + " as another view is already present: " + cells[row][col]);
                    cells[row][col] = cell;
                }
            }

            var jsRow = rows[nextEmptyCell.Y];
            jsRow.append(jsCell);
        }

        class Point
        {
            internal int X;
            internal int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    public class TableConstraint
    {
        public HorizontalAlignment HorizontalAlignment { get; private set; }
        public VerticalAlignment VerticalAlignment { get; private set; }
        public int ColumnSpan { get; private set; }
        public int RowSpan { get; private set; }

        public TableConstraint(
            HorizontalAlignment horizontalAlignment = HorizontalAlignment.Fill, 
            VerticalAlignment verticalAlignment = VerticalAlignment.Fill, 
            int columnSpan = 1, 
            int rowSpan = 1)
        {
            HorizontalAlignment = horizontalAlignment;
            VerticalAlignment = verticalAlignment;
            ColumnSpan = columnSpan;
            RowSpan = rowSpan;
        }

        public static TableConstraint Alignment(HorizontalAlignment alignment)
        {
            return new TableConstraint(horizontalAlignment: alignment);
        }

        public static TableConstraint Alignment(VerticalAlignment alignment)
        {
            return new TableConstraint(verticalAlignment: alignment);
        }

        public static TableConstraint SpanCols(int span)
        {
            return new TableConstraint(columnSpan: span);
        }

        public static TableConstraint SpanRows(int span)
        {
            return new TableConstraint(rowSpan: span);
        }

        public static TableConstraint Centered()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Center, verticalAlignment: VerticalAlignment.Middle);
        }

        public static TableConstraint Left()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Left, verticalAlignment: VerticalAlignment.Middle);
        }

        public static TableConstraint Right()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Right, verticalAlignment: VerticalAlignment.Middle);
        }
    }

    public class TableWidth
    {
        public TableWidthStyle Style { get; private set; }
        public int Value { get; private set; }

        public TableWidth(TableWidthStyle style, int value)
        {
            Style = style;
            Value = value;
        }

        public static TableWidth Percent(int percent)
        {
            return new TableWidth(TableWidthStyle.Percent, percent);
        }

        public static TableWidth Exact(int pixels)
        {
            return new TableWidth(TableWidthStyle.Pixels, pixels);
        }

        public static TableWidth Weight(int weight = 1)
        {
            return new TableWidth(TableWidthStyle.Weight, weight);
        }

        public static TableWidth Preferred()
        {
            return new TableWidth(TableWidthStyle.MaxPreferredWidth, 0);
        }

        public static TableWidth[] AllPreferred(int numberOfColumns)
        {
            return Enumerable.Repeat(Preferred(), numberOfColumns).ToArray();
        }

        public static TableWidth[] AllWeight(int numberOfColumns)
        {
            return Enumerable.Repeat(Weight(), numberOfColumns).ToArray();
        }
    }

    public enum TableWidthStyle
    {
        Pixels, 
        Percent,
        Weight,
        MaxPreferredWidth
    }
}