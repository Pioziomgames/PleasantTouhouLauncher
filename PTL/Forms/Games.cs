using PTL.Forms;
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

namespace PTL
{
    public partial class Games : Form
    {
        public ConfigObject Config;
        public struct GamesEntry
        {
            public string Name;
            public GameEntry? GameEntry;
            public CustomGameEntry? CustomGameEntry;
            public override string ToString()
            {
                return Name;
            }
        }
        public Games(ConfigObject config)
        {
            InitializeComponent();
            Config = config;
            Text = LocalizationManager.CurrentTranslation.Games;
            AddBtn.Text = LocalizationManager.CurrentTranslation.Add;
            EditBtn.Text = LocalizationManager.CurrentTranslation.Edit;
            RemoveBtn.Text = LocalizationManager.CurrentTranslation.Remove;
            PopulateGamesList();
        }
        private void PopulateGamesList()
        {
            GamesListBox.Items.Clear();
            if (Config.CustomFirst)
            {
                for (int i = 0; i < Config.CustomGameEntries.Count; i++)
                {
                    GamesEntry ge = new()
                    {
                        Name = Config.CustomGameEntries[i].Name,
                        CustomGameEntry = Config.CustomGameEntries[i]
                    };
                    GamesListBox.Items.Add(ge);
                }
                for (int i = 0; i < Config.GameEntries.Count; i++)
                {
                    GamesEntry ge = new()
                    {
                        Name = GetFullGameName(Config.GameEntries[i].Id, Config.NamePreset),
                        GameEntry = Config.GameEntries[i]
                    };
                    GamesListBox.Items.Add(ge);
                }
            }
            else
            {
                for (int i = 0; i < Config.GameEntries.Count; i++)
                {
                    GamesEntry ge = new()
                    {
                        Name = GetFullGameName(Config.GameEntries[i].Id, Config.NamePreset),
                        GameEntry = Config.GameEntries[i]
                    };
                    GamesListBox.Items.Add(ge);
                }
                for (int i = 0; i < Config.CustomGameEntries.Count; i++)
                {
                    GamesEntry ge = new()
                    {
                        Name = Config.CustomGameEntries[i].Name,
                        CustomGameEntry = Config.CustomGameEntries[i]
                    };
                    GamesListBox.Items.Add(ge);
                }
            }
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddGame ag = new(Config);
            if (ag.ShowDialog() == DialogResult.OK)
            {
                if (ag.Custom)
                {
                    Config.CustomGameEntries.Add(ag.OutputCustomGameEntry);
                    Config.SortCustomGames();
                }
                else
                {
                    Config.GameEntries.Add(ag.OutputGameEntry);
                    Config.SortGames();
                }
                PopulateGamesList();
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (GamesListBox.SelectedIndex != -1)
            {
                GamesEntry ge = (GamesEntry)GamesListBox.SelectedItem;
                AddGame ag;
                if (ge.GameEntry != null)
                {
                    ag = new AddGame(ge.GameEntry.Value, Config);
                    if (ag.ShowDialog() == DialogResult.OK)
                        Config.GameEntries[Config.GameEntries.IndexOf(ge.GameEntry.Value)] = ag.OutputGameEntry;
                }
                else if (ge.CustomGameEntry != null)
                {
                    ag = new AddGame(ge.CustomGameEntry.Value, Config);
                    if (ag.ShowDialog() == DialogResult.OK)
                        Config.CustomGameEntries[Config.CustomGameEntries.IndexOf(ge.CustomGameEntry.Value)] = ag.OutputCustomGameEntry;
                }
                else
                    return;

                PopulateGamesList();
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (GamesListBox.SelectedIndex != -1)
            {
                int OldIndex = GamesListBox.SelectedIndex;
                GamesEntry ge = (GamesEntry)GamesListBox.SelectedItem;

                if (ge.CustomGameEntry != null)
                {
                    Config.CustomGameEntries.Remove(ge.CustomGameEntry.Value);
                    try
                    {
                        if (MainForm.CheckIfIconExists(Path.Combine(MainForm.CustomGameIconsPath, MainForm.CleanString(ge.CustomGameEntry.Value.Name)), out string ActualPath))
                            File.Delete(ActualPath);
                    }
                    catch { }
                }
                else if (ge.GameEntry != null)
                    Config.GameEntries.Remove(ge.GameEntry.Value);

                PopulateGamesList();
                if (OldIndex < GamesListBox.Items.Count)
                    GamesListBox.SelectedIndex = OldIndex;
                else if (GamesListBox.Items.Count > 0)
                    GamesListBox.SelectedIndex = OldIndex - 1;
            }
        }
    }
}
