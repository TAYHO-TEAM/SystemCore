using AutoMapper;
using DevExtreme.AspNet.Mvc;
using ProjectManager.Read.Api.ViewModels.DevExpressClasses;


namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class ProjectManagerProfile : Profile
    {
        public ProjectManagerProfile()
        {
            CreateMap<DevRequestLoadOptionsViewModel, DataSourceLoadOptions>();
        }
    }
}
