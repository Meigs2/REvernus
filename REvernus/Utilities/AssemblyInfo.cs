namespace REvernus.Utilities
{
    public class AssemblyInfo
    {
        public static string GetFileAssemblyVersion()
        {
            return typeof(AssemblyInfo).Assembly.GetName().Version.ToString();
        }
    }
}