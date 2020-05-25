using System.Linq;

using War3Map.Template.Common.Constants;

using War3Net.Build.Info;

namespace War3Map.Template.Launcher
{
    internal static class PlayerAndForceSettings
    {
        public static void ApplyToMapInfo(MapInfo mapInfo)
        {
            // Create players
            var team0Players = new PlayerData[PlayerConstants.PlayerSlotCount];
            for (var i = 0; i < PlayerConstants.PlayerSlotCount; i++)
            {
                var playerData = PlayerData.Create(i);
                playerData.PlayerController = PlayerController.User;
                playerData.PlayerRace = PlayerRace.Human;
                playerData.IsRaceSelectable = true;
                playerData.StartPosition = new System.Drawing.PointF(0f, 0f);
                playerData.FixedStartPosition = true;

                team0Players[i] = playerData;
            }

            var team1Player = PlayerData.Create(23);
            team1Player.PlayerName = "Enemies";
            team1Player.PlayerController = PlayerController.Computer;
            team1Player.PlayerRace = PlayerRace.Orc;
            team1Player.IsRaceSelectable = false;
            team1Player.StartPosition = new System.Drawing.PointF( 0f, 0f );
            team1Player.FixedStartPosition = true;

            // Add players to MapInfo
            mapInfo.SetPlayerData(team0Players.Append(team1Player).ToArray());

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
            team0.SetPlayers(team0Players);
            team1.SetPlayers(team1Player);

            // Add teams to MapInfo
            mapInfo.SetForceData(team0, team1);

            // Update map flags
            mapInfo.MapFlags |= MapFlags.UseCustomForces | MapFlags.FixedPlayerSettingsForCustomForces;
        }
    }
}