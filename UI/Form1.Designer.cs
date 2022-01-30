namespace UI
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
            this.btnClickThis = new System.Windows.Forms.Button();
            this.lblHelloWorld = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClickThis
            // 
            this.btnClickThis.BackColor = System.Drawing.Color.Chartreuse;
            this.btnClickThis.Location = new System.Drawing.Point(260, 12);
            this.btnClickThis.Name = "btnClickThis";
            this.btnClickThis.Size = new System.Drawing.Size(129, 66);
            this.btnClickThis.TabIndex = 0;
            this.btnClickThis.Text = "Start Searching";
            this.btnClickThis.UseVisualStyleBackColor = false;
            this.btnClickThis.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHelloWorld
            // 
            this.lblHelloWorld.AutoSize = true;
            this.lblHelloWorld.Location = new System.Drawing.Point(257, 90);
            this.lblHelloWorld.Name = "lblHelloWorld";
            this.lblHelloWorld.Size = new System.Drawing.Size(136, 16);
            this.lblHelloWorld.TabIndex = 1;
            this.lblHelloWorld.Text = "Status: Not in process";
            this.lblHelloWorld.Click += new System.EventHandler(this.lblHelloWorld_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "City:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Location = new System.Drawing.Point(260, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 53);
            this.button2.TabIndex = 5;
            this.button2.Text = "Check data in table";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(474, 283);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblHelloWorld);
            this.Controls.Add(this.btnClickThis);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClickThis;
        private System.Windows.Forms.Label lblHelloWorld;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

