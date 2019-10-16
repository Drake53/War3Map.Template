using System.Diagnostics;
using System.IO;

using War3Net.Build;

namespace War3Map.Template.Launcher
{
    internal static class Program
    {
        // Input
        private const string SourceCodeProjectFolderPath = @"..\..\..\..\War3Map.Template.Source";
        private const string AssetsFolderPath = @".\Assets\";

        // Output
        private const string OutputFolderPath = @"..\..\..\..\artifacts";
        private const string OutputMapName = @"Testmap.w3x";

        // Warcraft III
        private const string Warcraft3ExecutableFilePath = null;
        private const string Warcraft3CommandLineArgs = @"-nowfpause -graphicsapi Direct3D9 ";

        private static void Main()
        {
            var mapInfo = Info.GetMapInfo(Path.Combine(AssetsFolderPath, MapInfo.FileName));
            var scriptCompilerOptions = CompilerOptions.GetCompilerOptions(mapInfo, SourceCodeProjectFolderPath, OutputFolderPath);

            // Build and launch
            var mapBuilder = new MapBuilder(OutputMapName);
            if (mapBuilder.Build(scriptCompilerOptions, AssetsFolderPath) && Warcraft3ExecutableFilePath != null)
            {
                var mapPath = Path.Combine(scriptCompilerOptions.OutputDirectory, OutputMapName);
                var absoluteMapPath = new FileInfo(mapPath).FullName;
                Process.Start(Warcraft3ExecutableFilePath, $"{Warcraft3CommandLineArgs} -loadfile \"{absoluteMapPath}\"");
            }
        }
    }
}