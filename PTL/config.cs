using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTL.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PTL
{
    public class ConfigObject
    {
        public bool FirstLaunch;
        public string Language;
        public int IconScale;
        public int FontSize;
        public List<GameEntry> GameEntries;
        public List<CustomGameEntry> CustomGameEntries;
        public string ThcrapPath;
        public bool UseThcrap;
        public bool SupportPC98;
        public string NekoPath;
        public int NamePreset;
        public bool ReimportGameOnLaunch;
        public string ThcrapProfile;
        public bool CloseOnLaunch;
        public bool CustomFirst;
        public ConfigObject()
        {
            Language = "English";
            FirstLaunch = true;
            UseThcrap = false;
            SupportPC98 = false;
            NekoPath = string.Empty;
            ThcrapPath = string.Empty;
            CustomGameEntries = new();
            GameEntries = new();
            IconScale = 8;
            FontSize = 14;
            NamePreset = 0;
            ReimportGameOnLaunch = false;
            ThcrapProfile = string.Empty;
            CustomFirst = true;
        }
        public void SortGames()
        {
            GameEntries = GameEntries.OrderBy(x=>x.Id).ToList();
        }
        public void SortCustomGames()
        {
            CustomGameEntries = CustomGameEntries.OrderBy(x=>x.Name).ToList();
        }
        public void AddGame(GameEntry game)
        {
            int index = GameEntries.FindIndex(x => x.Id == game.Id);
            if (index != -1)
                GameEntries[index] = game;
            else
                GameEntries.Add(game);
        }
        public void Save(string path)
        {
            string Json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, Json);
        }
        public static ConfigObject Read(string path)
        {
            ConfigObject? cfg = null;
            if (File.Exists(path))
                cfg = JsonConvert.DeserializeObject<ConfigObject>(File.ReadAllText(path));
            
            if ( cfg == null)
            {
                cfg = new ConfigObject();
                cfg.Save(path);
            }
            return cfg;
        }
    }
    public class Config
    {
        public struct GameEntry
        {
            public GameId Id;
            public string GamePath;
            public bool UseConfig;
            public string ConfigPath;
            [JsonIgnore]
            public bool PC98 { get {  return PC98(Id); } }
            public bool UseThcrap;
            public bool RunAsAdmin;
        }
        public struct CustomGameEntry
        {
            [JsonIgnore]
            public static GameId Id { get { return GameId.Custom; } }
            public string Name;
            public string GamePath;
            public bool UseConfig;
            public string ConfigPath;
            public bool UseThcrap;
            public bool RunAsAdmin;
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum GameId
        {
            Custom,
            Touhou1,
            Touhou2,
            Touhou3,
            Touhou4,
            Touhou5,
            Touhou6,
            Touhou7,
            Touhou75,
            Touhou8,
            Touhou9,
            Touhou95,
            Touhou10,
            Touhou105,
            Touhou11,
            Touhou12,
            Touhou123,
            Touhou125,
            Touhou128,
            Touhou13,
            Touhou135,
            Touhou14,
            Touhou143,
            Touhou145,
            Touhou15,
            Touhou155,
            Touhou16,
            Touhou165,
            Touhou17,
            Touhou175,
            Touhou18,
            Touhou185,
            Touhou19,
        }
        public static bool PC98(GameId TouhouGameId)
        {
            if (TouhouGameId > GameId.Custom && TouhouGameId < GameId.Touhou6)
                return true;
            return false;
        }
        public static string GetGameName(GameId TouhouGameId)
        {
            return TouhouGameId switch
            {
                GameId.Touhou1 => "Highly Responsive to Prayers",
                GameId.Touhou2 => "Story of Eastern Wonderland",
                GameId.Touhou3 => "Phantasmagoria of Dim.Dream",
                GameId.Touhou4 => "Lotus Land Story",
                GameId.Touhou5 => "Mystic Square",
                GameId.Touhou6 => "Embodiment of Scarlet Devil",
                GameId.Touhou7 => "Perfect Cherry Blossom",
                GameId.Touhou75 => "Immaterial and Missing Power",
                GameId.Touhou8 => "Imperishable Night",
                GameId.Touhou9 => "Phantasmagoria of Flower View",
                GameId.Touhou95 => "Shoot the Bullet",
                GameId.Touhou10 => "Mountain of Faith",
                GameId.Touhou105 => "Scarlet Weather Rhapsody",
                GameId.Touhou11 => "Subterranean Animism",
                GameId.Touhou12 => "Undefined Fantastic Object",
                GameId.Touhou123 => "Hisoutensoku",
                GameId.Touhou125 => "Double Spoiler",
                GameId.Touhou128 => "Great Fairy Wars",
                GameId.Touhou13 => "Ten Desires",
                GameId.Touhou135 => "Hopeless Masquerade",
                GameId.Touhou14 => "Double Dealing Character",
                GameId.Touhou143 => "Impossible Spell Card",
                GameId.Touhou145 => "Urban Legend in Limbo",
                GameId.Touhou15 => "Legacy of Lunatic Kingdom",
                GameId.Touhou155 => "Antinomy of Common Flowers",
                GameId.Touhou16 => "Hidden Star in Four Seasons",
                GameId.Touhou165 => "Violet Detector",
                GameId.Touhou17 => "Wily Beast and Weakest Creature",
                GameId.Touhou175 => "Sunken Fossil World",
                GameId.Touhou18 => "Unconnected Marketeers",
                GameId.Touhou185 => "100th Black Market",
                GameId.Touhou19 => "Unfinished Dream of All Living Ghost",
                _ => "Custom",
            };
        }
        public static string GetShortGameName(GameId TouhouGameId)
        {
            return TouhouGameId switch
            {
                GameId.Touhou1 => "HRTP",
                GameId.Touhou2 => "SOEW",
                GameId.Touhou3 => "PODD",
                GameId.Touhou4 => "LLS",
                GameId.Touhou5 => "MS",
                GameId.Touhou6 => "EOSD",
                GameId.Touhou7 => "PCB",
                GameId.Touhou75 => "IAMP",
                GameId.Touhou8 => "IN",
                GameId.Touhou9 => "POFV",
                GameId.Touhou95 => "STB",
                GameId.Touhou10 => "MOF",
                GameId.Touhou105 => "SWR",
                GameId.Touhou11 => "SA",
                GameId.Touhou12 => "UFO",
                GameId.Touhou123 => "SOKU",
                GameId.Touhou125 => "DS",
                GameId.Touhou128 => "FW",
                GameId.Touhou13 => "TD",
                GameId.Touhou135 => "HM",
                GameId.Touhou14 => "DDC",
                GameId.Touhou143 => "ISC",
                GameId.Touhou145 => "ULIL",
                GameId.Touhou15 => "LOLK",
                GameId.Touhou155 => "AOCF",
                GameId.Touhou16 => "HSIFS",
                GameId.Touhou165 => "VD",
                GameId.Touhou17 => "WBAWC",
                GameId.Touhou175 => "IBUN",
                GameId.Touhou18 => "UM",
                GameId.Touhou185 => "100BM",
                GameId.Touhou19 => "UDOALG",
                _ => "Custom",
            };
        }
        public static string GetGameNumber(GameId TouhouGameId)
        {
            return TouhouGameId switch
            {
                GameId.Touhou1 => "1",
                GameId.Touhou2 => "2",
                GameId.Touhou3 => "3",
                GameId.Touhou4 => "4",
                GameId.Touhou5 => "5",
                GameId.Touhou6 => "6",
                GameId.Touhou7 => "7",
                GameId.Touhou75 => "7.5",
                GameId.Touhou8 => "8",
                GameId.Touhou9 => "9",
                GameId.Touhou95 => "9.5",
                GameId.Touhou10 => "10",
                GameId.Touhou105 => "10.5",
                GameId.Touhou11 => "11",
                GameId.Touhou12 => "12",
                GameId.Touhou123 => "12.3",
                GameId.Touhou125 => "12.5",
                GameId.Touhou128 => "12.8",
                GameId.Touhou13 => "13",
                GameId.Touhou135 => "13.5",
                GameId.Touhou14 => "14",
                GameId.Touhou143 => "14.3",
                GameId.Touhou145 => "14.5",
                GameId.Touhou15 => "15",
                GameId.Touhou155 => "15.5",
                GameId.Touhou16 => "16",
                GameId.Touhou165 => "16.5",
                GameId.Touhou17 => "17",
                GameId.Touhou175 => "17.5",
                GameId.Touhou18 => "18",
                GameId.Touhou185 => "18.5",
                GameId.Touhou19 => "19",
                _ => string.Empty,
            };
        }

        public static string GetFullGameName(GameId TouhouGameId, int NamePreset)
        {
            return NamePreset switch
            {
                1 => $"Touhou {GetGameNumber(TouhouGameId)}: {GetShortGameName(TouhouGameId)}",
                2 => $"Touhou {GetGameNumber(TouhouGameId)}",
                3 => $"TH{GetGameNumber(TouhouGameId)}: {GetGameName(TouhouGameId)}",
                4 => $"TH{GetGameNumber(TouhouGameId)}: {GetShortGameName(TouhouGameId)}",
                5 => $"TH{GetGameNumber(TouhouGameId)}",
                6 => $"Th{GetGameNumber(TouhouGameId)}: {GetGameName(TouhouGameId)}",
                7 => $"Th{GetGameNumber(TouhouGameId)}: {GetShortGameName(TouhouGameId)}",
                8 => $"Th{GetGameNumber(TouhouGameId)}",
                9 => $"th{GetGameNumber(TouhouGameId)}: {GetGameName(TouhouGameId)}",
                10 => $"th{GetGameNumber(TouhouGameId)}: {GetShortGameName(TouhouGameId)}",
                11 => $"th{GetGameNumber(TouhouGameId)}",
                12 => $"{GetGameName(TouhouGameId)}",
                13 => $"{GetShortGameName(TouhouGameId)}",
                _ => $"Touhou {GetGameNumber(TouhouGameId)}: {GetGameName(TouhouGameId)}",
            };
        }
        public class ThcrapGames
        {
#pragma warning disable IDE1006 // Naming Styles
            public string th06 { get; set; }
            public string th06_custom { get; set; }
            public string th07 { get; set; }
            public string th07_custom { get; set; }
            public string th075 { get; set; }
            public string th075_custom { get; set; }
            public string th08 { get; set; }
            public string th08_custom { get; set; }
            public string th09 { get; set; }
            public string th09_custom { get; set; }
            public string th095 { get; set; }
            public string th095_custom { get; set; }
            public string th10 { get; set; }
            public string th10_custom { get; set; }
            public string th105 { get; set; }
            public string th105_custom { get; set; }
            public string th11 { get; set; }
            public string th11_custom { get; set; }
            public string th12 { get; set; }
            public string th12_custom { get; set; }
            public string th123 { get; set; }
            public string th123_custom { get; set; }
            public string th125 { get; set; }
            public string th125_custom { get; set; }
            public string th128 { get; set; }
            public string th128_custom { get; set; }
            public string th13 { get; set; }
            public string th13_custom { get; set; }
            public string th135 { get; set; }
            public string th135_custom { get; set; }
            public string th14 { get; set; }
            public string th14_custom { get; set; }
            public string th143 { get; set; }
            public string th143_custom { get; set; }
            public string th145 { get; set; }
            public string th145_custom { get; set; }
            public string th15 { get; set; }
            public string th15_custom { get; set; }
            public string th155 { get; set; }
            public string th155_custom { get; set; }
            public string th16 { get; set; }
            public string th16_custom { get; set; }
            public string th165 { get; set; }
            public string th165_custom { get; set; }
            public string th17 { get; set; }
            public string th17_custom { get; set; }
            public string th18 { get; set; }
            public string th18_custom { get; set; }
            public string th185 { get; set; }
            public string th185_custom { get; set; }
            public string th19 { get; set; }
            public string th19_custom { get; set; }
#pragma warning restore IDE1006 // Naming Styles
            public ThcrapGames()
            {
                th06 = string.Empty;
                th06_custom = string.Empty;
                th07 = string.Empty;
                th07_custom = string.Empty;
                th075 = string.Empty;
                th075_custom = string.Empty;
                th08 = string.Empty;
                th08_custom = string.Empty;
                th09 = string.Empty;
                th09_custom = string.Empty;
                th095 = string.Empty;
                th095_custom = string.Empty;
                th10 = string.Empty;
                th10_custom = string.Empty;
                th105 = string.Empty;
                th105_custom = string.Empty;
                th11 = string.Empty;
                th11_custom = string.Empty;
                th12 = string.Empty;
                th12_custom = string.Empty;
                th123 = string.Empty;
                th123_custom = string.Empty;
                th125 = string.Empty;
                th125_custom = string.Empty;
                th128 = string.Empty;
                th128_custom = string.Empty;
                th13 = string.Empty;
                th13_custom = string.Empty;
                th135 = string.Empty;
                th135_custom = string.Empty;
                th14 = string.Empty;
                th14_custom = string.Empty;
                th143 = string.Empty;
                th143_custom = string.Empty;
                th145 = string.Empty;
                th145_custom = string.Empty;
                th15 = string.Empty;
                th15_custom = string.Empty;
                th155 = string.Empty;
                th155_custom = string.Empty;
                th16 = string.Empty;
                th16_custom = string.Empty;
                th165 = string.Empty;
                th165_custom = string.Empty;
                th17 = string.Empty;
                th17_custom = string.Empty;
                th18 = string.Empty;
                th18_custom = string.Empty;
                th185 = string.Empty;
                th185_custom = string.Empty;
                th19 = string.Empty;
                th19_custom = string.Empty;
            }
        }
    }
}
