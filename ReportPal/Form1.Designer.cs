namespace ReportPal
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnIssues = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnServiceRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Menu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(501, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(495, 28);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Value = 20;
            // 
            // btnIssues
            // 
            this.btnIssues.Location = new System.Drawing.Point(89, 92);
            this.btnIssues.Margin = new System.Windows.Forms.Padding(4);
            this.btnIssues.Name = "btnIssues";
            this.btnIssues.Size = new System.Drawing.Size(335, 43);
            this.btnIssues.TabIndex = 3;
            this.btnIssues.Text = "Report Issues";
            this.btnIssues.UseVisualStyleBackColor = true;
            this.btnIssues.Click += new System.EventHandler(this.btnIssues_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.Enabled = false;
            this.btnEvents.Location = new System.Drawing.Point(89, 143);
            this.btnEvents.Margin = new System.Windows.Forms.Padding(4);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(335, 43);
            this.btnEvents.TabIndex = 4;
            this.btnEvents.Text = "Local Events and Announcements";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnServiceRequest
            // 
            this.btnServiceRequest.Enabled = false;
            this.btnServiceRequest.Location = new System.Drawing.Point(89, 194);
            this.btnServiceRequest.Margin = new System.Windows.Forms.Padding(4);
            this.btnServiceRequest.Name = "btnServiceRequest";
            this.btnServiceRequest.Size = new System.Drawing.Size(335, 43);
            this.btnServiceRequest.TabIndex = 5;
            this.btnServiceRequest.Text = "Service Request Status";
            this.btnServiceRequest.UseVisualStyleBackColor = true;
            this.btnServiceRequest.Click += new System.EventHandler(this.btnServiceRequest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 334);
            this.Controls.Add(this.btnServiceRequest);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnIssues);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Report Pal: Main Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnIssues;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnServiceRequest;
    }
}

