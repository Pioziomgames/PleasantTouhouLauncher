using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Xml.Linq;
using static PTL.Config;

namespace PTL
{
    public partial class MainForm : Form
    {
        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        public static readonly string GameIconsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameIcons");
        public static readonly string CustomGameIconsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CustomGameIcons");
        public static readonly string TranslationsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Translations");
        public static readonly Color EnabledColor = Color.FromArgb(58, 65, 65);
        public static readonly Color DisabledColor = Color.FromArgb(30, 30, 30);
        private static ConfigObject config = ConfigObject.Read(ConfigPath);
        private static readonly ToolTip toolTip = new();
        public MainForm()
        {
            InitializeComponent();
            ImportThcrapProfiles();
            if (config.ReimportGameOnLaunch)
                ImportThcrapGames(ref config);
            LocalizationManager.LoadTranslations();
            LocalizationManager.LoadTranslation(config.Language);
            LoadTranslation();
            CreateButtons();
        }
        private void LoadTranslation()
        {
            toolTip.SetToolTip(RandomBtn, LocalizationManager.CurrentTranslation.RandomToolTip);
            toolTip.SetToolTip(PlusBtn, LocalizationManager.CurrentTranslation.IconScaleUpToolTip);
            toolTip.SetToolTip(MinusBtn, LocalizationManager.CurrentTranslation.IconScaleDownToolTip);
            toolTip.SetToolTip(FontPlusBtn, LocalizationManager.CurrentTranslation.FontScaleUpToolTip);
            toolTip.SetToolTip(FontMinusBtn, LocalizationManager.CurrentTranslation.FontScaleDownToolTip);
            toolTip.SetToolTip(GithubBtn, LocalizationManager.CurrentTranslation.GithubToolTip);
            toolTip.SetToolTip(GamesBtn, LocalizationManager.CurrentTranslation.GamesToolTip);
            GamesBtn.Text = LocalizationManager.CurrentTranslation.Games;
            toolTip.SetToolTip(SettingsBtn, LocalizationManager.CurrentTranslation.SettingsToolTip);
            SettingsBtn.Text = LocalizationManager.CurrentTranslation.Settings;
            ThcrapProfileLbl.Text = LocalizationManager.CurrentTranslation.ThcrapProfile;
        }
        public static int ImportThcrapGames(ref ConfigObject Config)
        {
            int AddedGamesCount = 0;
            string? dir = Path.GetDirectoryName(Config.ThcrapPath);
            if (dir == null)
                return AddedGamesCount;
            string ThcrapConfigPath = Path.Combine(dir, "config\\games.js");
            if (File.Exists(ThcrapConfigPath))
            {
                ThcrapGames? games = JsonConvert.DeserializeObject<ThcrapGames>(File.ReadAllText(ThcrapConfigPath));
                if (games != null)
                {
                    if (!string.IsNullOrEmpty(games.th06))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou6,
                            GamePath = games.th06,
                            UseConfig = !string.IsNullOrEmpty(games.th06_custom),
                            ConfigPath = games.th06_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th07))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou7,
                            GamePath = games.th07,
                            UseConfig = !string.IsNullOrEmpty(games.th07_custom),
                            ConfigPath = games.th07_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th075))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou75,
                            GamePath = games.th075,
                            UseConfig = !string.IsNullOrEmpty(games.th075_custom),
                            ConfigPath = games.th075_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th08))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou8,
                            GamePath = games.th08,
                            UseConfig = !string.IsNullOrEmpty(games.th08_custom),
                            ConfigPath = games.th08_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th09))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou9,
                            GamePath = games.th09,
                            UseConfig = !string.IsNullOrEmpty(games.th09_custom),
                            ConfigPath = games.th09_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th095))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou95,
                            GamePath = games.th095,
                            UseConfig = !string.IsNullOrEmpty(games.th095_custom),
                            ConfigPath = games.th095_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th10))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou10,
                            GamePath = games.th10,
                            UseConfig = !string.IsNullOrEmpty(games.th10_custom),
                            ConfigPath = games.th10_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th105))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou105,
                            GamePath = games.th105,
                            UseConfig = !string.IsNullOrEmpty(games.th105_custom),
                            ConfigPath = games.th105_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th11))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou11,
                            GamePath = games.th11,
                            UseConfig = !string.IsNullOrEmpty(games.th11_custom),
                            ConfigPath = games.th11_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th12))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou12,
                            GamePath = games.th12,
                            UseConfig = !string.IsNullOrEmpty(games.th12_custom),
                            ConfigPath = games.th12_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th123))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou123,
                            GamePath = games.th123,
                            UseConfig = !string.IsNullOrEmpty(games.th123_custom),
                            ConfigPath = games.th123_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th125))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou125,
                            GamePath = games.th125,
                            UseConfig = !string.IsNullOrEmpty(games.th125_custom),
                            ConfigPath = games.th125_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th128))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou128,
                            GamePath = games.th128,
                            UseConfig = !string.IsNullOrEmpty(games.th128_custom),
                            ConfigPath = games.th128_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th13))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou13,
                            GamePath = games.th13,
                            UseConfig = !string.IsNullOrEmpty(games.th13_custom),
                            ConfigPath = games.th13_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th135))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou135,
                            GamePath = games.th135,
                            UseConfig = !string.IsNullOrEmpty(games.th135_custom),
                            ConfigPath = games.th135_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th14))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou14,
                            GamePath = games.th14,
                            UseConfig = !string.IsNullOrEmpty(games.th14_custom),
                            ConfigPath = games.th14_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th143))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou143,
                            GamePath = games.th143,
                            UseConfig = !string.IsNullOrEmpty(games.th143_custom),
                            ConfigPath = games.th143_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th145))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou145,
                            GamePath = games.th145,
                            UseConfig = !string.IsNullOrEmpty(games.th145_custom),
                            ConfigPath = games.th145_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th15))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou15,
                            GamePath = games.th15,
                            UseConfig = !string.IsNullOrEmpty(games.th15_custom),
                            ConfigPath = games.th15_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th155))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou155,
                            GamePath = games.th155,
                            UseConfig = !string.IsNullOrEmpty(games.th155_custom),
                            ConfigPath = games.th155_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th16))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou16,
                            GamePath = games.th16,
                            UseConfig = !string.IsNullOrEmpty(games.th16_custom),
                            ConfigPath = games.th16_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th165))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou165,
                            GamePath = games.th165,
                            UseConfig = !string.IsNullOrEmpty(games.th165_custom),
                            ConfigPath = games.th165_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th17))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou17,
                            GamePath = games.th17,
                            UseConfig = !string.IsNullOrEmpty(games.th17_custom),
                            ConfigPath = games.th17_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th18))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou18,
                            GamePath = games.th18,
                            UseConfig = !string.IsNullOrEmpty(games.th18_custom),
                            ConfigPath = games.th18_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th185))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou185,
                            GamePath = games.th185,
                            UseConfig = !string.IsNullOrEmpty(games.th185_custom),
                            ConfigPath = games.th185_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    if (!string.IsNullOrEmpty(games.th19))
                    {
                        GameEntry game = new()
                        {
                            UseThcrap = true,
                            Id = GameId.Touhou19,
                            GamePath = games.th19,
                            UseConfig = !string.IsNullOrEmpty(games.th19_custom),
                            ConfigPath = games.th19_custom
                        };
                        Config.AddGame(game); AddedGamesCount++;
                    }
                    Config.SortGames();
                }
            }
            return AddedGamesCount;
        }
        private void ImportThcrapProfiles()
        {
            ThcrapProfileBox.Items.Clear();
            if (config.UseThcrap && !String.IsNullOrEmpty(config.ThcrapPath))
            {
                string? Dir = Path.GetDirectoryName(config.ThcrapPath);
                if (Dir == null)
                    return;
                string ConfigDir = Path.Combine(Dir, "config");

                if (Directory.Exists(ConfigDir))
                {
                    IEnumerable<string> files = Directory.EnumerateFiles(ConfigDir, "*.js");

                    foreach (string filePath in files)
                    {
                        try
                        {
                            string fileContent = File.ReadAllText(filePath);

                            if (fileContent.Contains("\"patches\""))
                            {
                                ThcrapProfileBox.Items.Add(Path.GetFileNameWithoutExtension(filePath));
                            }
                        }
                        catch { }
                    }
                    if (ThcrapProfileBox.Items.Count > 0)
                    {
                        ThcrapProfileLbl.Enabled = true;
                        ThcrapProfileBox.Enabled = true;
                        int selIndex = ThcrapProfileBox.Items.IndexOf(config.ThcrapProfile);
                        if (selIndex != -1)
                            ThcrapProfileBox.SelectedIndex = selIndex;
                        else
                        {
                            ThcrapProfileBox.SelectedIndex = 0;
                            config.ThcrapProfile = ThcrapProfileBox.GetItemText(ThcrapProfileBox.SelectedItem);
                        }
                        return;
                    }

                }
            }
            config.UseThcrap = false;
            ThcrapProfileLbl.Enabled = false;
            ThcrapProfileBox.Enabled = false;
        }
        private void CreateButtons()
        {
            ClearButtons();

            List<LaunchGameButton> GameButtons = new();
            for (int i = 0; i < config.GameEntries.Count; i++)
            {
                if (!config.GameEntries[i].PC98 || (config.GameEntries[i].PC98 && config.SupportPC98))
                {
                    LaunchGameButton button = new(ref config,
                        new Size(config.IconScale * 15, config.IconScale * 15),
                        config.GameEntries[i],
                        GetGameIcon(config.GameEntries[i].Id))
                    {
                        FontSize = config.FontSize
                    };
                    GameButtons.Add(button);
                }
            }
            List<LaunchGameButton> CustomGameButtons = new();

            for (int i = 0; i < config.CustomGameEntries.Count; i++)
            {
                LaunchGameButton button = new(ref config,
                            new Size(config.IconScale * 15, config.IconScale * 15),
                            config.CustomGameEntries[i],
                            GetCustomGameIcon(config.CustomGameEntries[i].Name))
                {
                    FontSize = config.FontSize
                };
                CustomGameButtons.Add(button);
            }

            GameLayoutPanel.Controls.AddRange(config.CustomFirst ? CustomGameButtons.ToArray() : GameButtons.ToArray());
            GameLayoutPanel.Controls.AddRange(config.CustomFirst ? GameButtons.ToArray() : CustomGameButtons.ToArray());
        }
        public static bool CheckIfIconExists(string path, out string ActualPath)
        {
            if (File.Exists(path + ".png"))
                ActualPath = path + ".png";
            else if (File.Exists(path + ".jpg"))
                ActualPath = path + ".jpg";
            else if (File.Exists(path + ".ico"))
                ActualPath = path + ".ico";
            else if (File.Exists(path + ".bmp"))
                ActualPath = path + ".bmp";
            else if (File.Exists(path + ".gif"))
                ActualPath = path + ".gif";
            else
            {
                ActualPath = string.Empty;
                return false;
            }

            return true;
        }
        public static string CleanString(string input)
        {
            return string.Concat(input.Split(Path.GetInvalidFileNameChars()));
        }
        private static Bitmap? GetGameIcon(GameId TouhouId)
        {
            string path = Path.Combine(GameIconsPath, $"{TouhouId}");
            Bitmap? Icon = null;
            if (CheckIfIconExists(path, out string ActualPath))
            {
                Icon = new Bitmap(ActualPath);
            }
            return Icon;
        }
        private static Bitmap? GetCustomGameIcon(string name)
        {
            string path = Path.Combine(CustomGameIconsPath, CleanString(name));
            Bitmap? Icon = null;
            if (CheckIfIconExists(path, out string ActualPath))
            {
                Icon = new Bitmap(ActualPath);
            }
            return Icon;
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            if (config.IconScale > 5)
            {
                config.IconScale--;
                Size NewSize = new(config.IconScale * 15, config.IconScale * 15);
                for (int i = 0; i < GameLayoutPanel.Controls.Count; i++)
                {
                    LaunchGameButton c = (LaunchGameButton)GameLayoutPanel.Controls[i];
                    c.SetScale(NewSize);
                }
            }
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            if (config.IconScale < 17)
            {
                config.IconScale++;
                GameLayoutPanel.Width = GameLayoutPanel.Width;
                Size NewSize = new(config.IconScale * 15, config.IconScale * 15);
                for (int i = 0; i < GameLayoutPanel.Controls.Count; i++)
                {
                    LaunchGameButton c = (LaunchGameButton)GameLayoutPanel.Controls[i];
                    c.SetScale(NewSize);
                }
            }
        }

        private void FontMinusBtn_Click(object sender, EventArgs e)
        {
            if (config.FontSize > 10)
            {
                config.FontSize--;
                for (int i = 0; i < GameLayoutPanel.Controls.Count; i++)
                {
                    LaunchGameButton c = (LaunchGameButton)GameLayoutPanel.Controls[i];
                    c.FontSize = config.FontSize;
                }
            }
        }

        private void FontPlusBtn_Click(object sender, EventArgs e)
        {
            if (config.FontSize < 38)
            {
                config.FontSize++;
                for (int i = 0; i < GameLayoutPanel.Controls.Count; i++)
                {
                    LaunchGameButton c = (LaunchGameButton)GameLayoutPanel.Controls[i];
                    c.FontSize = config.FontSize;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.Save(ConfigPath);
        }

        private void SettingsBtn_Click(object? sender, EventArgs? e)
        {
            ClearButtons();
            string oldLanguage = config.Language;
            Settings settings = new(config);
            settings.ShowDialog();
            config = settings.Config;
            config.Save(ConfigPath);
            if (oldLanguage != config.Language)
                LoadTranslation();
            ImportThcrapProfiles();
            CreateButtons();
        }

        private void ThcrapProfileBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            config.ThcrapProfile = ThcrapProfileBox.GetItemText(ThcrapProfileBox.SelectedItem);
        }

        private void GamesBtn_Click(object sender, EventArgs e)
        {
            ClearButtons();
            Games games = new(config);
            games.ShowDialog();
            config = games.Config;
            CreateButtons();
        }
        private void ClearButtons()
        {
            foreach (LaunchGameButton button in GameLayoutPanel.Controls)
            {
                button.Dispose();
            }
            GameLayoutPanel.Controls.Clear();
        }

        private void RandomBtn_Click(object sender, EventArgs e)
        {
            if (GameLayoutPanel.Controls.Count > 0)
            {
                Random random = new();
                LaunchGameButton button = (LaunchGameButton)GameLayoutPanel.Controls[random.Next(GameLayoutPanel.Controls.Count)];
                button.LaunchGame();
            }
        }

        private void GithubBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "\"https://www.github.com/Pioziomgames/PleasantTouhouLauncher\"");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (config.FirstLaunch)
            {
                config.FirstLaunch = false;
                SettingsBtn_Click(null, null);
            }
        }
    }
}