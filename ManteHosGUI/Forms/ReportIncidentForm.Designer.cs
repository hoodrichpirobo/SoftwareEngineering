namespace ManteHos.Presentation.Forms
{
    partial class ReportIncidentForm
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
            this.dateField = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.serviceLabel = new System.Windows.Forms.Label();
            this.descriptionField = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.reportButton = new System.Windows.Forms.Button();
            this.serviceField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateField
            // 
            this.dateField.Checked = false;
            this.dateField.Location = new System.Drawing.Point(181, 59);
            this.dateField.Name = "dateField";
            this.dateField.Size = new System.Drawing.Size(201, 26);
            this.dateField.TabIndex = 0;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(68, 64);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(48, 20);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Date:";
            // 
            // serviceLabel
            // 
            this.serviceLabel.AutoSize = true;
            this.serviceLabel.Location = new System.Drawing.Point(68, 140);
            this.serviceLabel.Name = "serviceLabel";
            this.serviceLabel.Size = new System.Drawing.Size(65, 20);
            this.serviceLabel.TabIndex = 5;
            this.serviceLabel.Text = "Service:";
            // 
            // descriptionField
            // 
            this.descriptionField.Location = new System.Drawing.Point(181, 212);
            this.descriptionField.Name = "descriptionField";
            this.descriptionField.Size = new System.Drawing.Size(201, 104);
            this.descriptionField.TabIndex = 7;
            this.descriptionField.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(68, 215);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(93, 20);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Description:";
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(316, 426);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(100, 34);
            this.reportButton.TabIndex = 10;
            this.reportButton.Text = "&Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // serviceField
            // 
            this.serviceField.Location = new System.Drawing.Point(181, 134);
            this.serviceField.Name = "serviceField";
            this.serviceField.Size = new System.Drawing.Size(201, 26);
            this.serviceField.TabIndex = 11;
            // 
            // ReportIncidentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 496);
            this.Controls.Add(this.serviceField);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionField);
            this.Controls.Add(this.serviceLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateField);
            this.Name = "ReportIncidentForm";
            this.Text = "Report Incident";
            this.Load += new System.EventHandler(this.ReportIncidentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateField;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label serviceLabel;
        private System.Windows.Forms.RichTextBox descriptionField;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.TextBox serviceField;
    }
}