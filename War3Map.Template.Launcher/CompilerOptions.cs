using War3Net.Build;
using War3Net.Build.Script;
using War3Net.IO.Mpq;

namespace War3Map.Template.Launcher
{
    internal static class CompilerOptions
    {
        public static ScriptCompilerOptions GetCompilerOptions(MapInfo mapInfo, string sourceDirectory, string outputDirectory)
        {
            var scriptCompilerOptions = new ScriptCompilerOptions(CSharpLua.CoreSystem.CoreSystemProvider.GetCoreSystemFiles());

            scriptCompilerOptions.MapInfo = mapInfo;
            scriptCompilerOptions.SourceDirectory = sourceDirectory;
            scriptCompilerOptions.OutputDirectory = outputDirectory;

            scriptCompilerOptions.DefaultFileFlags = MpqFileFlags.Exists | MpqFileFlags.CompressedMulti;
            scriptCompilerOptions.FileFlags[ListFile.Key] = MpqFileFlags.Exists | MpqFileFlags.Encrypted | MpqFileFlags.BlockOffsetAdjustedKey;

#if DEBUG
            scriptCompilerOptions.Debug = true;
#endif

            return scriptCompilerOptions;
        }
    }
}