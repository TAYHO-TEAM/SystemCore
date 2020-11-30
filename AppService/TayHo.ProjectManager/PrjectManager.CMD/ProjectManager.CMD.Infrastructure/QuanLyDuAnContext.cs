using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using System.Reflection;

namespace ProjectManager.CMD.Infrastructure
{
    public class QuanLyDuAnContext : BaseDbContext
    {
        public QuanLyDuAnContext(DbContextOptions<QuanLyDuAnContext> options, IMediator mediator) : base(options, mediator)
        {
        }
        public DbSet<Stages> Stages { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<RequestDetail> RequestDetail { get; set; }
        public DbSet<ProblemCategory> ProblemCategory { get; set; }
        public DbSet<GroupStages> GroupStages { get; set; }
        public DbSet<FilesAttachment> FilesAttachment { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Reply> Reply { get; set; }
        public DbSet<NS_GiaiDoan> NS_GiaiDoan { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
