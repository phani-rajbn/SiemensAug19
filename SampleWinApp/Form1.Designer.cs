namespace SampleWinApp
{
    partial class MainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.cmbOptions = new System.Windows.Forms.ComboBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inconsolata", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculator Program";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Value1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter Value2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Operation:";
            // 
            // txtValue1
            // 
            this.txtValue1.Location = new System.Drawing.Point(248, 135);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(287, 30);
            this.txtValue1.TabIndex = 4;
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(248, 192);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(287, 30);
            this.txtValue2.TabIndex = 5;
            // 
            // cmbOptions
            // 
            this.cmbOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptions.FormattingEnabled = true;
            this.cmbOptions.Items.AddRange(new object[] {
            "Add",
            "Subtract",
            "Multiply",
            "Divide"});
            this.cmbOptions.Location = new System.Drawing.Point(248, 255);
            this.cmbOptions.Name = "cmbOptions";
            this.cmbOptions.Size = new System.Drawing.Size(287, 35);
            this.cmbOptions.TabIndex = 6;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(295, 362);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(199, 51);
            this.btnGet.TabIndex = 7;
            this.btnGet.Text = "Get Value";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAnswer);
            this.groupBox1.Location = new System.Drawing.Point(565, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 155);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Answer";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Inconsolata", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Location = new System.Drawing.Point(92, 58);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 42);
            this.lblAnswer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.cmbOptions);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.txtValue1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Inconsolata", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValue1;
        private System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.ComboBox cmbOptions;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAnswer;
    }
}

