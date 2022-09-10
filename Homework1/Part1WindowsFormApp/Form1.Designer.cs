namespace Part1WindowsFormApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vowelLabel = new System.Windows.Forms.Label();
            this.upperLabel = new System.Windows.Forms.Label();
            this.reverseLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "String: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vowel Count: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Uppercase Count: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Reverse String:";
            // 
            // vowelLabel
            // 
            this.vowelLabel.AutoSize = true;
            this.vowelLabel.Location = new System.Drawing.Point(201, 100);
            this.vowelLabel.Name = "vowelLabel";
            this.vowelLabel.Size = new System.Drawing.Size(16, 13);
            this.vowelLabel.TabIndex = 5;
            this.vowelLabel.Text = "---";
            // 
            // upperLabel
            // 
            this.upperLabel.AutoSize = true;
            this.upperLabel.Location = new System.Drawing.Point(201, 149);
            this.upperLabel.Name = "upperLabel";
            this.upperLabel.Size = new System.Drawing.Size(16, 13);
            this.upperLabel.TabIndex = 6;
            this.upperLabel.Text = "---";
            // 
            // reverseLabel
            // 
            this.reverseLabel.AutoSize = true;
            this.reverseLabel.Location = new System.Drawing.Point(201, 196);
            this.reverseLabel.Name = "reverseLabel";
            this.reverseLabel.Size = new System.Drawing.Size(16, 13);
            this.reverseLabel.TabIndex = 7;
            this.reverseLabel.Text = "---";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Analyze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reverseLabel);
            this.Controls.Add(this.upperLabel);
            this.Controls.Add(this.vowelLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label vowelLabel;
        private System.Windows.Forms.Label upperLabel;
        private System.Windows.Forms.Label reverseLabel;
        private System.Windows.Forms.Button button1;
    }
}

