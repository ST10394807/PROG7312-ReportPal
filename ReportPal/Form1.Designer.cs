namespace ReportPal
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnIssues = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnServiceRequest = new System.Windows.Forms.Button();
            this.btnViewIssues = new System.Windows.Forms.Button();
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(272, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to ReportPal";
            // 
            // btnIssues
            // 
            this.btnIssues.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIssues.Location = new System.Drawing.Point(172, 91);
            this.btnIssues.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnIssues.MinimumSize = new System.Drawing.Size(0, 60);
            this.btnIssues.Name = "btnIssues";
            this.btnIssues.Size = new System.Drawing.Size(456, 60);
            this.btnIssues.TabIndex = 2;
            this.btnIssues.Text = "Report Issues";
            this.btnIssues.UseVisualStyleBackColor = true;
            this.btnIssues.Click += new System.EventHandler(this.btnIssues_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEvents.Enabled = false;
            this.btnEvents.Location = new System.Drawing.Point(172, 251);
            this.btnEvents.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnEvents.MinimumSize = new System.Drawing.Size(0, 60);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(456, 60);
            this.btnEvents.TabIndex = 4;
            this.btnEvents.Text = "Local Events and Announcements";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnServiceRequest
            // 
            this.btnServiceRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServiceRequest.Enabled = false;
            this.btnServiceRequest.Location = new System.Drawing.Point(172, 331);
            this.btnServiceRequest.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnServiceRequest.MinimumSize = new System.Drawing.Size(0, 60);
            this.btnServiceRequest.Name = "btnServiceRequest";
            this.btnServiceRequest.Size = new System.Drawing.Size(456, 60);
            this.btnServiceRequest.TabIndex = 5;
            this.btnServiceRequest.Text = "Service Request Status";
            this.btnServiceRequest.UseVisualStyleBackColor = true;
            this.btnServiceRequest.Click += new System.EventHandler(this.btnServiceRequest_Click);
            // 
            // btnViewIssues
            // 
            this.btnViewIssues.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewIssues.Location = new System.Drawing.Point(172, 171);
            this.btnViewIssues.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnViewIssues.MinimumSize = new System.Drawing.Size(0, 60);
            this.btnViewIssues.Name = "btnViewIssues";
            this.btnViewIssues.Size = new System.Drawing.Size(456, 60);
            this.btnViewIssues.TabIndex = 3;
            this.btnViewIssues.Text = "View Submitted Issues";
            this.btnViewIssues.UseVisualStyleBackColor = true;
            this.btnViewIssues.Click += new System.EventHandler(this.btnViewIssues_Click);
            // 
            // lblIntro
            // 
            this.lblIntro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(179, 49);
            this.lblIntro.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(442, 32);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "This app helps you report municipal issues in Pretoria. You can log a new issue, " +
    "check previous ones, or send a service request.";
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.Location = new System.Drawing.Point(175, 540);
            this.lblFooter.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(450, 16);
            this.lblFooter.TabIndex = 6;
            this.lblFooter.Text = "Tip: Use Settings (top menu) to change theme or language.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIntro, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnIssues, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnViewIssues, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEvents, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnServiceRequest, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblFooter, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 576);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Pal: Main Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIssues;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnServiceRequest;
        private System.Windows.Forms.Button btnViewIssues;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}
