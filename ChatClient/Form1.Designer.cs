namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button3 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            readOnlyRichTextBox1 = new ReadOnlyRichTextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 25);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 100);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 1;
            label2.Text = "Сообщение";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(114, 10);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.MaxLength = 15;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(322, 31);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(114, 93);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.MaxLength = 500;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(438, 31);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(560, 93);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(107, 38);
            button1.TabIndex = 5;
            button1.Text = "Отправить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(446, 10);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(107, 38);
            button2.TabIndex = 6;
            button2.Text = "Connect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 753);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(119, 25);
            label3.TabIndex = 7;
            label3.Text = "Подключено";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(649, 753);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(22, 25);
            label4.TabIndex = 8;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(114, 53);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(104, 25);
            label5.TabIndex = 9;
            label5.Text = "Notification";
            // 
            // button3
            // 
            button3.Location = new Point(560, 10);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(107, 38);
            button3.TabIndex = 10;
            button3.Text = "Disconnect";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(29, 157);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(12, 4);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(624, 592);
            tabControl1.TabIndex = 13;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.MouseClick += tabControl1_MouseClick;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(readOnlyRichTextBox1);
            tabPage1.Location = new Point(4, 36);
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(616, 552);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Общий";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // readOnlyRichTextBox1
            // 
            readOnlyRichTextBox1.BorderStyle = BorderStyle.FixedSingle;
            readOnlyRichTextBox1.Dock = DockStyle.Fill;
            readOnlyRichTextBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            readOnlyRichTextBox1.Location = new Point(4, 5);
            readOnlyRichTextBox1.Margin = new Padding(4, 5, 4, 5);
            readOnlyRichTextBox1.MaxLength = 500;
            readOnlyRichTextBox1.Name = "readOnlyRichTextBox1";
            readOnlyRichTextBox1.Size = new Size(608, 542);
            readOnlyRichTextBox1.TabIndex = 12;
            readOnlyRichTextBox1.Text = "";
            readOnlyRichTextBox1.TextChanged += readOnlyRichTextBox1_TextChanged;
            readOnlyRichTextBox1.MouseDoubleClick += readOnlyRichTextBox1_MouseDoubleClick;
            // 
            // Form1
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(684, 790);
            Controls.Add(tabControl1);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Form1";
            Text = "SignalR_Client";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ReadOnlyRichTextBox readOnlyRichTextBox1;
    }
}