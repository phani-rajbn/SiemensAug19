namespace SampleWinApp
{
    partial class PatientInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.txtDiesease = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstNames = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inconsolata", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient Info System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "List of Patients";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtDiesease);
            this.groupBox1.Controls.Add(this.txtDoc);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(422, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 392);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details of Patient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Patient ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "Patient Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 31);
            this.label5.TabIndex = 2;
            this.label5.Text = "Doctor Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 31);
            this.label6.TabIndex = 3;
            this.label6.Text = "Disease:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 31);
            this.label7.TabIndex = 4;
            this.label7.Text = "Bill Amount:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(246, 41);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(259, 33);
            this.txtID.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(246, 98);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(259, 33);
            this.txtName.TabIndex = 6;
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(246, 156);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(259, 33);
            this.txtDoc.TabIndex = 7;
            // 
            // txtDiesease
            // 
            this.txtDiesease.Location = new System.Drawing.Point(246, 216);
            this.txtDiesease.Name = "txtDiesease";
            this.txtDiesease.Size = new System.Drawing.Size(259, 33);
            this.txtDiesease.TabIndex = 8;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(246, 268);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(259, 33);
            this.txtAmount.TabIndex = 9;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(43, 326);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 47);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(220, 326);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 47);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(392, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 47);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstNames
            // 
            this.lstNames.FormattingEnabled = true;
            this.lstNames.ItemHeight = 31;
            this.lstNames.Location = new System.Drawing.Point(66, 141);
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(246, 376);
            this.lstNames.TabIndex = 3;
            this.lstNames.SelectedIndexChanged += new System.EventHandler(this.lstNames_SelectedIndexChanged);
            // 
            // PatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 605);
            this.Controls.Add(this.lstNames);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Inconsolata", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "PatientInfo";
            this.Text = "PatientInfo";
            this.Load += new System.EventHandler(this.PatientInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtDiesease;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox lstNames;
    }
}