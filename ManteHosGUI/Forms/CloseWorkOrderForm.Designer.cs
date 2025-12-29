namespace ManteHos.Presentation.Forms
{
    partial class CloseWorkOrderForm
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
            this.workOrdersLabel = new System.Windows.Forms.Label();
            this.workOrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIncidentDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repairReportLabel = new System.Windows.Forms.Label();
            this.repairReportTextBox = new System.Windows.Forms.RichTextBox();
            this.closeWorkOrderButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.workOrdersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOrdersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // workOrdersLabel
            // 
            this.workOrdersLabel.AutoSize = true;
            this.workOrdersLabel.Location = new System.Drawing.Point(27, 19);
            this.workOrdersLabel.Name = "workOrdersLabel";
            this.workOrdersLabel.Size = new System.Drawing.Size(156, 17);
            this.workOrdersLabel.TabIndex = 0;
            this.workOrdersLabel.Text = "Your Open Work Orders:";
            // 
            // workOrdersDataGridView
            // 
            this.workOrdersDataGridView.AllowUserToAddRows = false;
            this.workOrdersDataGridView.AllowUserToDeleteRows = false;
            this.workOrdersDataGridView.AutoGenerateColumns = false;
            this.workOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workOrdersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colStartDate,
            this.colIncidentDescription,
            this.colDepartment});
            this.workOrdersDataGridView.DataSource = this.workOrdersBindingSource;
            this.workOrdersDataGridView.Location = new System.Drawing.Point(30, 48);
            this.workOrdersDataGridView.MultiSelect = false;
            this.workOrdersDataGridView.Name = "workOrdersDataGridView";
            this.workOrdersDataGridView.ReadOnly = true;
            this.workOrdersDataGridView.RowHeadersWidth = 51;
            this.workOrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.workOrdersDataGridView.Size = new System.Drawing.Size(540, 180);
            this.workOrdersDataGridView.TabIndex = 1;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ds_Id";
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colStartDate
            // 
            this.colStartDate.DataPropertyName = "ds_StartDate";
            this.colStartDate.HeaderText = "Start Date";
            this.colStartDate.MinimumWidth = 6;
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.Width = 120;
            // 
            // colIncidentDescription
            // 
            this.colIncidentDescription.DataPropertyName = "ds_IncidentDescription";
            this.colIncidentDescription.HeaderText = "Description";
            this.colIncidentDescription.MinimumWidth = 6;
            this.colIncidentDescription.Name = "colIncidentDescription";
            this.colIncidentDescription.ReadOnly = true;
            this.colIncidentDescription.Width = 200;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "ds_Department";
            this.colDepartment.HeaderText = "Department";
            this.colDepartment.MinimumWidth = 6;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 120;
            // 
            // repairReportLabel
            // 
            this.repairReportLabel.AutoSize = true;
            this.repairReportLabel.Location = new System.Drawing.Point(27, 245);
            this.repairReportLabel.Name = "repairReportLabel";
            this.repairReportLabel.Size = new System.Drawing.Size(100, 17);
            this.repairReportLabel.TabIndex = 2;
            this.repairReportLabel.Text = "Repair Report:";
            // 
            // repairReportTextBox
            // 
            this.repairReportTextBox.Location = new System.Drawing.Point(30, 274);
            this.repairReportTextBox.Name = "repairReportTextBox";
            this.repairReportTextBox.Size = new System.Drawing.Size(540, 100);
            this.repairReportTextBox.TabIndex = 3;
            this.repairReportTextBox.Text = "";
            // 
            // closeWorkOrderButton
            // 
            this.closeWorkOrderButton.Location = new System.Drawing.Point(350, 394);
            this.closeWorkOrderButton.Name = "closeWorkOrderButton";
            this.closeWorkOrderButton.Size = new System.Drawing.Size(120, 35);
            this.closeWorkOrderButton.TabIndex = 4;
            this.closeWorkOrderButton.Text = "Close Work Order";
            this.closeWorkOrderButton.UseVisualStyleBackColor = true;
            this.closeWorkOrderButton.Click += new System.EventHandler(this.closeWorkOrderButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(480, 394);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 35);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CloseWorkOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.closeWorkOrderButton);
            this.Controls.Add(this.repairReportTextBox);
            this.Controls.Add(this.repairReportLabel);
            this.Controls.Add(this.workOrdersDataGridView);
            this.Controls.Add(this.workOrdersLabel);
            this.Name = "CloseWorkOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Close Work Order";
            this.Shown += new System.EventHandler(this.CloseWorkOrderForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.workOrdersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOrdersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label workOrdersLabel;
        private System.Windows.Forms.DataGridView workOrdersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIncidentDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.BindingSource workOrdersBindingSource;
        private System.Windows.Forms.Label repairReportLabel;
        private System.Windows.Forms.RichTextBox repairReportTextBox;
        private System.Windows.Forms.Button closeWorkOrderButton;
        private System.Windows.Forms.Button cancelButton;
    }
}