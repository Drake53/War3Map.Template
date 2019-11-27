using War3Net.Build.Info;

namespace War3Map.Template.Launcher
{
    internal static class Info
    {
        public static MapInfo GetMapInfo()
        {
            var mapInfo = MapInfo.Default;

            mapInfo.MapName = "Just another Warcraft III map";
            mapInfo.MapDescription = "Nondescript";
            mapInfo.MapAuthor = "Unknown";
            mapInfo.RecommendedPlayers = "Any";

            mapInfo.MapFlags &= ~MapFlags.MeleeMap;
            mapInfo.ScriptLanguage = ScriptLanguage.Lua;

            PlayerAndForceSettings.ApplyToMapInfo(mapInfo);

            return mapInfo;
        }
    }
}