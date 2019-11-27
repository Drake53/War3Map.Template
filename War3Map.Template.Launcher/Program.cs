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
            // Build and launch
            var mapBuilder = new MapBuilder(OutputMapName);
            if (mapBuilder.Build(CompilerOptions.GetCompilerOptions(SourceCodeProjectFolderPath, OutputFolderPath), AssetsFolderPath))
            {
                var mapPath = Path.Combine(OutputFolderPath, OutputMapName);
                var absoluteMapPath = new FileInfo(mapPath).FullName;

                if (Warcraft3ExecutableFilePath is null)
                {
                    Process.Start("explorer.exe", $"/select, \"{absoluteMapPath}\"");
                }
                else
                {
                    Process.Start(Warcraft3ExecutableFilePath, $"{Warcraft3CommandLineArgs} -loadfile \"{absoluteMapPath}\"");
                }
            }
        }
    }
}