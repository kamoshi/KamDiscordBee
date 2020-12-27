using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicBeePlugin
{
    public partial class SettingsWindow : Form
    {
        private readonly Plugin plugin;
        private readonly Settings settings;

        internal SettingsWindow(Plugin plugin, Settings settings)
        {
            this.plugin = plugin;
            this.settings = settings;
            InitializeComponent();
        }

        private void UpdateFormData(Settings settings)
        {
            textBoxAppId.Text = settings.ApplicationId;

            // Image stuff
            textBoxLargeImageDetail.Text = settings.ImageDetail;
            checkBoxUseCustomAssetKey.Checked = settings.ImageUseAssetKey;
            textBoxAssetKey.Text = settings.ImageAssetKey;

            textBoxAppId.Enabled = checkBoxUseCustomAssetKey.Checked;
            textBoxAssetKey.Enabled = checkBoxUseCustomAssetKey.Checked;

            // Info stuff
            textBoxTopLine.Text = settings.TopLine;
            textBoxBottomLine.Text = settings.BottomLine;
            checkBoxTimeShow.Checked = settings.ShowTime;
            checkBoxTimeShowRemaining.Checked = settings.ShowRemainingTime;
            checkBoxTrackNoCount.Checked = settings.ShowTrackNumber;

            checkBoxTimeShowRemaining.Enabled = checkBoxTimeShow.Checked;
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            UpdateFormData(settings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.ApplicationId = textBoxAppId.Text;
            // image
            settings.ImageDetail = textBoxLargeImageDetail.Text;
            settings.ImageUseAssetKey = checkBoxUseCustomAssetKey.Checked;
            settings.ImageAssetKey = textBoxAssetKey.Text;

            // info
            settings.TopLine = textBoxTopLine.Text;
            settings.BottomLine = textBoxBottomLine.Text;
            settings.ShowTime = checkBoxTimeShow.Checked;
            settings.ShowRemainingTime = checkBoxTimeShowRemaining.Checked;
            settings.ShowTrackNumber = checkBoxTrackNoCount.Checked;

            // save
            plugin.SaveSettings();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLargeImageDetail_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxUseCustomAssetKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAssetKey.Enabled = checkBoxUseCustomAssetKey.Checked;
            textBoxAppId.Enabled = checkBoxUseCustomAssetKey.Checked;
        }

        private void checkBoxTimeShow_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTimeShowRemaining.Enabled = checkBoxTimeShow.Checked;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonDefaults_Click(object sender, EventArgs e)
        {
            UpdateFormData(new Settings());
        }

        private void textBoxAppId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
