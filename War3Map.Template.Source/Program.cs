using static War3Api.Common;

namespace War3Map.Template.Source
{
    internal static class Program
    {
        private static void Main()
        {
            DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "Hello World!");
        }
    }
}