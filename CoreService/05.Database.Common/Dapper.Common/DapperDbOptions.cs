namespace Dapper.Common
{
    public class DapperDbOptions
    {
        public string ConnectionStrings { get; set; }
        public int MaxRetryCount { get; set; }
        public int MaxRetryDelayInSecond { get; set; }
        public int CommandTimeOut { get; set; } = 300;
    }
}