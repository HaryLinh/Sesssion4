namespace Session4
{
    partial class frmEditIventory
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
            this.cbbPartName = new System.Windows.Forms.ComboBox();
            this.cbbTransaction = new System.Windows.Forms.ComboBox();
            this.cbbSource = new System.Windows.Forms.ComboBox();
            this.cbbDesnitation = new System.Windows.Forms.ComboBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbbPartName
            // 
            this.cbbPartName.FormattingEnabled = true;
            this.cbbPartName.Location = new System.Drawing.Point(129, 47);
            this.cbbPartName.Name = "cbbPartName";
            this.cbbPartName.Size = new System.Drawing.Size(219, 21);
            this.cbbPartName.TabIndex = 0;
            // 
            // cbbTransaction
            // 
            this.cbbTransaction.FormattingEnabled = true;
            this.cbbTransaction.Location = new System.Drawing.Point(129, 117);
            this.cbbTransaction.Name = "cbbTransaction";
            this.cbbTransaction.Size = new System.Drawing.Size(219, 21);
            this.cbbTransaction.TabIndex = 1;
            // 
            // cbbSource
            // 
            this.cbbSource.FormattingEnabled = true;
            this.cbbSource.Location = new System.Drawing.Point(129, 190);
            this.cbbSource.Name = "cbbSource";
            this.cbbSource.Size = new System.Drawing.Size(219, 21);
            this.cbbSource.TabIndex = 2;
            // 
            // cbbDesnitation
            // 
            this.cbbDesnitation.FormattingEnabled = true;
            this.cbbDesnitation.Location = new System.Drawing.Point(129, 266);
            this.cbbDesnitation.Name = "cbbDesnitation";
            this.cbbDesnitation.Size = new System.Drawing.Size(219, 21);
            this.cbbDesnitation.TabIndex = 3;
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(560, 44);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(105, 20);
            this.date.TabIndex = 4;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(560, 118);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(112, 20);
            this.txtAmount.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "PartName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "TransactionType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Source";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Desnitation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(462, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Amount";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(542, 231);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 56);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmEditIventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.date);
            this.Controls.Add(this.cbbDesnitation);
            this.Controls.Add(this.cbbSource);
            this.Controls.Add(this.cbbTransaction);
            this.Controls.Add(this.cbbPartName);
            this.Name = "frmEditIventory";
            this.Text = "frmEditIventory";
            this.Load += new System.EventHandler(this.frmEditIventory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbPartName;
        private System.Windows.Forms.ComboBox cbbTransaction;
        private System.Windows.Forms.ComboBox cbbSource;
        private System.Windows.Forms.ComboBox cbbDesnitation;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEdit;
    }
}