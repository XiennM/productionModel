namespace produ
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
            this.factsComboBox = new System.Windows.Forms.CheckedListBox();
            this.forwardButton = new System.Windows.Forms.RadioButton();
            this.backwardButton = new System.Windows.Forms.RadioButton();
            this.finalFactsComboBox = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // factsComboBox
            // 
            this.factsComboBox.FormattingEnabled = true;
            this.factsComboBox.Location = new System.Drawing.Point(12, 39);
            this.factsComboBox.Name = "factsComboBox";
            this.factsComboBox.ScrollAlwaysVisible = true;
            this.factsComboBox.Size = new System.Drawing.Size(234, 409);
            this.factsComboBox.TabIndex = 0;
            // 
            // forwardButton
            // 
            this.forwardButton.AutoSize = true;
            this.forwardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.forwardButton.Checked = true;
            this.forwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forwardButton.Location = new System.Drawing.Point(12, 12);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(119, 21);
            this.forwardButton.TabIndex = 1;
            this.forwardButton.TabStop = true;
            this.forwardButton.Text = "прямой вывод";
            this.forwardButton.UseVisualStyleBackColor = false;
            this.forwardButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // backwardButton
            // 
            this.backwardButton.AutoSize = true;
            this.backwardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backwardButton.Location = new System.Drawing.Point(137, 12);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(135, 21);
            this.backwardButton.TabIndex = 2;
            this.backwardButton.TabStop = true;
            this.backwardButton.Text = "обратный вывод";
            this.backwardButton.UseVisualStyleBackColor = false;
            // 
            // finalFactsComboBox
            // 
            this.finalFactsComboBox.FormattingEnabled = true;
            this.finalFactsComboBox.Location = new System.Drawing.Point(252, 42);
            this.finalFactsComboBox.Name = "finalFactsComboBox";
            this.finalFactsComboBox.ScrollAlwaysVisible = true;
            this.finalFactsComboBox.Size = new System.Drawing.Size(310, 409);
            this.finalFactsComboBox.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(568, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(420, 409);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(856, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Перезапуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(718, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Запуск";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 455);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.finalFactsComboBox);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.factsComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox factsComboBox;
        private System.Windows.Forms.RadioButton forwardButton;
        private System.Windows.Forms.RadioButton backwardButton;
        private System.Windows.Forms.CheckedListBox finalFactsComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

