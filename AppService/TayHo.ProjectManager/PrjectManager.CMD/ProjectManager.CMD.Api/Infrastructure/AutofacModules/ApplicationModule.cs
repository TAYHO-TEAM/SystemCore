using Autofac;
using MediatR;
using ProjectManager.CMD.Api.Application.Behaviors;
using ProjectManager.CMD.Domain.IRepositories;
using ProjectManager.CMD.Domain.IService;
using ProjectManager.CMD.Infrastructure.Repositories;
using ProjectManager.CMD.Infrastructure.Service;

namespace ProjectManager.CMD.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register services
            builder.RegisterGeneric(typeof(LoggingBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPerformanceBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterType<MediaService>().As<IMediaService>().InstancePerLifetimeScope();

            // register repositories
            builder.RegisterType<StagesRepository>().As<IStagesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RequestsRepository>().As<IRequestsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RequestDetailRepository>().As<IRequestDetailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProblemCategoryRepository>().As<IProblemCategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupStagesRepository>().As<IGroupStagesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FilesAttachmentRepository>().As<IFilesAttachmentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentTypeRepository>().As<IDocumentTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AssignmentsRepository>().As<IAssignmentsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ReplyRepository>().As<IReplyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ContractorInfoRepository>().As<IContractorInfoRepository>().InstancePerLifetimeScope();

            builder.RegisterType<NS_GiaiDoanRepository>().As<INS_GiaiDoanRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_HangMucRepository>().As<INS_HangMucRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_HangMucDetailRepository>().As<INS_HangMucDetailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_GoiThauRepository>().As<INS_GoiThauRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_LoaiCongViecRepository>().As<INS_LoaiCongViecRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_CongViecRepository>().As<INS_CongViecRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_CongViecDetailRepository>().As<INS_CongViecDetailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_NhomChiPhiRepository>().As<INS_NhomChiPhiRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_NhomCongViecRepository>().As<INS_NhomCongViecRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NS_NhomCongViecDetailRepository>().As<INS_NhomCongViecDetailRepository>().InstancePerLifetimeScope();

            builder.RegisterType<RequestRegistRepository>().As<IRequestRegistRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ResponseRegistReplyRepository>().As<IResponseRegistReplyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ResponseRegistRepository>().As<IResponseRegistRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PlanRegisterRepository>().As<IPlanRegisterRepository>().InstancePerLifetimeScope();
        }
    }
}
