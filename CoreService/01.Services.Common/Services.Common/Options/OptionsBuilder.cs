using Microsoft.Extensions.Options;
using Services.Common.APIs.Cmd.EF;
using Services.Common.Options;

namespace Services.Common
{
    public interface IOptionsBuilder
    {
        JwtOptions ReadJwtOptionsSettings();

        RedisServerOptions ReadRedisServerOptionsSettings();

        SQLServerOptions ReadSqlServerOptionsSettings();
    }

    public class OptionsBuilder : IOptionsBuilder
    {
        #region fields

        private JwtOptions _jwtOptions;
        private SQLServerOptions _sqlServerOptions;
        private RedisServerOptions _redisServerOptions;

        #endregion fields

        #region constructors

        public OptionsBuilder(IOptionsMonitor<JwtOptions> jwtOptionsMonitor, IOptionsMonitor<SQLServerOptions> sqlServerOptionsMonitor, IOptionsMonitor<RedisServerOptions> redisOptionsMonitor)
        {
            _jwtOptions = jwtOptionsMonitor.CurrentValue;
            _redisServerOptions = redisOptionsMonitor.CurrentValue;
            _sqlServerOptions = sqlServerOptionsMonitor.CurrentValue;
            jwtOptionsMonitor.OnChange(config => { _jwtOptions = config; });
            sqlServerOptionsMonitor.OnChange(config => { _sqlServerOptions = config; });
            redisOptionsMonitor.OnChange(config => { _redisServerOptions = config; });
        }

        #endregion constructors

        #region implementation

        public JwtOptions ReadJwtOptionsSettings()
        {
            return _jwtOptions;
        }

        public RedisServerOptions ReadRedisServerOptionsSettings()
        {
            return _redisServerOptions;
        }

        public SQLServerOptions ReadSqlServerOptionsSettings()
        {
            return _sqlServerOptions;
        }

        #endregion implementation
    }
}