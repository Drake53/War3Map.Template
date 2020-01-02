using War3Net.Build.Info;

namespace War3Map.Template.Launcher
{
    internal static class PlayerAndForceSettings
    {
        public static void ApplyToMapInfo(MapInfo mapInfo)
        {
            // Create players
            var player0 = PlayerData.Create();
            player0.PlayerNumber = 0;
            player0.PlayerName = "Player 1";
            player0.PlayerController = PlayerController.User;
            player0.PlayerRace = PlayerRace.Human;
            player0.IsRaceSelectable = true;
            player0.StartPosition = new System.Drawing.PointF( 0f, 0f );
            player0.FixedStartPosition = true;

            var player1 = PlayerData.Create();
            player1.PlayerNumber = 1;
            player1.PlayerName = "Player 2";
            player1.PlayerController = PlayerController.User;
            player1.PlayerRace = PlayerRace.Human;
            player1.IsRaceSelectable = true;
            player1.StartPosition = new System.Drawing.PointF( 0f, 0f );
            player1.FixedStartPosition = true;

            var player2 = PlayerData.Create();
            player2.PlayerNumber = 23;
            player2.PlayerName = "Enemies";
            player2.PlayerController = PlayerController.Computer;
            player2.PlayerRace = PlayerRace.Orc;
            player2.IsRaceSelectable = false;
            player2.StartPosition = new System.Drawing.PointF( 0f, 0f );
            player2.FixedStartPosition = true;

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