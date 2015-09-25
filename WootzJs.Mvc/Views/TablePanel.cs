using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class TablePanel : Control
    {
        public TableConstraint DefaultConstraint { get; set; }

        private Element table;
        private TableWidth[] columnWidths;
        private List<Element> rows = new List<Element>();
        private List<Control[]> cells = new List<Control[]>();
        private int verticalCellSpacing;
        private int horizontalCellSpacing;

        public TablePanel(params TableWidth[] columnWidths)
        {
            this.columnWidths = columnWidths;
            DefaultConstraint = new TableConstraint();
        }

        public int VerticalCellSpacing
        {
            get { return verticalCellSpacing; }
            set
            {
                verticalCellSpacing = value;
                ResetCellSpacing();
            }
        }

        public int HorizontalCellSpacing
        {
            get { return horizontalCellSpacing; }
            set
            {
                horizontalCellSpacing = value;
                ResetCellSpacing();
            }
        }

        public int CellSpacing
        {
            get {  return HorizontalCellSpacing; }
            set
            {
                verticalCellSpacing = value;
                horizontalCellSpacing = value;
                ResetCellSpacing();
            }
        }

        private void ResetCellSpacing()
        {
            for (var i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                for (var j = 0; j < row.Children.Length; j++)
                {
                    var cell = row.Children[j];
                    var isLastCellInRow = j == row.Children.Length - 1;
                    var isLastRowInTable = i == rows.Count - 1;
                    if (!isLastCellInRow)
                        cell.Style.PaddingRight = horizontalCellSpacing + "px";
                    if (!isLastRowInTable)
                        cell.Style.PaddingBottom = verticalCellSpacing + "px";
                }
            }            
        }

        protected override Element CreateNode()
        {
            table = Browser.Document.CreateElement("table");

            var totalNumberOfWeights = columnWidths.Where(x => x.Style == TableWidthStyle.Weight).Sum(x => x.Value);
            var totalPercent = columnWidths.Where(x => x.Style == TableWidthStyle.Percent).Sum(x => x.Value);
            var percentAvailableToWeights = 100 - totalPercent;
            if (percentAvailableToWeights < 0)
                throw new InvalidOperationException("Total amount of percent specified is greater than 100");

            var percentToEachWeight = percentAvailableToWeights / totalNumberOfWeights;
            var extraPercent = percentAvailableToWeights - percentToEachWeight*totalNumberOfWeights;

            // Define columns
            var colgroup = Browser.Document.CreateElement("colgroup");
            foreach (var width in columnWidths)
            {
                var col = Browser.Document.CreateElement("col");
                switch (width.Style)
                {
                    case TableWidthStyle.Pixels:
                        col.Style.Width = width.Value + "px";
                        break;
                    case TableWidthStyle.Weight:
                        var currentWeight = percentToEachWeight * width.Value;
                        currentWeight += extraPercent;
                        extraPercent = 0;
                        col.Style.Width = currentWeight + "%";
                        break;
                    case TableWidthStyle.Percent:
                        col.Style.Width = width.Value + "%";
                        break;
                }
                colgroup.AppendChild(col);
            }
            table.AppendChild(colgroup);

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

        public Element Add(Control cell)
        {
            return Add(cell, null);
        }

        public Element Add(Control cell, TableConstraint constraint)
        {
            AddChild(cell);

            var nextEmptyCell = GetNextEmptyCell();
            constraint = constraint ?? DefaultConstraint;
            if (nextEmptyCell.X + constraint.ColumnSpan > columnWidths.Length)
                throw new InvalidOperationException($"Added a cell at position ({nextEmptyCell.X},{nextEmptyCell.Y}), but the column ({constraint.ColumnSpan}) exceeds the available remaining space in the row ({columnWidths.Length - nextEmptyCell.X}).");

            var jsCell = Browser.Document.CreateElement("td");
            if (constraint.ColumnSpan != 1)
                jsCell.SetAttribute("colspan", constraint.ColumnSpan.ToString());                        
            if (constraint.RowSpan != 1)
                jsCell.SetAttribute("rowspan", constraint.RowSpan.ToString());
            var jsCellDiv = Browser.Document.CreateElement("div");
            jsCell.AppendChild(jsCellDiv);
            switch (constraint.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    jsCell.SetAttribute("align", "left");
                    break;
                case HorizontalAlignment.Center:
                    jsCell.SetAttribute("align", "center");
                    break;
                case HorizontalAlignment.Right:
                    jsCell.SetAttribute("align", "right");
                    break;
                case HorizontalAlignment.Fill:
                    jsCellDiv.Style.Width = "100%";
                    cell.Node.Style.Width = "100%";
                    break;
            }
            switch (constraint.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    jsCell.Style.VerticalAlign = "top";
                    break;
                case VerticalAlignment.Middle:
                    jsCell.Style.VerticalAlign = "middle";
                    break;
                case VerticalAlignment.Bottom:
                    jsCell.Style.VerticalAlign = "bottom";
                    break;
                case VerticalAlignment.Fill:
                    cell.Node.Style.Height = "100%"; 
                    jsCellDiv.Style.Height = "100%";
                    break;
            }
            jsCellDiv.AppendChild(cell.Node);
                        
            for (var row = nextEmptyCell.Y; row < nextEmptyCell.Y + constraint.RowSpan; row++)
            {
                for (var col = nextEmptyCell.X; col < nextEmptyCell.X + constraint.ColumnSpan; col++)
                {
                    while (cells.Count <= row)
                    {
                        cells.Add(new Control[columnWidths.Length]);
                        var newRow = Browser.Document.CreateElement("tr");
                        table.AppendChild(newRow);
                        rows.Add(newRow);
                    }
                    if (cells[row][col] != null)
                        throw new InvalidOperationException("Illegal layout: cannot add a view at row " + row + ", column " + col + " as another view is already present: " + cells[row][col]);
                    cells[row][col] = cell;
                }
            }

            var isFirstRowInTable = nextEmptyCell.Y == 0;
            var isLastCellInRow = nextEmptyCell.X + constraint.ColumnSpan == columnWidths.Length;
            if (!isLastCellInRow && horizontalCellSpacing != 0)
                jsCell.Style.PaddingRight = horizontalCellSpacing + "px";
            if (!isFirstRowInTable)
                jsCell.Style.PaddingTop = verticalCellSpacing + "px";

            var jsRow = rows[nextEmptyCell.Y];
            jsRow.AppendChild(jsCell);

            return jsCellDiv;
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
        public HorizontalAlignment HorizontalAlignment { get; }
        public VerticalAlignment VerticalAlignment { get; }
        public int ColumnSpan { get; }
        public int RowSpan { get; }

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

        public static TableConstraint TopLeft()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Left, verticalAlignment: VerticalAlignment.Top);
        }

        public static TableConstraint TopCenter()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Center, verticalAlignment: VerticalAlignment.Top);
        }

        public static TableConstraint TopRight()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Right, verticalAlignment: VerticalAlignment.Top);
        }

        public static TableConstraint MiddleLeft()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Left, verticalAlignment: VerticalAlignment.Middle);
        }

        public static TableConstraint MiddleRight()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Right, verticalAlignment: VerticalAlignment.Middle);
        }

        public static TableConstraint BottomLeft()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Left, verticalAlignment: VerticalAlignment.Bottom);
        }

        public static TableConstraint BottomCenter()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Center, verticalAlignment: VerticalAlignment.Bottom);
        }

        public static TableConstraint BottomRight()
        {
            return new TableConstraint(horizontalAlignment: HorizontalAlignment.Right, verticalAlignment: VerticalAlignment.Bottom);
        }
    }

    public class TableWidth
    {
        public TableWidthStyle Style { get; }
        public int Value { get; }

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