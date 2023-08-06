using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTL
{
    public static class LocalizationManager
    {
        public static Translation CurrentTranslation = new();
        private readonly static List<Translation> LoadedTranslations = new();
        public static void LoadTranslation(string language)
        {
            int index = LoadedTranslations.FindIndex(x => x.LanguageName == language);
            if (index != -1)
            {
                CurrentTranslation = LoadedTranslations[index];
            }
            else
                CurrentTranslation = new();
        }
        public static string[] GetLanguages()
        {
            string[] Languages = new string[LoadedTranslations.Count];
            for (int i = 0; i < LoadedTranslations.Count; i++)
                Languages[i] = LoadedTranslations[i].LanguageName;
            return Languages;
        }
        public static void LoadTranslations()
        {
            LoadedTranslations.Clear();
            try
            {
                string[] Files = Directory.GetFiles(MainForm.TranslationsPath, "*.json");
                for (int i = 0; i < Files.Length; i++)
                {
                    try
                    {
                        Translation? Language = JsonConvert.DeserializeObject<Translation>(File.ReadAllText(Files[i]));
                        if (Language != null)
                            LoadedTranslations.Add(Language);
                    }
                    catch { }
                }
            }
            catch { }
            if (LoadedTranslations.Count == 0)
                LoadedTranslations.Add(new());
        }
    }
    public class Translation
    {
        public string LanguageName = "English";
        public string Settings = "Settings";
        public string SettingsToolTip = "Change program settings";
        public string Games = "Games";
        public string GamesToolTip = "Add, Edit and Remove games from the list";
        public string RandomToolTip = "Launch a random game from the list";
        public string GithubToolTip = "Visit the github page of this program";
        public string IconScaleDownToolTip = "Make the icons smaller";
        public string IconScaleUpToolTip = "Make the icons bigger";
        public string FontScaleDownToolTip = "Make the icon font bigger";
        public string FontScaleUpToolTip = "Make the icon font smaller";
        public string ThcrapProfile = "Thcrap Profile:";
        public string Remove = "Remove";
        public string Edit = "Edit";
        public string Add = "Add";
        public string AddGame = "Add Game";
        public string EditGame = "Edit Game";
        public string Game = "Game:";
        public string Name = "Name:";
        public string GamePath = "Game path:";
        public string UseConfigCustom = "Use config/custom";
        public string CustomPath = "Custom path:";
        public string LaunchAsAdministrator = "Launch as administrator";
        public string LaunchWithThcrap = "Launch with thcrap";
        public string LaunchGamesWithThcrap = "Launch games with thcrap";
        public string ThcrapPath = "Thcrap path:";
        public string SupportPC98Games = "Support PC98 Games";
        public string Neko2Path = "Neko 2 path:";
        public string NamePreset = "Name preset:";
        public string CloseLauncherOnGameStart = "Close launcher on game start";
        public string DisplayCustomGamesBeforeOfficialOnes = "Display custom games before official ones";
        public string ImportThcrapGames = "Import Thcrap games";
        public string ReimportThcrapGamesOnLaunch = "Reimport thcrap games on launch";
        public string SelectNekoProject2Exe = "Select neko project 2's exe file";
        public string NekoProject2ExeFile = "neko project 2 exe file";
        public string ImportedGames = "Imported/Reimported {0} games";
        public string GameImport = "Game Import";
        public string UnableToImport = "Unable to import any games";
        public string SelectThcrapExe = "Select thcrap's exe file";
        public string Language = "Language";
        public string Cancel = "Cancel";
        public string Save = "Save";
        public string Custom = "Custom";
        public string SelectYourHdi = "Select your game's hdi file";
        public string SelectYourConfig = "Select your game's config/custom.exe file";
        public string SelectAnIcon = "Select an icon for your game";
        public string Bitmap = "Bitmap";
        public string HdiFile = "hdi file";
        public string ExeFile = "exe file";
        public string AllFiles = "All files";
        public string GameImageToolTip = "Set an image for your game";
        public string GameImageToolTip2 = "(Right click to remove it)";
        public string Error = "Error";
        public string CannotLaunchPC98Games = "Cannot launch PC98 games because the neko project 2 path was not set up";
    }
}
