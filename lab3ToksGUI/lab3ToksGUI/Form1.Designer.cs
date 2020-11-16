namespace lab3ToksGUI
{
    partial class Form1
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
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputTextFild = new System.Windows.Forms.TextBox();
            this.ButtonToEncoding = new System.Windows.Forms.Button();
            this.EncodingLabel = new System.Windows.Forms.Label();
            this.OutputEncoding = new System.Windows.Forms.TextBox();
            this.DecodingLabel = new System.Windows.Forms.Label();
            this.OutputDecoding = new System.Windows.Forms.TextBox();
            this.CheckButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.InputLabel.Location = new System.Drawing.Point(12, 33);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(268, 29);
            this.InputLabel.TabIndex = 0;
            this.InputLabel.Text = "Enter string for codding:";
            // 
            // InputTextFild
            // 
            this.InputTextFild.Location = new System.Drawing.Point(15, 65);
            this.InputTextFild.Name = "InputTextFild";
            this.InputTextFild.Size = new System.Drawing.Size(377, 22);
            this.InputTextFild.TabIndex = 1;
            // 
            // ButtonToEncoding
            // 
            this.ButtonToEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonToEncoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ButtonToEncoding.Location = new System.Drawing.Point(398, 59);
            this.ButtonToEncoding.Name = "ButtonToEncoding";
            this.ButtonToEncoding.Size = new System.Drawing.Size(98, 32);
            this.ButtonToEncoding.TabIndex = 3;
            this.ButtonToEncoding.Text = "Encode";
            this.ButtonToEncoding.UseVisualStyleBackColor = true;
            this.ButtonToEncoding.Click += new System.EventHandler(this.ButtonToEncoding_Click);
            // 
            // EncodingLabel
            // 
            this.EncodingLabel.AutoSize = true;
            this.EncodingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.EncodingLabel.Location = new System.Drawing.Point(12, 108);
            this.EncodingLabel.Name = "EncodingLabel";
            this.EncodingLabel.Size = new System.Drawing.Size(186, 29);
            this.EncodingLabel.TabIndex = 4;
            this.EncodingLabel.Text = "Encoding string:";
            // 
            // OutputEncoding
            // 
            this.OutputEncoding.Location = new System.Drawing.Point(17, 140);
            this.OutputEncoding.Name = "OutputEncoding";
            this.OutputEncoding.Size = new System.Drawing.Size(377, 22);
            this.OutputEncoding.TabIndex = 5;
            // 
            // DecodingLabel
            // 
            this.DecodingLabel.AutoSize = true;
            this.DecodingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DecodingLabel.Location = new System.Drawing.Point(12, 183);
            this.DecodingLabel.Name = "DecodingLabel";
            this.DecodingLabel.Size = new System.Drawing.Size(188, 29);
            this.DecodingLabel.TabIndex = 6;
            this.DecodingLabel.Text = "Decoding string:";
            // 
            // OutputDecoding
            // 
            this.OutputDecoding.Location = new System.Drawing.Point(17, 215);
            this.OutputDecoding.Name = "OutputDecoding";
            this.OutputDecoding.ReadOnly = true;
            this.OutputDecoding.Size = new System.Drawing.Size(377, 22);
            this.OutputDecoding.TabIndex = 7;
            // 
            // CheckButton
            // 
            this.CheckButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CheckButton.Location = new System.Drawing.Point(400, 134);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(98, 32);
            this.CheckButton.TabIndex = 8;
            this.CheckButton.Text = "Check error";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(508, 289);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.OutputDecoding);
            this.Controls.Add(this.DecodingLabel);
            this.Controls.Add(this.OutputEncoding);
            this.Controls.Add(this.EncodingLabel);
            this.Controls.Add(this.ButtonToEncoding);
            this.Controls.Add(this.InputTextFild);
            this.Controls.Add(this.InputLabel);
            this.Name = "Form1";
            this.Text = "Hamming";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox InputTextFild;
        private System.Windows.Forms.Button ButtonToEncoding;
        private System.Windows.Forms.Label EncodingLabel;
        private System.Windows.Forms.TextBox OutputEncoding;
        private System.Windows.Forms.Label DecodingLabel;
        private System.Windows.Forms.TextBox OutputDecoding;
        private System.Windows.Forms.Button CheckButton;
    }
}

