using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;
//using System.Configuration;

namespace AppWFGenProject
{
    static class Program
    {
        public static IConfiguration _configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("/Content/appsettings.json", true, true)
            .Build();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GenProject(_configuration));
        }

    }
    public static class ConfigExtenstions
    {
        public static T GetValue<T>(this IConfiguration configuration, string configSection, string keyName)
        {
            return (T)Convert.ChangeType(configuration[$"{configSection}:{keyName}"], typeof(T));
        }
        //private static T GetValue<T>(string configSection, string configSubSection, string keyName)
        //{
        //    return (T)Convert.ChangeType(Configuration[$"{configSection}:{configSubSection}:{keyName}"], typeof(T));
        //}
    }

}
