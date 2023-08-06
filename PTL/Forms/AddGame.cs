using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PTL.Config;

namespace PTL.Forms
{
    public partial class AddGame : Form
    {
        public bool Custom = false;
        public bool PC98 = false;
        public bool UseThcrap = true;
        public GameEntry OutputGameEntry;
        public CustomGameEntry OutputCustomGameEntry;
        public Bitmap? GameIcon;
        private string OriginalName = string.Empty;
        private bool IconChanged = false;
        private string IconExtension = ".png";
        private ToolTip toolTip = new();
        public class AddGameEntry
        {
            public GameId id;
            public string name = string.Empty;
            public override string ToString()
            {
                return name;
            }
        }
        public AddGame(GameEntry gameEntry, ConfigObject config)
            : this(gameEntry, null, config)
        {
            Text = LocalizationManager.CurrentTranslation.EditGame;
            if (MainForm.CheckIfIconExists(Path.Combine(MainForm.GameIconsPath, $"{gameEntry.Id}"), out string ActualPath))
            {
                GameIcon = new Bitmap(ActualPath);
                GameImage.Image = GameIcon;
            }
        }
        public AddGame(CustomGameEntry customGameEntry, ConfigObject config)
            : this(null, customGameEntry, config)
        {
            Text = LocalizationManager.CurrentTranslation.EditGame;
            if (MainForm.CheckIfIconExists(Path.Combine(MainForm.CustomGameIconsPath, MainForm.CleanString(customGameEntry.Name)), out string ActualPath))
            {
                GameIcon = new Bitmap(ActualPath);
                GameImage.Image = GameIcon;
                IconExtension = Path.GetExtension(ActualPath);
            }
        }
        public AddGame(ConfigObject config)
            : this(null, null, config)
        { }
        private AddGame(GameEntry? gameEntry, CustomGameEntry? customGameEntry, ConfigObject config)
        {
            InitializeComponent();
            Text = LocalizationManager.CurrentTranslation.AddGame;
            GameLbl.Text = LocalizationManager.CurrentTranslation.Game;
            NameLbl.Text = LocalizationManager.CurrentTranslation.Name;
            GamePathLbl.Text = LocalizationManager.CurrentTranslation.GamePath;
            ConfigChk.Text = LocalizationManager.CurrentTranslation.UseConfigCustom;
            ConfigPathLbl.Text = LocalizationManager.CurrentTranslation.CustomPath;
            AdminChk.Text = LocalizationManager.CurrentTranslation.LaunchAsAdministrator;
            UseThcrapChk.Text = LocalizationManager.CurrentTranslation.LaunchWithThcrap;
            SaveBtn.Text = LocalizationManager.CurrentTranslation.Save;
            CancelBtn.Text = LocalizationManager.CurrentTranslation.Cancel;

            ConfigPathTextBox.BackColor = MainForm.DisabledColor;
            if (gameEntry != null)
            {
                Custom = false;
                GameCmbx.Enabled = false;
                GameCmbx.Visible = false;
                HiddenGameTextBox.Visible = true;
                HiddenGameTextBox.Text = GetFullGameName(gameEntry.Value.Id, config.NamePreset);
                GameLbl.Enabled = false;
                GamePathTextBox.Text = gameEntry.Value.GamePath;
                AdminChk.Checked = gameEntry.Value.RunAsAdmin;
                ConfigChk.Checked = gameEntry.Value.UseConfig;
                ConfigPathTextBox.Text = gameEntry.Value.ConfigPath;
                if (gameEntry.Value.PC98)
                {
                    PC98 = true;
                    UseThcrapChk.Enabled = false;
                    ConfigChk.Checked = false;
                    ConfigChk.Enabled = false;
                }
                else
                    UseThcrapChk.Checked = gameEntry.Value.UseThcrap;
            }
            else if (customGameEntry != null)
            {
                toolTip.SetToolTip(GameImage, $"{LocalizationManager.CurrentTranslation.GameImageToolTip}\n" +
                    $"{LocalizationManager.CurrentTranslation.GameImageToolTip2}");
                Custom = true;
                GameCmbx.Enabled = false;
                GameCmbx.Visible = false;
                HiddenGameTextBox.Visible = true;
                HiddenGameTextBox.Text = LocalizationManager.CurrentTranslation.Custom;
                GameLbl.Enabled = false;
                NameTextBox.Enabled = true;
                NameTextBox.Text = customGameEntry.Value.Name;
                NameTextBox.BackColor = MainForm.EnabledColor;
                NameLbl.Enabled = true;
                GamePathTextBox.Text = customGameEntry.Value.GamePath;
                AdminChk.Checked = customGameEntry.Value.RunAsAdmin;
                UseThcrapChk.Checked = customGameEntry.Value.UseThcrap;
                OriginalName = customGameEntry.Value.Name;
                ConfigChk.Checked = gameEntry.Value.UseConfig;
                ConfigPathTextBox.Text = gameEntry.Value.ConfigPath;
            }
            else
            {
                UseThcrap = config.UseThcrap;

                GameId start = GameId.Touhou1;
                if (!config.SupportPC98)
                {
                    if (config.UseThcrap)
                        UseThcrapChk.Checked = true;
                    start = GameId.Touhou6;
                }

                for (GameId i = start; i < (GameId)33; i++)
                {
                    if (config.GameEntries.FindIndex(x => x.Id == i) == -1)
                    {
                        AddGameEntry age = new()
                        {
                            id = i,
                            name = GetFullGameName(i, config.NamePreset)
                        };
                        GameCmbx.Items.Add(age);
                    }
                }

                GameCmbx.Items.Add(new AddGameEntry() { id = GameId.Custom, name = LocalizationManager.CurrentTranslation.Custom });
                GameCmbx.SelectedIndex = 0;
                GameCmbx_SelectionChangeCommitted(null, null);
            }
        }

