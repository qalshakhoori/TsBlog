using System.Configuration;

namespace TsBlog.Repositories
{
    /// <summary>
    /// Static configuration class
    /// </summary>
    public static class Config
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["TsBlogMySQLDB"].ConnectionString;

        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}