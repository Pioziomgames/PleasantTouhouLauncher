using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PTL.Config;

namespace PTL
{
    public partial class Settings : Form
    {
        public ConfigObject Config;

        public Settings(ConfigObject config)
        {
            Config = config;
            InitializeComponent();
            LocalizationManager.LoadTranslations();
            LocalizationManager.LoadTranslation(config.Language);
            LoadTranslation();
            string[] languages = LocalizationManager.GetLanguages();
            LanguageCmbx.Items.AddRange(languages);
            int index = Array.IndexOf(languages, config.Language);
            if (index == -1)
                index = Array.IndexOf(languages, "English");
            LanguageCmbx.SelectedIndex = index;

            UseThcrapChk.Checked = Config.UseThcrap;
            ReimportChk.Checked = Config.ReimportGameOnLaunch;
            ThcrapTextBox.Text = Config.ThcrapPath;
            NekoTextBox.Text = Config.NekoPath;
            NameCmbx.SelectedIndex = Config.NamePreset;
            UseNekoChk.Checked = Config.SupportPC98;
            CloseOnLaunchChk.Checked = Config.CloseOnLaunch;
            CustomFirstChk.Checked = Config.CustomFirst;
        }
        private void LoadTranslation()
        {
            Text = LocalizationManager.CurrentTranslation.Settings;
            UseThcrapChk.Text = LocalizationManager.CurrentTranslation.LaunchGamesWithThcrap;
            ThcrapPathLbl.Text = LocalizationManager.CurrentTranslation.ThcrapPath;
            UseNekoChk.Text = LocalizationManager.CurrentTranslation.SupportPC98Games;
            NekoLbl.Text = LocalizationManager.CurrentTranslation.Neko2Path;
            NamePresetLbl.Text = LocalizationManager.CurrentTranslation.NamePreset;
            CloseOnLaunchChk.Text = LocalizationManager.CurrentTranslation.CloseLauncherOnGameStart;
            CustomFirstChk.Text = LocalizationManager.CurrentTranslation.DisplayCustomGamesBeforeOfficialOnes;
            ImportThcrapBtn.Text = LocalizationManager.CurrentTranslation.ImportThcrapGames;
            ReimportChk.Text = LocalizationManager.CurrentTranslation.ReimportThcrapGamesOnLaunch;
            if (LocalizationManager.CurrentTranslation.LanguageName == "English")
                LanguageLbl.Text = "Language:";
            else
                LanguageLbl.Text = $"{LocalizationManager.CurrentTranslation.Language}\\Language:";
        }
        private void UseThcrapChk_CheckedChanged(object sender, EventArgs e)
        {
            if (UseThcrapChk.Checked)
            {
                ThcrapTextBox.Enabled = true;
                ThcrapTextBox.BackColor = MainForm.EnabledColor;
                ThcrapPathLbl.Enabled = true;
                ReimportChk.Enabled = true;
                Config.UseThcrap = true;
                ReimportChk.Enabled = true;
            }
            else
            {
                ThcrapTextBox.Enabled = false;
                ThcrapTextBox.BackColor = MainForm.DisabledColor;
                ThcrapPathLbl.Enabled = false;
                ReimportChk.Enabled = false;
                Config.UseThcrap = false;
                ReimportChk.Enabled = false;
                ReimportChk.Checked = false;
            }
        }
        private void ThcrapTextBox_Click(object? sender, EventArgs? e)
        {
            OpenFileDialog dialog = new()
            {
                Title = LocalizationManager.CurrentTranslation.SelectThcrapExe,
                Filter = $"thcrap_loader.exe|*thcrap_loader.exe|{LocalizationManager.CurrentTranslation.AllFiles} (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Config.ThcrapPath = dialog.FileName;
                string? Dir = Path.GetDirectoryName(dialog.FileName);
                if (Dir == null) { return; }
                if (Dir.ToLower().EndsWith("\\bin"))
                {
                    string otherExePath = Dir;
                    otherExePath = Path.Combine(otherExePath.Substring(0, otherExePath.Length - 3), "thcrap_loader.exe");
                    if (File.Exists(otherExePath))
                        Config.ThcrapPath = otherExePath;
                }

                ThcrapTextBox.Text = Config.ThcrapPath;
            }
        }
        private void UseNekoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (UseNekoChk.Checked)
            {
                NekoLbl.Enabled = true;
                NekoTextBox.Enabled = true;
                NekoTextBox.BackColor = MainForm.EnabledColor;
                Config.SupportPC98 = true;
            }
            else
            {
                NekoLbl.Enabled = false;
                NekoTextBox.Enabled = false;
                NekoTextBox.BackColor = MainForm.DisabledColor;
                Config.SupportPC98 = false;
            }
        }
        private void NekoTextBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = LocalizationManager.CurrentTranslation.SelectNekoProject2Exe,
                Filter = $"{LocalizationManager.CurrentTranslation.NekoProject2ExeFile} |*.exe|" +
                $"{LocalizationManager.CurrentTranslation.AllFiles} (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Config.NekoPath = dialog.FileName;
                NekoTextBox.Text = dialog.FileName;
            }
        }
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.NamePreset = NameCmbx.SelectedIndex;
            if (String.IsNullOrEmpty(Config.ThcrapPath))
                Config.UseThcrap = false;
        }

        private void ImportThcrapBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Config.ThcrapPath))
            {
                UseThcrapChk.Checked = true;
                ThcrapTextBox_Click(null, null);
            }
            if (!String.IsNullOrEmpty(Config.ThcrapPath))
            {
                UseThcrapChk.Checked = true;
                int AddedGames = MainForm.ImportThcrapGames(ref Config);
                MessageBox.Show(AddedGames > 0 ? String.Format(LocalizationManager.CurrentTranslation.ImportedGames, AddedGames)
                    : LocalizationManager.CurrentTranslation.UnableToImport, LocalizationManager.CurrentTranslation.GameImport);
            }
        }

        private void ReimportChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ReimportChk.Checked)
                Config.ReimportGameOnLaunch = true;
            else
                Config.ReimportGameOnLaunch = false;
        }

        private void CloseOnLaunchChk_CheckedChanged(object sender, EventArgs e)
        {
            if (CloseOnLaunchChk.Checked)
                Config.CloseOnLaunch = true;
            else
                Config.CloseOnLaunch = false;
        }

        private void CustomFirstChk_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomFirstChk.Checked)
                Config.CustomFirst = true;
            else
                Config.CustomFirst = false;
        }

        private void LanguageCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageCmbx.SelectedIndex != -1)
            {
                try
                {
                    string lang = LanguageCmbx.GetItemText(LanguageCmbx.SelectedItem);
                    LocalizationManager.LoadTranslation(lang);
                    Config.Language = lang;
                }
                catch
                {
                    Config.Language = "English";
                    LocalizationManager.LoadTranslation("English");
                }
                LoadTranslation();
            }
        }
    }
}
