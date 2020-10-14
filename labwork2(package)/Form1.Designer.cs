namespace lab2TOKSIK
{
    partial class COM_CHAT_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chatWindow = new System.Windows.Forms.TextBox();
            this.msgWindow = new System.Windows.Forms.TextBox();
            this.port = new Port();
            //this.Port = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chatWindow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.msgWindow);
            this.splitContainer1.Size = new System.Drawing.Size(436, 287);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // chatWindow
            // 
            this.chatWindow.BackColor = System.Drawing.SystemColors.Info;
            this.chatWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatWindow.Enabled = false;
            this.chatWindow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chatWindow.Location = new System.Drawing.Point(0, 0);
            this.chatWindow.Margin = new System.Windows.Forms.Padding(2);
            this.chatWindow.Multiline = true;
            this.chatWindow.Name = "chatWindow";
            this.chatWindow.ReadOnly = true;
            this.chatWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatWindow.Size = new System.Drawing.Size(436, 258);
            this.chatWindow.TabIndex = 0;
            this.chatWindow.TabStop = false;
            // 
            // msgWindow
            // 
            this.msgWindow.BackColor = System.Drawing.SystemColors.Info;
            this.msgWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgWindow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.msgWindow.Location = new System.Drawing.Point(0, 0);
            this.msgWindow.Margin = new System.Windows.Forms.Padding(2);
            this.msgWindow.Name = "msgWindow";
            this.msgWindow.Size = new System.Drawing.Size(436, 20);
            this.msgWindow.TabIndex = 0;
            this.msgWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msgWindow_KeyDown);
            // 
            // Port
            // 
            this.port.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.COM_Port_DataReceived);
            // 
            // COM_CHAT_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 287);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "COM_CHAT_Form";
            this.Text = "COM_CHAT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.COM_CHAT_Form_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox msgWindow;
        private Port port;
        private System.Windows.Forms.TextBox chatWindow;
    }
}

