namespace Services.Common.APIs.Cmd.EF
{
    public class SQLServerOptions
    {
        public int MaxRetryCount { get; set; }
        public int MaxRetryDelayInSecond { get; set; }
        public int CommandTimeOut { get; set; }
        public string ConnectionStrings { get; set; }
    }
}