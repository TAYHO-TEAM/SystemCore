﻿using MediatR;
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
        public DbSet<Assignments> Assignments { get; set; } 
        public DbSet<ContractorInfo> ContractorInfo { get; set; } 
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<FilesAttachment> FilesAttachment { get; set; } 
        public DbSet<GroupStages> GroupStages { get; set; } 
        public DbSet<NS_CongViec> NS_CongViec { get; set; }
        public DbSet<NS_GiaiDoan> NS_GiaiDoan { get; set; }
        public DbSet<NS_GoiThau> NS_GoiThau { get; set; }
        public DbSet<NS_HangMuc> NS_HangMuc { get; set; }
        public DbSet<NS_HopDong> NS_HopDong { get; set; }
        public DbSet<NS_LoaiThau> NS_LoaiThau { get; set; }
        public DbSet<NS_NhomChiPhi> NS_NhomChiPhi { get; set; }
        public DbSet<OperationProcess> OperationProcess { get; set; }
        public DbSet<ProblemCategory> ProblemCategory { get; set; }
        public DbSet<Reply> Reply { get; set; }
        public DbSet<RequestDetail> RequestDetail { get; set; }
        public DbSet<RequestRegist> RequestRegist { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<ResponseRegist> ResponseRegist { get; set; }
        public DbSet<ResponseRegistReply> ResponseRegistReply { get; set; }
        public DbSet<Stages> Stages { get; set; }
        public DbSet<StepsProcess> StepsProcess { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
