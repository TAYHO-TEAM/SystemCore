﻿using Dapper.Common;
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
            services.AddScoped<IDOBaseRepository<PlanRegisterDTO>, DOBaseRepository<PlanRegisterDTO>>();
            services.AddScoped<IDOBaseRepository<OperationProcessDTO>, DOBaseRepository<OperationProcessDTO>>();
            services.AddScoped<IDOBaseRepository<StepsProcessDTO>, DOBaseRepository<StepsProcessDTO>>();

            services.AddScoped<IDOBaseRepository<NS_CongViecDTO>, DOBaseRepository<NS_CongViecDTO>>();
            services.AddScoped<INS_CongViecRepository<NS_CongViec_CongViecDetailDTO>, NS_CongViecRepository<NS_CongViec_CongViecDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_CongViecDetailDTO>, DOBaseRepository<NS_CongViecDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_GiaiDoanDTO>, DOBaseRepository<NS_GiaiDoanDTO>>();
            services.AddScoped<IDOBaseRepository<NS_GoiThauDTO>, DOBaseRepository<NS_GoiThauDTO>>();

            services.AddScoped<IDOBaseRepository<NS_HangMucDTO>, DOBaseRepository<NS_HangMucDTO>>();
            services.AddScoped<INS_HangMucRepository<NS_HangMuc_HangMucDetailDTO>, NS_HangMucRepository<NS_HangMuc_HangMucDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_HangMucDetailDTO>, DOBaseRepository<NS_HangMucDetailDTO>>();
            services.AddScoped<IDOBaseRepository<NS_LoaiCongViecDTO>, DOBaseRepository<NS_LoaiCongViecDTO>>();
            services.AddScoped<IDOBaseRepository<NS_NhomChiPhiDTO>, DOBaseRepository<NS_NhomChiPhiDTO>>();

            services.AddScoped<IDOBaseRepository<NS_NhomCongViecDTO>, DOBaseRepository<NS_NhomCongViecDTO>>();
            services.AddScoped<INS_NhomCongViecRepository<NS_NhomCongViec_NhomCongViecDetailDTO>, NS_NhomCongViecRepository<NS_NhomCongViec_NhomCongViecDetailDTO>>();

            services.AddScoped<IDOBaseRepository<NS_NhomCongViecDetailDTO>, DOBaseRepository<NS_NhomCongViecDetailDTO>>();
            services.AddScoped<IDOBaseRepository<NS_ReasonDTO>, DOBaseRepository<NS_ReasonDTO>>();

            services.AddScoped<IDOBaseRepository<NS_PhatDTO>, DOBaseRepository<NS_PhatDTO>>();
            services.AddScoped<IDOBaseRepository<NS_Phat_NhomDTO>, DOBaseRepository<NS_Phat_NhomDTO>>();
            services.AddScoped<IDOBaseRepository<NS_Phat_TheoDoiDTO>, DOBaseRepository<NS_Phat_TheoDoiDTO>>();
            services.AddScoped<IDOBaseRepository<NS_KhauTruDTO>, DOBaseRepository<NS_KhauTruDTO>>();
            services.AddScoped<IDOBaseRepository<NS_KhauTru_TheoDoiDTO>, DOBaseRepository<NS_KhauTru_TheoDoiDTO>>();
            services.AddScoped<IDOBaseRepository<NS_TamUngDTO>, DOBaseRepository<NS_TamUngDTO>>();
            services.AddScoped<IDOBaseRepository<NS_TamUng_TheoDoiDTO>, DOBaseRepository<NS_TamUng_TheoDoiDTO>>();

            services.AddScoped<IDOBaseRepository<RequestRegistDTO>, DOBaseRepository<RequestRegistDTO>>();
            services.AddScoped<IDOBaseRepository<ResponseRegistDTO>, DOBaseRepository<ResponseRegistDTO>>();
            services.AddScoped<IDOBaseRepository<ResponseRegistReplyDTO>, DOBaseRepository<ResponseRegistReplyDTO>>();
            services.AddScoped<IDOBaseRepository<WorkItemsDTO>, DOBaseRepository<WorkItemsDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentReleasedDTO>, DOBaseRepository<DocumentReleasedDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentReleasedAccountDTO>, DOBaseRepository<DocumentReleasedAccountDTO>>();
            services.AddScoped<IDOBaseRepository<DocumentReleasedLogDTO>, DOBaseRepository<DocumentReleasedLogDTO>>();
            services.AddScoped<IDOBaseRepository<AccountInfoDTO>, DOBaseRepository<AccountInfoDTO>>();

            services.AddScoped<IRequestRegistRepository<RequestRegistDTO>, RequestRegistRepository<RequestRegistDTO>>();
            services.AddScoped<IRequestRegistRepository<RequestRegistDetailDTO>, RequestRegistRepository<RequestRegistDetailDTO>>();
            services.AddScoped<IResponseRegistRepository<ResponseRegistDTO>, ResponseRegistRepository<ResponseRegistDTO>>();
            services.AddScoped<IFilesAttachmentRepository<FilesAttachmentDTO>, FilesAttachmentRepository<FilesAttachmentDTO>>();

            return services;
        }

        #endregion private functions
    }
}
