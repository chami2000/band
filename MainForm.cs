using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace LTEBandControl
{
    public partial class MainForm : DarkForm
    {
        private RouterControl router;
        private readonly string[] availableBands = { "EUTRAN_BAND1", "EUTRAN_BAND3", "EUTRAN_BAND5", "EUTRAN_BAND38", "EUTRAN_BAND41" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToggleCredentialsVisibility(false);
        }

        private void ToggleCredentialsVisibility(bool visible)
        {
            panelCredentials.Visible = visible;
            btnConnect.Visible = visible;
        }

        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtRouterIp.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            router = new RouterControl(ip, username, password);
            if (await router.GetSessionIdAsync() != null)
            {
                lblStatus.Text = "Successfully connected to router";
                await UpdateCurrentBandsAsync();
                EnableBandControls(true);
            }
            else
            {
                lblStatus.Text = "Failed to connect to router";
            }
        }

        private async void BtnChangeBands_Click(object sender, EventArgs e)
        {
            var selectedBands = checkedListBoxBands.CheckedItems.Cast<string>().ToArray();
            if (selectedBands.Any())
            {
                if (await router.ChangeLTEBandsAsync(selectedBands))
                {
                    lblStatus.Text = "Successfully changed bands";
                    await UpdateCurrentBandsAsync();
                }
                else
                {
                    lblStatus.Text = "Failed to change bands";
                }
            }
            else
            {
                lblStatus.Text = "Please select at least one band";
            }
        }

        private async Task UpdateCurrentBandsAsync()
        {
            var currentBands = await router.GetCurrentBandsAsync();
            if (currentBands != null)
            {
                lblCurrentBands.Text = $"Current Bands: {string.Join(", ", currentBands.Select(b => b.Split('_').Last()))}";
                for (int i = 0; i < availableBands.Length; i++)
                {
                    checkedListBoxBands.SetItemChecked(i, currentBands.Contains(availableBands[i]));
                }
            }
            else
            {
                lblCurrentBands.Text = "Failed to fetch current bands";
            }
        }

        private void EnableBandControls(bool enable)
        {
            checkedListBoxBands.Enabled = enable;
            btnChangeBands.Enabled = enable;
        }

        private void BtnToggleCredentials_Click(object sender, EventArgs e)
        {
            ToggleCredentialsVisibility(!panelCredentials.Visible);
        }
    }
}
