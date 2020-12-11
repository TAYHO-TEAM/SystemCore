using Dapper.Common;
using Dapper.Common.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Repositories;

namespace ProjectManager.Read.Sql
{
    public static class QuanLyDuAnSqlDbExtensions
    {
        public static IServiceCollection AddQuanLyDuAnServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerOptions(configuration).AddSqlRepositories();
            return services;
        }

        #region private functions

        private static IServiceCollection AddSqlServerOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DapperDbOptions>(configuration.GetSection("SQLServerOptions"));
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            return services;
        }

        private static IServiceCollection AddSqlRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDOBaseRepository<StagesDTO>, DOBaseRepository<StagesDTO>>();
            services.AddScoped<IDOBaseRepository<ActionsDTO>, DOBaseRepository<ActionsDTO>>();
            services.AddScoped<IDOBaseRepository<RequestsDTO>, DOBaseRepository<RequestsDTO>>();
            services.AddScoped<IDOBaseRepository<RequestDetailDTO>, DOBaseRepository<RequestDetailDTO>>();
            services.AddScoped<IDOBaseRepository<ProblemCategoryDTO>, DOBaseRepository<ProblemCategoryDTO>>();
            services.AddScoped<IDOBaseRepository<GroupStagesDTO>, DOBaseRepository<GroupStagesDTO>>();
            services.AddScoped<IDOBaseRepository<FilesAttachmentDTO>, DOBaseRepository<FilesAttachmentDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentTypeDTO>, DOBaseRepository<DocumentTypeDTO>>();
            services.AddScoped<IDOBaseRepository<AssignmentsDTO>, DOBaseRepository<AssignmentsDTO>>();
            services.AddScoped<IDOBaseRepository<ProjectsDTO>, DOBaseRepository<ProjectsDTO>>();
            services.AddScoped<IDOBaseRepository<ReplyDTO>, DOBaseRepository<ReplyDTO>>();
            services.AddScoped<IDOBaseRepository<ContractorInfoDTO>, DOBaseRepository<ContractorInfoDTO>>();

            services.AddScoped<IDOBaseRepository<NS_CongViecDTO>, DOBaseRepository<NS_CongViecDTO>>();
            services.AddScoped<IDOBaseRepository<NS_GiaiDoanDTO>, DOBaseRepository<NS_GiaiDoanDTO>>();
            services.AddScoped<IDOBaseRepository<NS_NhomCongViecDTO>, DOBaseRepository<NS_NhomCongViecDTO>>();
            services.AddScoped<INS_NhomCongViecRepository<NS_NhomCongViecDTO>, NS_NhomCongViecRepository<NS_NhomCongViecDTO>>();
            services.AddScoped<IDOBaseRepository<NS_HangMucDTO>, DOBaseRepository<NS_HangMucDTO>>();
            services.AddScoped<IDOBaseRepository<NS_HopDongDTO>, DOBaseRepository<NS_HopDongDTO>>();
            services.AddScoped<IDOBaseRepository<NS_LoaiThauDTO>, DOBaseRepository<NS_LoaiThauDTO>>();
            services.AddScoped<IDOBaseRepository<NS_NhomChiPhiDTO>, DOBaseRepository<NS_NhomChiPhiDTO>>();

            services.AddScoped<IDOBaseRepository<RequestRegistDTO>, DOBaseRepository<RequestRegistDTO>>();
            services.AddScoped<IDOBaseRepository<ResponseRegistDTO>, DOBaseRepository<ResponseRegistDTO>>();
            services.AddScoped<IDOBaseRepository<ResponseRegistReplyDTO>, DOBaseRepository<ResponseRegistReplyDTO>>();
            services.AddScoped<IDOBaseRepository<WorkItemsDTO>, DOBaseRepository<WorkItemsDTO>>();
            services.AddScoped<IRequestRegistRepository<RequestRegistDTO>, RequestRegistRepository<RequestRegistDTO>>();

            return services;
        }

        #endregion private functions
    }
}
