
namespace WootzJs.Mvc.Mvc.Views
{
    public class AlignmentPanel : TablePanel
    {
        public static AlignmentPanel Top(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Fill, VerticalAlignment.Top);
        }

        public static AlignmentPanel Bottom(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Fill, VerticalAlignment.Bottom);
        }

        public static AlignmentPanel Right(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Right, VerticalAlignment.Fill);
        }

        public static AlignmentPanel Left(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Left, VerticalAlignment.Fill);
        }

        public AlignmentPanel(Control content, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment) : base(TableWidth.AllWeight(1))
        {
            Add(content, new TableConstraint(horizontalAlignment, verticalAlignment));
        }
    }
}