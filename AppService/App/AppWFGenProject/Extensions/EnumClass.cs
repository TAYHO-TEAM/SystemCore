namespace AppWFGenProject.Extensions
{
    public static class EnumClass
    {
        public static string nameproject = "{nameproject}";
        public static string common = "{common}";
        public static string db = "{db}";
        public static string Entity = "{Entity}";
        public static string entity = "{entity}";
        public static string _entity = "{_entity}";
        public static string version = "{version}";
        public static string builderConfig = "{builderConfig}";
        public static string builderFields = "{builderFields}";
        public static string paramCreate = "{paramCreate}";
        public static string functionCreate = "{functionCreate}";
        public static string builderProperties = "{builderProperties}";
        public static string builderBehaviours = "{builderBehaviours}";
        public static string builderRegister = "{biulderRegister}";
        public static string builderRequestParam = "{builderRequestParam}";
        public static string builderSetUpdate = "{builderSetUpdate}";
        public static string builderPublic = "{builderPublic}";
    }
    public class ConstDirect 
    {
       
        private string _command = @"\Application\Commands\{Entity}Cmd\";
        private string _commandBaseClasses = @"\Application\Commands\{Entity}Cmd\BaseClasses\";
        private string _controllers = @"\Controllers\{version}\";
        private string _mappings = @"\Infrastructure\Mappings\";
        private string _domainObjects = @"\DomainObjects\Mappings\";
        private string _eFConfig = @"\EFConfig\";
        private string _iRepositories = @"\IRepositories\";
        private string _repositories = @"\Repositories\";
        private string _viewModels = @"\ViewModels\";
        // CMD
        ////Controller
        public string Command { get; }
        public string CommandBaseClasses { get; }
        public string Controllers { get; }
        //// Domain
        public string Mappings { get; }
        public string DomainObjects { get; }
        public string IRepositories { get; }
        //// Infrastructure
        public string EFConfig { get; }
        public string Repositories { get; }
        // Read
        //// Controller
        public string ReadControllers { get; }
        //// Mappings
        public string ReadMappings { get; }
        //// ViewModels
        public string ViewModels { get; }
        public ConstDirect(string nameproject)
        {
            Command = @"\"+nameproject+".CMD.Api" + _command;
            CommandBaseClasses= @"\" + nameproject + ".CMD.Api" + _commandBaseClasses;
            Controllers = @"\"+ nameproject + ".CMD.Api" + _controllers;
            Mappings = @"\"+ nameproject+ ".CMD.Domain" + _mappings;
            DomainObjects = @"\" + nameproject + ".CMD.Domain" + _domainObjects;
            IRepositories = @"\" + nameproject + ".CMD.Domain" + _iRepositories;
            EFConfig = @"\" + nameproject + ".CMD.Infrastructure" + _eFConfig;
            Repositories = @"\" + nameproject + ".CMD.Infrastructure" + _repositories;
            ReadControllers = @"\" + nameproject + "Read.Api" + _controllers;
            ReadMappings = @"\" + nameproject + "Read.Api" + _mappings;
            ViewModels = @"\" + nameproject + "Read.Api" + _viewModels;
        }
    }

    public class SetConfig
    {
        
    }
}
