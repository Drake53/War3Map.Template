using War3Net.Build;
using War3Net.Build.Providers;

namespace War3Map.Template.Launcher
{
    internal static class Info
    {
        private const string MapName = "Just another Warcraft III map";
        private const string MapDescription = "Nondescript";
        private const string MapAuthor = "Unknown";
        private const string RecommendedPlayers = "Any";

        public static MapInfo GetMapInfo(string infoFile)
        {
            var mapInfo = MapInfo.Parse(FileProvider.GetFile(infoFile));

            mapInfo.MapName = MapName;
            mapInfo.MapDescription = MapDescription;
            mapInfo.MapAuthor = MapAuthor;
            mapInfo.RecommendedPlayers = RecommendedPlayers;

            mapInfo.MapFlags &= ~MapFlags.MeleeMap;
            mapInfo.ScriptLanguage = ScriptLanguage.Lua;

            PlayerAndForceSettings.ApplyToMapInfo(mapInfo);

            return mapInfo;
        }
    }
}