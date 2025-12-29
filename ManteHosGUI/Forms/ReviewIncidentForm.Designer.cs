namespace ManteHos.Presentation.Forms
{
    partial class ReviewIncidentForm
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
            this.IncidentsbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.textReason = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textArea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RejButton = new System.Windows.Forms.Button();
            this.AcptButton = new System.Windows.Forms.Button();
            this.dataGridViewIncidents = new System.Windows.Forms.DataGridView();
            this.IncidentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncidents)).BeginInit();
            this.SuspendLayout();
            // 
            // IncidentsbindingSource
            // 
            this.IncidentsbindingSource.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // comboPriority
            // 
            this.comboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Location = new System.Drawing.Point(320, 326);
            this.comboPriority.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(180, 28);
            this.comboPriority.TabIndex = 9;
            // 
            // textReason
            // 
            this.textReason.BackColor = System.Drawing.SystemColors.Window;
            this.textReason.Location = new System.Drawing.Point(846, 274);
            this.textReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textReason.Multiline = true;
            this.textReason.Name = "textReason";
            this.textReason.Size = new System.Drawing.Size(148, 29);
            this.textReason.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(682, 274);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rejection Reason";
            // 
            // textArea
            // 
            this.textArea.Location = new System.Drawing.Point(320, 269);
            this.textArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(148, 26);
            this.textArea.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 326);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Priority";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 274);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Area";
            // 
            // RejButton
            // 
            this.RejButton.Location = new System.Drawing.Point(866, 391);
            this.RejButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RejButton.Name = "RejButton";
            this.RejButton.Size = new System.Drawing.Size(112, 35);
            this.RejButton.TabIndex = 2;
            this.RejButton.Text = "Reject";
            this.RejButton.UseVisualStyleBackColor = true;
            this.RejButton.Click += new System.EventHandler(this.RejButton_Click);
            // 
            // AcptButton
            // 
            this.AcptButton.Location = new System.Drawing.Point(320, 391);
            this.AcptButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AcptButton.Name = "AcptButton";
            this.AcptButton.Size = new System.Drawing.Size(112, 35);
            this.AcptButton.TabIndex = 1;
            this.AcptButton.Text = "Accept";
            this.AcptButton.UseVisualStyleBackColor = true;
            this.AcptButton.Click += new System.EventHandler(this.AccpButton_Click);
            // 
            // dataGridViewIncidents
            // 
            this.dataGridViewIncidents.AutoGenerateColumns = false;
            this.dataGridViewIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncidents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IncidentId,
            this.Description,
            this.Department});
            this.dataGridViewIncidents.DataSource = this.IncidentsbindingSource;
            this.dataGridViewIncidents.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewIncidents.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewIncidents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewIncidents.Name = "dataGridViewIncidents";
            this.dataGridViewIncidents.RowHeadersWidth = 62;
            this.dataGridViewIncidents.Size = new System.Drawing.Size(1200, 231);
            this.dataGridViewIncidents.TabIndex = 0;
            this.dataGridViewIncidents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIncidents_CellContentClick);
            // 
            // IncidentId
            // 
            this.IncidentId.DataPropertyName = "Id";
            this.IncidentId.HeaderText = "Incident";
            this.IncidentId.MinimumWidth = 8;
            this.IncidentId.Name = "IncidentId";
            this.IncidentId.Width = 150;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 8;
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Department";
            this.Department.MinimumWidth = 8;
            this.Department.Name = "Department";
            this.Department.Width = 150;
            // 
            // ReviewIncidentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.comboPriority);
            this.Controls.Add(this.textReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RejButton);
            this.Controls.Add(this.AcptButton);
            this.Controls.Add(this.dataGridViewIncidents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReviewIncidentForm";
            this.Text = "Review Incident ";
            this.Load += new System.EventHandler(this.ReviewIncidentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncidents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource IncidentsbindingSource;
        private System.Windows.Forms.DataGridView dataGridViewIncidents;
        private System.Windows.Forms.Button AcptButton;
        private System.Windows.Forms.Button RejButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textReason;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncidentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
    }
}