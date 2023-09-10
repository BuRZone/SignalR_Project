using System.Text.RegularExpressions;

namespace ChatClient
{
    public static class ReadOnlyRichTextBoxExtensions
    {
        public static void AppendText(this ReadOnlyRichTextBox box, string text, Color color)
        {
            Regex regex = new Regex(@"^  Система: Пользователь под именем [\D\d\s\S\w\W]* вошел в чат");
            Regex regex1 = new Regex(@"^  Система: Пользователь под именем [\D\d\s\S\w\W]* покинул чат");
            if (regex.IsMatch(text))
            {
                color = Color.LightSeaGreen;
            }
            if (regex1.IsMatch(text))
            {
                color = Color.Red;
            }
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.ReadOnly = true;
        }
    }
}
