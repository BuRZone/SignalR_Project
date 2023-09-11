using ChatClient.Properties;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        HubConnection? hubConnection;
        string UserName = "";
        string Control = "";
        string mes;
        Point _imageLocation = new Point(20, 4);
        Point _imgHitArea = new Point(20, 4);
        Image closeImage;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            label5.Text = "Notification: Disconnected";
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            readOnlyRichTextBox1.BackColor = Color.White;

        }

        void ConnectUser()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:5001/chat").Build();

            textBox1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            UserName = textBox1.Text;
            label5.Text = $"Notification:";
        }

        void DisconnectUser()
        {
            textBox1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            label4.Text = "0";
            label5.Text = "Notification: Disconnected";
            textBox2.Enabled = false;
            textBox2.Clear();
            button1.Enabled = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await hubConnection.InvokeAsync("Send", UserName, textBox2.Text);
                textBox2.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ConnectUser();
            label5.Text = $"Notification: Connecting...";
            hubConnection.On<string>("AddUser", (message) =>
            {
                Control = message;
            });

            hubConnection.On<string, string>("Receive", (user, message) =>
            {

                var newMassage = $"  {user}: {message}";
                mes = newMassage;
                readOnlyRichTextBox1.AppendText(newMassage + "\n", Color.Black);
                readOnlyRichTextBox1.ScrollToCaret();
            });

            hubConnection.On<int>("updateTotalUsers", (count) =>
            {
                label4.Text = count.ToString();
            });

            try
            {
                await hubConnection.StartAsync();
            }
            catch (HttpRequestException ex)
            {

            }
            finally
            {
                if (hubConnection.State == HubConnectionState.Connected)
                {
                    await hubConnection.InvokeAsync("UserNameAdd", UserName);
                    await Task.Run(() => Task.Delay(1000).Wait());

                    if (Control.Contains("существует"))
                    {
                        await hubConnection.StopAsync();
                        DisconnectUser();
                        label5.Text = $"Notification: {Control}";
                    }
                    else
                    {
                        button3.Enabled = true;
                        await hubConnection.InvokeAsync("UsersConnected");
                        label5.Text = $"Notification: {Control}";
                        textBox2.Enabled = true;
                        await hubConnection.InvokeAsync("Send", "Система", $"Пользователь под именем \"{UserName}\" вошел в чат");
                    }
                }
                else
                {
                    DisconnectUser();
                    label5.Text = $"Notification: Сервер не найден";
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (hubConnection != null && hubConnection.State == HubConnectionState.Connected)
                {
                    DisconnectUser();
                    await Task.Run(() => hubConnection.InvokeAsync("Send", "Система", $"Пользователь под именем \"{UserName}\" покинул чат").Wait());
                    await Task.Run(() => hubConnection.InvokeAsync("UserNameRemove", UserName).Wait());
                    await Task.Run(() => hubConnection.StopAsync().Wait());
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            await Task.Run(() => Task.Delay(1000).Wait()); //иначе может закрыться с оштбкой
            try
            {
                if (hubConnection != null && hubConnection.State == HubConnectionState.Connected)
                {
                    DisconnectUser();
                    await Task.Run(() => hubConnection.InvokeAsync("Send", "Система", $"Пользователь под именем \"{UserName}\" покинул чат").Wait());
                    await Task.Run(() => hubConnection.InvokeAsync("UserNameRemove", UserName).Wait());
                    await Task.Run(() => hubConnection.StopAsync().Wait());
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (textBox2.Text.Length == 0)
            {
                button1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (textBox1.Text.Length < 3)
            {
                button2.Enabled = false;
                label5.Text = "Notification: Имя должно быть не менее 3 символов и не более 15";
            }
        }

        private void readOnlyRichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", e.LinkText); //открывается дефолтный броузер
            }
            catch (Exception ex)
            {

            }
        }

        private void readOnlyRichTextBox1_TextChanged(object sender, EventArgs e)
        {
            {
                Regex regex = new Regex(@"^\s\s[\D\d\s\S\w\W]*:");
                if (regex.IsMatch(mes) && !mes.Contains("Система") && !mes.Contains("  " + UserName + ":"))
                {
                    string f = regex.Match(mes).Value;
                    int index = readOnlyRichTextBox1.Text.LastIndexOf(f);
                    readOnlyRichTextBox1.Select(index, f.Length);
                    readOnlyRichTextBox1.SelectionBackColor = Color.Red;
                }
            }
        }

        private void readOnlyRichTextBox1_MouseDoubleClick(object sender, MouseEventArgs ex)
        {


            if (readOnlyRichTextBox1.SelectionBackColor == Color.Red && tabControl1.Controls.Find(readOnlyRichTextBox1.SelectedText, true).Length == 0)
            {
                TabPage tabPage = new TabPage();
                tabPage.Name = readOnlyRichTextBox1.SelectedText;
                tabPage.Text = readOnlyRichTextBox1.SelectedText;               
                tabControl1.Controls.Add(tabPage);
                ReadOnlyRichTextBox readOnlyRichTextBox = new ReadOnlyRichTextBox();
                tabPage.Controls.Add(readOnlyRichTextBox);
                readOnlyRichTextBox.Dock = DockStyle.Fill;
                readOnlyRichTextBox.BackColor = Color.Aqua;
                readOnlyRichTextBox.MaxLength = 500;
            }
            if (readOnlyRichTextBox1.SelectionBackColor == Color.Red && tabControl1.Controls.Find(readOnlyRichTextBox1.SelectedText, true).Length > 0)
            {
                tabControl1.SelectTab(readOnlyRichTextBox1.SelectedText);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

            closeImage = Properties.Resources.cross;

            //tabControl1.Padding = new Point(15, 4);
            Image img = new Bitmap(closeImage);
            Rectangle r = e.Bounds;
            r = this.tabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tabControl1.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tabControl1.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tabControl1.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tabControl1.SelectedIndex >= 1)
            {
                if (r.Contains(p))
                {
                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    tabControl.TabPages.Remove(tabPage);
                }
            }
        }
    }
}
