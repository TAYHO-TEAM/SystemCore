using Microsoft.Extensions.Options;
using Services.Common.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.APIs.Infrastructure.Configuration
{
    public interface IConfigurationReader
    {
        JwtOptions ReadJwtOptionsSettings();
    }

    public class ConfigurationReader : IConfigurationReader
    {
        private JwtOptions _jwtOptions;
        public ConfigurationReader(IOptionsMonitor<JwtOptions> jwtOptionsMonitor)
        {
            _jwtOptions = jwtOptionsMonitor.CurrentValue;
            jwtOptionsMonitor.OnChange(config =>
            {
                _jwtOptions = config;
            });
        }
        public JwtOptions ReadJwtOptionsSettings()
        {
            return _jwtOptions;
        }
    }
}
