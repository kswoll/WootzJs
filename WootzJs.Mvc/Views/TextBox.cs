using System;
using System.Runtime.WootzJs;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class TextBox : Control
    {
        public event Action Changed;

        private Action<KeyboardEvent> keyPress;
        private Action<KeyboardEvent> keyUp;
        private Action<KeyboardEvent> keyDown;

        public new InputElement Node
        {
            get { return base.Node.As<InputElement>(); }
        }

        public TextBoxType Type
        {
            get { return TextBoxTypes.Parse(Node.GetAttribute("type")); }
            set { Node.SetAttribute("type", value.GetInputType()); }
        }

        public string Name
        {
            get { return Node.GetAttribute("name"); }
            set { Node.SetAttribute("name", value); }
        }

        public string Placeholder
        {
            get { return Node.GetAttribute("placeholder"); }
            set { Node.SetAttribute("placeholder", value); }
        }

        public int? MaxLength
        {
            get
            {
                var maxLength = Node.GetAttribute("maxlength");
                return maxLength != null ? (int?)int.Parse(maxLength) : null;
            }
            set
            {
                if (value != null)
                    Node.SetAttribute("maxlength", value.Value.ToString());
                else
                    Node.RemoveAttribute("maxlength");
            }
        }

        public event Action<KeyboardEvent> KeyPress
        {
            add
            {
                if (keyPress == null)
                    Node.AddEventListener("keypress", OnKeyPress);
                keyPress = (Action<KeyboardEvent>)Delegate.Combine(keyPress, value);
            }
            remove
            {
                keyPress = (Action<KeyboardEvent>)Delegate.Remove(keyPress, value);
                if (keyPress == null)
                    Node.RemoveEventListener("keypress", OnKeyPress);
            }
        }

        private void OnKeyPress(Event evt)
        {
            if (keyPress != null)
                keyPress((KeyboardEvent)evt);
        }

        public event Action<KeyboardEvent> KeyDown
        {
            add
            {
                if (keyDown == null)
                    Node.AddEventListener("keydown", OnKeyDown);
                keyDown = (Action<KeyboardEvent>)Delegate.Combine(keyDown, value);
            }
            remove
            {
                keyDown = (Action<KeyboardEvent>)Delegate.Remove(keyDown, value);
                if (keyDown == null)
                    Node.RemoveEventListener("keydown", OnKeyDown);
            }
        }

        private void OnKeyDown(Event evt)
        {
            if (keyDown != null)
                keyDown((KeyboardEvent)evt);
        }

        public event Action<KeyboardEvent> KeyUp
        {
            add
            {
                if (keyUp == null)
                    Node.AddEventListener("keyup", OnKeyUp);
                keyUp = (Action<KeyboardEvent>)Delegate.Combine(keyUp, value);
            }
            remove
            {
                keyUp = (Action<KeyboardEvent>)Delegate.Remove(keyUp, value);
                if (keyUp == null)
                    Node.RemoveEventListener("keyup", OnKeyUp);
            }
        }

        private void OnKeyUp(Event evt)
        {
            if (keyUp != null)
                keyUp((KeyboardEvent)evt);
        }

        protected override Element CreateNode()
        {
            var textBox = Browser.Document.CreateElement("input");
            textBox.SetAttribute("type", "text");
            textBox.AddEventListener("change", OnJsChanged);

            return textBox;
        }

        private void OnJsChanged(Event evt)
        {
            var changed = Changed;
            if (changed != null)
                changed();
        }

        public string Text
        {
            get
            {
                EnsureNodeExists();
                return Node.Value;
            }
            set
            {
                EnsureNodeExists();
                Node.Value = value;
            }
        }
    }
}