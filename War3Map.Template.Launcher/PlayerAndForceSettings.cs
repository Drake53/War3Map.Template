using War3Net.Build.Info;

namespace War3Map.Template.Launcher
{
    internal static class PlayerAndForceSettings
    {
        public static void ApplyToMapInfo(MapInfo mapInfo)
        {
            // Create players
            var player0 = new PlayerData()
            {
                PlayerNumber = 0,
                PlayerName = "Player 1",
                PlayerController = PlayerController.User,
                PlayerRace = PlayerRace.Human,
                IsRaceSelectable = true,
                StartPosition = new System.Drawing.PointF(0f, 0f),
                FixedStartPosition = true,
            };
            var player1 = new PlayerData()
            {
                PlayerNumber = 1,
                PlayerName = "Player 2",
                PlayerController = PlayerController.User,
                PlayerRace = PlayerRace.Human,
                IsRaceSelectable = true,
                StartPosition = new System.Drawing.PointF(0f, 0f),
                FixedStartPosition = true,
            };
            var player2 = new PlayerData()
            {
                PlayerNumber = 23,
                PlayerName = "Enemies",
                PlayerController = PlayerController.Computer,
                PlayerRace = PlayerRace.Orc,
                IsRaceSelectable = false,
                StartPosition = new System.Drawing.PointF(0f, 0f),
                FixedStartPosition = true,
            };

            // Add players to MapInfo
            mapInfo.SetPlayerData(player0, player1, player2);

            // Create teams
            var team0 = new ForceData()
            {
                ForceName = "Team 1",
                ForceFlags = ForceFlags.Allied | ForceFlags.ShareVision,
            };
            var team1 = new ForceData()
            {
                ForceName = "Team 2",
            };

            // Add players to teams
            team0.SetPlayers(player0, player1);
            team1.SetPlayers(player2);

            // Add teams to MapInfo
            mapInfo.SetForceData(team0, team1);

            // Update map flags
            mapInfo.MapFlags |= MapFlags.UseCustomForces | MapFlags.FixedPlayerSettingsForCustomForces;
        }
    }
}