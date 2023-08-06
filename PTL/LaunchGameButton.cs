using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static PTL.Config;

namespace PTL
{
    public class LaunchGameButton : UserControl
    {
        private Button mainButton;
        private Button? settingsButton;
        private GameEntry? Entry;
        private CustomGameEntry? CustomEntry;
        private readonly ConfigObject Config;
        private readonly Bitmap? ButtonBG;
        public int FontSize { get {return fontSize; } set { fontSize = value; mainButton.Font = new Font("Arial", value); } }
        private int fontSize = 14;
        public new void Dispose()
        {
            ButtonBG?.Dispose();
            mainButton.Image?.Dispose();
            Entry = null;
            CustomEntry = null;
            settingsButton = null;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LaunchGameButton(ref ConfigObject config, Size size, GameEntry entry, Bitmap? buttonBG)
        {
            Config = config;
            Text = GetFullGameName(entry.Id, Config.NamePreset);
            ButtonBG = buttonBG;
            Size = size;
            Entry = entry;
            InitializeComponents(Text, size);
        }
        public LaunchGameButton(ref ConfigObject config, Size size, CustomGameEntry entry, Bitmap? buttonBG)
        {
            Config = config;
            Text = entry.Name;
            ButtonBG = buttonBG;
            Size = size;
            CustomEntry = entry;
            InitializeComponents(Text, size);
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private void InitializeComponents(string ButtonText, Size size)
        {
            TabStop = false;
            Margin = new Padding(5);
            mainButton = new Button
            {
                Size = size,
                Text = ButtonText,
                ForeColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", FontSize),
                BackgroundImageLayout = ImageLayout.Stretch,
                Dock = DockStyle.Fill,
                TabStop = false
            };
            mainButton.Click += (sender, e) => OnMainButtonClick(e);
            mainButton.Paint += (sender, e) => { if (sender != null) OutlinePaint(sender, e); };

            if (ButtonBG != null )
                mainButton.BackgroundImage = ButtonBG;
            
            if ((Entry != null && Entry.Value.UseConfig) || (CustomEntry != null && CustomEntry.Value.UseConfig))
            {
                settingsButton = new Button
                {
                    Size = size / 4,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Padding = new Padding(0),
                    BackColor = Color.Transparent,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackgroundImage = PTL.Properties.Resources.cog,
                };
                settingsButton.Click += (sender, e) => OnSettingsButtonClick(e);
                settingsButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                settingsButton.FlatAppearance.CheckedBackColor = Color.Transparent;
                settingsButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

                settingsButton.MouseEnter += (sender, e) => settingsButton.ForeColor = Color.Gray;
                settingsButton.MouseLeave += (sender, e) => settingsButton.ForeColor = Color.White;
                mainButton.Controls.Add(settingsButton);
                settingsButton.GotFocus += (sender, e) => this.ActiveControl = null;
            }
            this.Controls.Add(mainButton);
            SetScale(size);
        }
        public void LaunchGame()
        {
            OnMainButtonClick(null);
        }
        private void OutlinePaint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            e.Graphics.Clear(button.BackColor);
            if (button.BackgroundImage != null)
            {
                e.Graphics.DrawImage(button.BackgroundImage, button.ClientRectangle);
            }

            // Draw a small white border around the button
            Rectangle borderRect = button.ClientRectangle;
            borderRect.Inflate(-1, -1);
            using (Pen whiteBorderPen = new(button.Focused ? Color.Black : Color.White, button.Focused ? 8 : 2))
            {
                e.Graphics.DrawRectangle(whiteBorderPen, borderRect);
            }

            Size textBounds = new(button.Width - 10, button.Height - 10);
            Rectangle textRect = new(Point.Empty, textBounds);

            StringFormat format = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.Word
            };
            GraphicsPath outlinePath = new();
            outlinePath.AddString(button.Text, button.Font.FontFamily, (int)button.Font.Style, button.Font.Size, textRect, format);

            // Draw the outline
            using (Pen outlinePen = new(Color.Black, 2))
            {
                outlinePen.LineJoin = LineJoin.Round;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(outlinePen, outlinePath);
            }

            // Draw the text
            using SolidBrush fillBrush = new(Color.White);
            e.Graphics.FillPath(fillBrush, outlinePath);
        }
        protected virtual void OnMainButtonClick(EventArgs? e)
        {
            if (CustomEntry != null)
            {
                if (CustomEntry.Value.UseThcrap && Config.UseThcrap)
                    Run(Config.ThcrapPath, $"{Config.ThcrapProfile}.js \"{CustomEntry.Value.GamePath}\"", CustomEntry.Value.RunAsAdmin);
                else
                    Run(CustomEntry.Value.GamePath, RunAsAdmin: CustomEntry.Value.RunAsAdmin);
            }
            else if (Entry != null && !Entry.Value.PC98)
            {
                if (Entry.Value.UseThcrap && Config.UseThcrap)
                    Run(Config.ThcrapPath, $"{Config.ThcrapProfile}.js \"{Entry.Value.GamePath}\"", Entry.Value.RunAsAdmin);
                else
                    Run(Entry.Value.GamePath, RunAsAdmin: Entry.Value.RunAsAdmin);
            }
            else if (Entry != null)
            {
                if (Config.SupportPC98 && !String.IsNullOrWhiteSpace(Config.NekoPath))
                {
                    EditNekoConfig(Config.NekoPath, Entry.Value.GamePath);
                    Run(Config.NekoPath);
                }
                else
                {
                    MessageBox.Show(LocalizationManager.CurrentTranslation.CannotLaunchPC98Games, LocalizationManager.CurrentTranslation.Error);
                    return;
                }
            }
            ActiveControl = null;
            if (Config.CloseOnLaunch)
                Application.Exit();
        }
        protected virtual void OnSettingsButtonClick(EventArgs e)
        {
            if (CustomEntry != null)
            {
                if (CustomEntry.Value.UseThcrap && Config.UseThcrap)
                    Run(Config.ThcrapPath, $"{Config.ThcrapProfile}.js \"{CustomEntry.Value.ConfigPath}\"", CustomEntry.Value.RunAsAdmin);
                else
                    Run(CustomEntry.Value.ConfigPath, RunAsAdmin: CustomEntry.Value.RunAsAdmin);
            }
            else if (Entry != null)
            {
                if (Entry.Value.UseThcrap && Config.UseThcrap)
                    Run(Config.ThcrapPath, $"{Config.ThcrapProfile}.js \"{Entry.Value.ConfigPath}\"", Entry.Value.RunAsAdmin);
                else
                    Run(Entry.Value.ConfigPath, RunAsAdmin: Entry.Value.RunAsAdmin);
            }
            ActiveControl = null;
        }
        private static void Run(string path, string args = "", bool RunAsAdmin = false)
        {
            try
            {
                ProcessStartInfo startInfo = new()
                {
                    UseShellExecute = true,
                    FileName = path,
                    Arguments = args,
                    WorkingDirectory = Path.GetDirectoryName(path),
                    Verb = RunAsAdmin ? "runas" : string.Empty
                };

                Process.Start(path, args);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.Message.Contains("The requested operation requires elevation"))
                {
                    ProcessStartInfo startInfo = new()
                    {
                        UseShellExecute = true,
                        FileName = path,
                        Arguments = args,
                        WorkingDirectory = Path.GetDirectoryName(path),
                        Verb = "runas"
                    };
                    try
                    {
                        Process.Start(startInfo);
                    }
                    catch
                    {
                    }
                }
            }
        }
        private static void EditNekoConfig(string path, string hdi)
        {
            try
            {
                string ConfigPath = path[..^3] + "ini";
                string[] ConfigFile = File.ReadAllLines(ConfigPath);
                for (int i = 0; i < ConfigFile.Length; i++)
                {
                    if (ConfigFile[i].Contains("HDfolder="))
                        ConfigFile[i] = "HDfolder=" + hdi;
                    else if (ConfigFile[i].Contains("HDD1FILE="))
                        ConfigFile[i] = "HDD1FILE=" + hdi;
                }
                File.WriteAllLines(ConfigPath, ConfigFile);
            } catch { }
        }
        public void SetScale(Size size)
        {
            this.Size = size;
            mainButton.Size = size;
            if (settingsButton != null)
            {
                settingsButton.Size = size / 4;
                settingsButton.Location = new Point(mainButton.Width - settingsButton.Width - settingsButton.Margin.Right,
                                                    mainButton.Height - settingsButton.Height - settingsButton.Margin.Bottom);
            }
        }
    }
}