        private void ConfigChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfigChk.Checked)
            {
                ConfigPathLbl.Enabled = true;
                ConfigPathTextBox.Enabled = true;
                ConfigPathTextBox.BackColor = MainForm.EnabledColor;
            }
            else
            {
                ConfigPathLbl.Enabled = false;
                ConfigPathTextBox.Enabled = false;
                ConfigPathTextBox.BackColor = MainForm.DisabledColor;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(GamePathTextBox.Text) || Custom && String.IsNullOrEmpty(NameTextBox.Text) || ConfigChk.Checked && String.IsNullOrEmpty(ConfigPathTextBox.Text))
                return;

            if (Custom)
            {
                OutputCustomGameEntry = new();
                OutputCustomGameEntry.GamePath = GamePathTextBox.Text;
                OutputCustomGameEntry.Name = NameTextBox.Text;
                OutputCustomGameEntry.UseThcrap = UseThcrapChk.Checked;
                OutputCustomGameEntry.RunAsAdmin = AdminChk.Checked;
                OutputCustomGameEntry.UseConfig = ConfigChk.Checked;
                OutputCustomGameEntry.ConfigPath = OutputCustomGameEntry.UseConfig ? ConfigPathTextBox.Text : string.Empty;
                if (OriginalName != string.Empty && OriginalName != OutputCustomGameEntry.Name)
                {
                    if (MainForm.CheckIfIconExists(Path.Combine(MainForm.CustomGameIconsPath, MainForm.CleanString(OriginalName)), out string ActualPath))
                    {
                        File.Move(ActualPath, Path.Combine(MainForm.CustomGameIconsPath, MainForm.CleanString(OutputCustomGameEntry.Name) + Path.GetExtension(ActualPath)));
                    }
                }
                else if (IconChanged)
                {
                    if (MainForm.CheckIfIconExists(Path.Combine(MainForm.CustomGameIconsPath, MainForm.CleanString(OutputCustomGameEntry.Name)), out string ActualPath))
                        File.Delete(ActualPath);
                    if (GameIcon != null)
                        GameIcon.Save(Path.Combine(MainForm.CustomGameIconsPath, MainForm.CleanString(OutputCustomGameEntry.Name) + IconExtension));
                }
            }
            else
            {
                OutputGameEntry = new();
                OutputGameEntry.GamePath = GamePathTextBox.Text;
                OutputGameEntry.RunAsAdmin = AdminChk.Checked;
                OutputGameEntry.UseThcrap = UseThcrapChk.Checked;
                OutputGameEntry.UseConfig = ConfigChk.Checked;
                OutputGameEntry.ConfigPath = OutputGameEntry.UseConfig ? ConfigPathTextBox.Text : string.Empty;
                AddGameEntry a = (AddGameEntry)GameCmbx.SelectedItem;
                OutputGameEntry.Id = a.id;
            }
            DialogResult = DialogResult.OK;
        }

        private void GameCmbx_SelectionChangeCommitted(object? sender, EventArgs? e)
        {
            if (GameCmbx.SelectedIndex != -1)
            {
                AddGameEntry age = (AddGameEntry)GameCmbx.SelectedItem;
                if (age.id == GameId.Custom)
                {
                    PC98 = false;
                    Custom = true;
                    NameTextBox.Enabled = true;
                    NameTextBox.BackColor = MainForm.EnabledColor;
                    NameLbl.Enabled = true;
                    UseThcrapChk.Enabled = true;
                    ConfigChk.Enabled = true;
                    ClearGameIcon();
                    toolTip.SetToolTip(GameImage, $"{LocalizationManager.CurrentTranslation.GameImageToolTip}\n" +
                    $"{LocalizationManager.CurrentTranslation.GameImageToolTip2}");
                    return;
                }
                else
                {
                    ClearGameIcon();
                    toolTip.SetToolTip(GameImage, null);
                    if (MainForm.CheckIfIconExists(Path.Combine(MainForm.GameIconsPath, $"{age.id}"), out string ActualPath))
                    {
                        GameIcon = new Bitmap(ActualPath);
                        GameImage.Image = GameIcon;
                    }
                    if (age.id < GameId.Touhou6)
                    {
                        PC98 = true;
                        UseThcrapChk.Checked = false;
                        UseThcrapChk.Enabled = false;
                        ConfigChk.Checked = false;
                        ConfigChk.Enabled = false;
                    }
                    else
                    {
                        PC98 = false;
                        UseThcrapChk.Enabled = true;
                        if (UseThcrap)
                            UseThcrapChk.Checked = true;
                        ConfigChk.Enabled = true;
                    }
                }
            }
            Custom = false;
            NameTextBox.Enabled = false;
            NameTextBox.BackColor = MainForm.DisabledColor;
            NameLbl.Enabled = false;
        }

        private void GamePathTextBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = LocalizationManager.CurrentTranslation.SelectYourHdi,
                Filter = PC98 ? $"{LocalizationManager.CurrentTranslation.HdiFile} " +
                $"|*.hdi|{LocalizationManager.CurrentTranslation.AllFiles} (*.*)|*.*"
                : $"{LocalizationManager.CurrentTranslation.ExeFile} |*.exe|{LocalizationManager.CurrentTranslation.AllFiles} (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                GamePathTextBox.Text = dialog.FileName;
            }
        }

        private void ConfigPathTextBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = LocalizationManager.CurrentTranslation.SelectYourConfig,
                Filter = $"{LocalizationManager.CurrentTranslation.ExeFile} |*.exe|{LocalizationManager.CurrentTranslation.AllFiles} (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ConfigPathTextBox.Text = dialog.FileName;
            }
        }

        private void GameImage_Click(object sender, EventArgs e)
        {
            if (Custom)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    ClearGameIcon();
                    IconChanged = true;
                }
                else
                {
                    OpenFileDialog dialog = new()
                    {
                        Title = LocalizationManager.CurrentTranslation.SelectAnIcon,
                        Filter = $"{LocalizationManager.CurrentTranslation.Bitmap}|*.png;*.jpg;*.bmp;.gif;*.ico|" +
                        $"{LocalizationManager.CurrentTranslation.AllFiles} (*.*)|*.*"
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ClearGameIcon();
                            GameIcon = new Bitmap(dialog.FileName);
                            GameImage.Image = GameIcon;
                            IconExtension = Path.GetExtension(dialog.FileName);
                            IconChanged = true;
                        }
                        catch { }
                    }
                }
            }
        }
        private void ClearGameIcon()
        {
            if (GameIcon != null)
            {
                GameIcon.Dispose();
                GameIcon = null;
            }
            if (GameImage.Image != null)
            {
                GameImage.Image.Dispose();
                GameImage.Image = null;
            }
        }
    }
}
