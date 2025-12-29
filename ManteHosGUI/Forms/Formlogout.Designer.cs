namespace ManteHos.Presentation.Forms
{
    partial class Formlogout
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.yes_logout = new System.Windows.Forms.Button();
            this.no_logout_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(235, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure that you want to Log Out?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "You will return to the main page";
            // 
            // yes_logout
            // 
            this.yes_logout.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.yes_logout.Location = new System.Drawing.Point(482, 191);
            this.yes_logout.Name = "yes_logout";
            this.yes_logout.Size = new System.Drawing.Size(75, 23);
            this.yes_logout.TabIndex = 3;
            this.yes_logout.Text = "Yes";
            this.yes_logout.UseVisualStyleBackColor = true;
            this.yes_logout.Click += new System.EventHandler(this.yes_logout_Click);
            // 
            // no_logout_button
            // 
            this.no_logout_button.Location = new System.Drawing.Point(239, 191);
            this.no_logout_button.Name = "no_logout_button";
            this.no_logout_button.Size = new System.Drawing.Size(75, 23);
            this.no_logout_button.TabIndex = 4;
            this.no_logout_button.Text = "No";
            this.no_logout_button.UseVisualStyleBackColor = true;
            this.no_logout_button.Click += new System.EventHandler(this.no_logout_button_Click);
            // 
            // Formlogout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.no_logout_button);
            this.Controls.Add(this.yes_logout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Formlogout";
            this.Text = "LogOut";
            this.Load += new System.EventHandler(this.Formlogout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button yes_logout;
        private System.Windows.Forms.Button no_logout_button;
    }
}