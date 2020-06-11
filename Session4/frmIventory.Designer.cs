namespace Session4
{
    partial class frmIventory
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchaseOrderManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehouseManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranSactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.next = new System.Windows.Forms.Button();
            this.pre = new System.Windows.Forms.Button();
            this.last_page = new System.Windows.Forms.Button();
            this.first_page = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrderManagementToolStripMenuItem,
            this.warehouseManagementToolStripMenuItem,
            this.inventoryReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // purchaseOrderManagementToolStripMenuItem
            // 
            this.purchaseOrderManagementToolStripMenuItem.Name = "purchaseOrderManagementToolStripMenuItem";
            this.purchaseOrderManagementToolStripMenuItem.Size = new System.Drawing.Size(174, 20);
            this.purchaseOrderManagementToolStripMenuItem.Text = "Purchase Order Management";
            this.purchaseOrderManagementToolStripMenuItem.Click += new System.EventHandler(this.purchaseOrderManagementToolStripMenuItem_Click);
            // 
            // warehouseManagementToolStripMenuItem
            // 
            this.warehouseManagementToolStripMenuItem.Name = "warehouseManagementToolStripMenuItem";
            this.warehouseManagementToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.warehouseManagementToolStripMenuItem.Text = "Warehouse Management";
            this.warehouseManagementToolStripMenuItem.Click += new System.EventHandler(this.warehouseManagementToolStripMenuItem_Click);
            // 
            // inventoryReportToolStripMenuItem
            // 
            this.inventoryReportToolStripMenuItem.Name = "inventoryReportToolStripMenuItem";
            this.inventoryReportToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.inventoryReportToolStripMenuItem.Text = "Inventory Report";
            this.inventoryReportToolStripMenuItem.Click += new System.EventHandler(this.inventoryReportToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartName,
            this.TranSactionType,
            this.Date,
            this.Amount,
            this.Source,
            this.Destination,
            this.OrderItem,
            this.PartID,
            this.IDDes,
            this.IDSource,
            this.TranID});
            this.dataGridView1.Location = new System.Drawing.Point(24, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(825, 333);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PartName
            // 
            this.PartName.DataPropertyName = "PartName";
            this.PartName.HeaderText = "PartName";
            this.PartName.Name = "PartName";
            // 
            // TranSactionType
            // 
            this.TranSactionType.DataPropertyName = "TranSactionName";
            this.TranSactionType.HeaderText = "TranSactionType";
            this.TranSactionType.Name = "TranSactionType";
            this.TranSactionType.Width = 150;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "OrderDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Source
            // 
            this.Source.DataPropertyName = "source";
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            // 
            // Destination
            // 
            this.Destination.DataPropertyName = "Desnitaion";
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            this.Destination.Width = 120;
            // 
            // OrderItem
            // 
            this.OrderItem.DataPropertyName = "OrderItem";
            this.OrderItem.HeaderText = "OrderItem";
            this.OrderItem.Name = "OrderItem";
            this.OrderItem.Visible = false;
            // 
            // PartID
            // 
            this.PartID.DataPropertyName = "PartID";
            this.PartID.HeaderText = "PartID";
            this.PartID.Name = "PartID";
            this.PartID.Visible = false;
            // 
            // IDDes
            // 
            this.IDDes.DataPropertyName = "IDDes";
            this.IDDes.HeaderText = "IDDes";
            this.IDDes.Name = "IDDes";
            this.IDDes.Visible = false;
            // 
            // IDSource
            // 
            this.IDSource.DataPropertyName = "IDSource";
            this.IDSource.HeaderText = "IDSource";
            this.IDSource.Name = "IDSource";
            this.IDSource.Visible = false;
            // 
            // TranID
            // 
            this.TranID.DataPropertyName = "TranID";
            this.TranID.HeaderText = "TranID";
            this.TranID.Name = "TranID";
            this.TranID.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PartName";
            this.dataGridViewTextBoxColumn1.HeaderText = "PartName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TranSactionName";
            this.dataGridViewTextBoxColumn2.HeaderText = "TranSactionType";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrderDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "source";
            this.dataGridViewTextBoxColumn5.HeaderText = "Source";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Desnitaion";
            this.dataGridViewTextBoxColumn6.HeaderText = "Destination";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(342, 404);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(44, 23);
            this.next.TabIndex = 2;
            this.next.Text = ">>";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // pre
            // 
            this.pre.Location = new System.Drawing.Point(409, 404);
            this.pre.Name = "pre";
            this.pre.Size = new System.Drawing.Size(39, 23);
            this.pre.TabIndex = 3;
            this.pre.Text = "<<";
            this.pre.UseVisualStyleBackColor = true;
            this.pre.Click += new System.EventHandler(this.pre_Click);
            // 
            // last_page
            // 
            this.last_page.Location = new System.Drawing.Point(473, 404);
            this.last_page.Name = "last_page";
            this.last_page.Size = new System.Drawing.Size(75, 23);
            this.last_page.TabIndex = 4;
            this.last_page.Text = "Last";
            this.last_page.UseVisualStyleBackColor = true;
            this.last_page.Click += new System.EventHandler(this.last_page_Click);
            // 
            // first_page
            // 
            this.first_page.Location = new System.Drawing.Point(232, 404);
            this.first_page.Name = "first_page";
            this.first_page.Size = new System.Drawing.Size(81, 23);
            this.first_page.TabIndex = 5;
            this.first_page.Text = "First";
            this.first_page.UseVisualStyleBackColor = true;
            this.first_page.Click += new System.EventHandler(this.first_page_Click);
            // 
            // frmIventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 443);
            this.Controls.Add(this.first_page);
            this.Controls.Add(this.last_page);
            this.Controls.Add(this.pre);
            this.Controls.Add(this.next);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmIventory";
            this.Text = "Iventory Mangement";
            this.Load += new System.EventHandler(this.frmIventory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryReportToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranSactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranID;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button pre;
        private System.Windows.Forms.Button last_page;
        private System.Windows.Forms.Button first_page;
    }
}

