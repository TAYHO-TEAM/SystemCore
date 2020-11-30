using Autofac;
using MediatR;
using ProjectManager.CMD.Api.Application.Behaviors;
using ProjectManager.CMD.Domain.IRepositories;
using ProjectManager.CMD.Infrastructure.Repositories;


namespace ProjectManager.CMD.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register services
            builder.RegisterGeneric(typeof(LoggingBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPerformanceBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

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
            builder.RegisterType<NS_GiaiDoanRepository>().As<INS_GiaiDoanRepository>().InstancePerLifetimeScope();
        }
    }
}
