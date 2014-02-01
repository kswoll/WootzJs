
namespace WootzJs.Mvc.Mvc.Views
{
    public class AlignmentPanel : TablePanel
    {
        public static AlignmentPanel Top(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Fill, VerticalAlignment.Top);
        }

        public AlignmentPanel(Control content, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment) : base(TableWidth.AllWeight(1))
        {
            Add(content, new TableConstraint(horizontalAlignment, verticalAlignment));
        }
    }
}