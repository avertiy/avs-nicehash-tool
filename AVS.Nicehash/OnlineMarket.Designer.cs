namespace AVS.Nicehash
{
    partial class OnlineMarket
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new AVS.CoreLib.WinForms.Grid.GridControl();
            this.ColumnAlgo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMiners = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAlive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 446);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Online market";
            // 
            // gridControl1
            // 
            this.gridControl1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAlgo,
            this.ColType,
            this.ColumnOrder,
            this.ColumnLimit,
            this.ColumnPrice,
            this.ColumnMiners,
            this.ColumnSpeed,
            this.ColumnAlive});
            this.gridControl1.Controller = null;
            this.gridControl1.DataSource = null;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.GridSummaryText = "";
            this.gridControl1.Location = new System.Drawing.Point(3, 16);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(737, 427);
            this.gridControl1.TabIndex = 1;
            // 
            // ColumnAlgo
            // 
            this.ColumnAlgo.DataPropertyName = "Algorithm";
            this.ColumnAlgo.HeaderText = "Algo";
            this.ColumnAlgo.Name = "ColumnAlgo";
            this.ColumnAlgo.Width = 60;
            // 
            // ColType
            // 
            this.ColType.DataPropertyName = "Type";
            this.ColType.HeaderText = "Type";
            this.ColType.Name = "ColType";
            // 
            // ColumnOrder
            // 
            this.ColumnOrder.DataPropertyName = "Id";
            this.ColumnOrder.HeaderText = "Order";
            this.ColumnOrder.Name = "ColumnOrder";
            // 
            // ColumnLimit
            // 
            this.ColumnLimit.DataPropertyName = "SpeedLimit";
            this.ColumnLimit.HeaderText = "Limit";
            this.ColumnLimit.Name = "ColumnLimit";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.DataPropertyName = "Price";
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // ColumnMiners
            // 
            this.ColumnMiners.DataPropertyName = "Workers";
            this.ColumnMiners.HeaderText = "Miners";
            this.ColumnMiners.Name = "ColumnMiners";
            // 
            // ColumnSpeed
            // 
            this.ColumnSpeed.DataPropertyName = "AcceptedSpeed";
            this.ColumnSpeed.HeaderText = "Speed";
            this.ColumnSpeed.Name = "ColumnSpeed";
            // 
            // ColumnAlive
            // 
            this.ColumnAlive.DataPropertyName = "IsAlive";
            this.ColumnAlive.HeaderText = "Alive";
            this.ColumnAlive.Name = "ColumnAlive";
            this.ColumnAlive.Width = 50;
            // 
            // OnlineMarket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OnlineMarket";
            this.Size = new System.Drawing.Size(743, 446);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CoreLib.WinForms.Grid.GridControl gridControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlgo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMiners;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpeed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAlive;
    }
}
