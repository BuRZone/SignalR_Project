using System.ComponentModel;
using System.Runtime.InteropServices;


namespace ChatClient
{
    public class ReadOnlyRichTextBox : RichTextBox
    {

        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);

        public ReadOnlyRichTextBox()
        {
            this.MouseDown += new MouseEventHandler(this.ReadOnlyRichTextBox_Mouse);
            this.MouseUp += new MouseEventHandler(this.ReadOnlyRichTextBox_Mouse);
            base.ReadOnly = true;
            base.TabStop = false;
            HideCaret(this.Handle);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            HideCaret(this.Handle);
        }

        protected override void OnEnter(EventArgs e)
        {
            HideCaret(this.Handle);
        }

        [DefaultValue(true)]
        public new bool ReadOnly
        {
            get { return true; }
            set { }
        }

        [DefaultValue(false)]
        public new bool TabStop
        {
            get { return false; }
            set { }
        }

        private void ReadOnlyRichTextBox_Mouse(object sender, MouseEventArgs e)
        {
            HideCaret(this.Handle);
        }

        private void InitializeComponent()
        {
            //
            // ReadOnlyRichTextBox
            //
            this.Resize += new System.EventHandler(this.ReadOnlyRichTextBox_Resize);

        }

        private void ReadOnlyRichTextBox_Resize(object sender, EventArgs e)
        {
            HideCaret(this.Handle);
        }
    }
}
