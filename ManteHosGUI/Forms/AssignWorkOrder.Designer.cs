namespace ManteHos.Presentation.Forms
{
    partial class AssignWorkOrder
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAssignedOps = new System.Windows.Forms.ListBox();
            this.comboBoxAvailableOps = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddOperator = new System.Windows.Forms.Button();
            this.btnRemoveOperator = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(64, 143);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(320, 185);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select an incident of the list to view the available operators";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxAssignedOps
            // 
            this.listBoxAssignedOps.FormattingEnabled = true;
            this.listBoxAssignedOps.ItemHeight = 16;
            this.listBoxAssignedOps.Location = new System.Drawing.Point(429, 166);
            this.listBoxAssignedOps.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxAssignedOps.Name = "listBoxAssignedOps";
            this.listBoxAssignedOps.Size = new System.Drawing.Size(193, 116);
            this.listBoxAssignedOps.TabIndex = 2;
            // 
            // comboBoxAvailableOps
            // 
            this.comboBoxAvailableOps.FormattingEnabled = true;
            this.comboBoxAvailableOps.Location = new System.Drawing.Point(688, 166);
            this.comboBoxAvailableOps.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAvailableOps.Name = "comboBoxAvailableOps";
            this.comboBoxAvailableOps.Size = new System.Drawing.Size(160, 24);
            this.comboBoxAvailableOps.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assigned Operators";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(688, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Available Operators";
            // 
            // btnAddOperator
            // 
            this.btnAddOperator.Location = new System.Drawing.Point(883, 164);
            this.btnAddOperator.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddOperator.Name = "btnAddOperator";
            this.btnAddOperator.Size = new System.Drawing.Size(131, 28);
            this.btnAddOperator.TabIndex = 6;
            this.btnAddOperator.Text = "Add Operator";
            this.btnAddOperator.UseVisualStyleBackColor = true;
            this.btnAddOperator.Click += new System.EventHandler(this.btnAddOperator_Click);
            // 
            // btnRemoveOperator
            // 
            this.btnRemoveOperator.Location = new System.Drawing.Point(433, 299);
            this.btnRemoveOperator.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveOperator.Name = "btnRemoveOperator";
            this.btnRemoveOperator.Size = new System.Drawing.Size(191, 28);
            this.btnRemoveOperator.TabIndex = 7;
            this.btnRemoveOperator.Text = "Remove Operator";
            this.btnRemoveOperator.UseVisualStyleBackColor = true;
            this.btnRemoveOperator.Click += new System.EventHandler(this.btnRemoveOperator_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(913, 496);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Finish";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AssignWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRemoveOperator);
            this.Controls.Add(this.btnAddOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAvailableOps);
            this.Controls.Add(this.listBoxAssignedOps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AssignWorkOrder";
            this.Text = "AssignWorkOrder";
            this.Load += new System.EventHandler(this.AssignWorkOrder_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAssignedOps;
        private System.Windows.Forms.ComboBox comboBoxAvailableOps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddOperator;
        private System.Windows.Forms.Button btnRemoveOperator;
        private System.Windows.Forms.Button button1;
    }
}