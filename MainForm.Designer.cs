namespace LTEBandControl
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            this.panelCredentials = new System.Windows.Forms.Panel();
            this.txtPassword = new DarkUI.Controls.DarkTextBox();
            this.txtUsername = new DarkUI.Controls.DarkTextBox();
            this.txtRouterIp = new DarkUI.Controls.DarkTextBox();
            this.lblPassword = new DarkUI.Controls.DarkLabel();
            this.lblUsername = new DarkUI.Controls.DarkLabel();
            this.lblRouterIp = new DarkUI.Controls.DarkLabel();
            this.btnConnect = new DarkUI.Controls.DarkButton();
            this.btnToggleCredentials = new DarkUI.Controls.DarkButton();
            this.lblSelectBands = new DarkUI.Controls.DarkLabel();
            this.checkedListBoxBands = new System.Windows.Forms.CheckedListBox();
            this.btnChangeBands = new DarkUI.Controls.DarkButton();
            this.lblCurrentBands = new DarkUI.Controls.DarkLabel();
            this.lblStatus = new DarkUI.Controls.DarkLabel();
            this.panelCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCredentials
            // 
            this.panelCredentials.Controls.Add(this.txtPassword);
            this.panelCredentials.Controls.Add(this.txtUsername);
            this.panelCredentials.Controls.Add(this.txtRouterIp);
            this.panelCredentials.Controls.Add(this.lblPassword);
            this.panelCredentials.Controls.Add(this.lblUsername);
            this.panelCredentials.Controls.Add(this.lblRouterIp);
            this.panelCredentials.Location = new System.Drawing.Point(12, 12);
            this.panelCredentials.Name = "panelCredentials";
            this.panelCredentials.Size = new System.Drawing.Size(260, 100);
            this.panelCredentials.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(85, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(160, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(85, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(160, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // txtRouterIp
            // 
            this.txtRouterIp.Location = new System.Drawing.Point(85, 10);
            this.txtRouterIp.Name = "txtRouterIp";
            this.txtRouterIp.Size = new System.Drawing.Size(160, 20);
            this.txtRouterIp.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(15, 40);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // lblRouterIp
            // 
            this.lblRouterIp.AutoSize = true;
            this.lblRouterIp.Location = new System.Drawing.Point(15, 10);
            this.lblRouterIp.Name = "lblRouterIp";
            this.lblRouterIp.Size = new System.Drawing.Size(54, 13);
            this.lblRouterIp.TabIndex = 0;
            this.lblRouterIp.Text = "Router IP:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 118);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(260, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnToggleCredentials
            // 
            this.btnToggleCredentials.Location = new System.Drawing.Point(12, 147);
            this.btnToggleCredentials.Name = "btnToggleCredentials";
            this.btnToggleCredentials.Size = new System.Drawing.Size(260, 23);
            this.btnToggleCredentials.TabIndex = 2;
            this.btnToggleCredentials.Text = "Toggle Credentials";
            this.btnToggleCredentials.Click += new System.EventHandler(this.BtnToggleCredentials_Click);
            // 
            // lblSelectBands
            // 
            this.lblSelectBands.AutoSize = true;
            this.lblSelectBands.Location = new System.Drawing.Point(12, 173);
            this.lblSelectBands.Name = "lblSelectBands";
            this.lblSelectBands.Size = new System.Drawing.Size(91, 13);
            this.lblSelectBands.TabIndex = 3;
            this.lblSelectBands.Text = "Select LTE Bands:";
            // 
            // checkedListBoxBands
            // 
            this.checkedListBoxBands.FormattingEnabled = true;
            this.checkedListBoxBands.Items.AddRange(new object[] {
            "Band 1",
            "Band 3",
            "Band 5",
            "Band 38",
            "Band 41"});
            this.checkedListBoxBands.Location = new System.Drawing.Point(12, 189);
            this.checkedListBoxBands.Name = "checkedListBoxBands";
            this.checkedListBoxBands.Size = new System.Drawing.Size(260, 79);
            this.checkedListBoxBands.TabIndex = 4;
            // 
            // btnChangeBands
            // 
            this.btnChangeBands.Location = new System.Drawing.Point(12, 274);
            this.btnChangeBands.Name = "btnChangeBands";
            this.btnChangeBands.Size = new System.Drawing.Size(260, 23);
            this.btnChangeBands.TabIndex = 5;
            this.btnChangeBands.Text = "Change Bands";
            this.btnChangeBands.Click += new System.EventHandler(this.BtnChangeBands_Click);
            // 
            // lblCurrentBands
            // 
            this.lblCurrentBands.AutoSize = true;
            this.lblCurrentBands.Location = new System.Drawing.Point(12, 300);
            this.lblCurrentBands.Name = "lblCurrentBands";
            this.lblCurrentBands.Size = new System.Drawing.Size(77, 13);
            this.lblCurrentBands.TabIndex = 6;
            this.lblCurrentBands.Text = "Current Bands:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 320);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 341);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCurrentBands);
            this.Controls.Add(this.btnChangeBands);
            this.Controls.Add(this.checkedListBoxBands);
            this.Controls.Add(this.lblSelectBands);
            this.Controls.Add(this.btnToggleCredentials);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.panelCredentials);
            this.Name = "MainForm";
            this.Text = "LTE Band Control";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelCredentials.ResumeLayout(false);
            this.panelCredentials.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelCredentials;
        private DarkUI.Controls.DarkTextBox txtPassword;
        private DarkUI.Controls.DarkTextBox txtUsername;
        private DarkUI.Controls.DarkTextBox txtRouterIp;
        private DarkUI.Controls.DarkLabel lblPassword;
        private DarkUI.Controls.DarkLabel lblUsername;
        private DarkUI.Controls.DarkLabel lblRouterIp;
        private DarkUI.Controls.DarkButton btnConnect;
        private DarkUI.Controls.DarkButton btnToggleCredentials;
        private DarkUI.Controls.DarkLabel lblSelectBands;
        private System.Windows.Forms.CheckedListBox checkedListBoxBands;
        private DarkUI.Controls.DarkButton btnChangeBands;
        private DarkUI.Controls.DarkLabel lblCurrentBands;
        private DarkUI.Controls.DarkLabel lblStatus;
    }
}
