using Dapper;
using Dapper.Common;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProjectManager.CMD.Infrastructure;
using ProjectManager.Read.Sql.DTOs.BaseClasses;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Repositories
{
    public class ProjectManagerRepository: IProjectManagerRepository
    {
        protected readonly ProjectManagerBaseContext _dbContext;
        //protected readonly ISqlConnectionFactory _connectionFactory;
        public ProjectManagerRepository( ProjectManagerBaseContext dbContext)
        {
            _dbContext = dbContext;
            //_connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<LoadResult> GetAccount(string nameEF,DevLoadOptionsBase dataSourceLoadOptions)
        {
            dynamic objEF = null;
            objEF = ConvertEF(nameEF);
            if (objEF != null)
            {
                dataSourceLoadOptions.PrimaryKey = new[] { "ID" };
                dataSourceLoadOptions.PaginateViaPrimaryKey = true;
                return await DataSourceLoader.LoadAsync(objEF, dataSourceLoadOptions);
            }
            else
            {
                return new LoadResult();
            }
        }
        private dynamic ConvertEF(string nameEntity)
        {
            dynamic orders = null;
            switch (nameEntity)
            {
                case nameof(_dbContext.AccountInfo):
                    orders = _dbContext.AccountInfo;
                    break;
                //case nameof(_dbContext.Accounts):
                //    orders = _dbContext.Accounts;
                //    break;
                //case nameof(_dbContext.Actions):
                //    orders = _dbContext.Actions;
                //    break;
                case nameof(_dbContext.Assignments):
                    orders = _dbContext.Assignments;
                    break;
                //case nameof(_dbContext.Categorys):
                //    orders = _dbContext.Categorys;
                //    break;
                case nameof(_dbContext.ContractorInfo):
                    orders = _dbContext.ContractorInfo;
                    break;
                case nameof(_dbContext.Conversation):
                    orders = _dbContext.Conversation;
                    break;
                case nameof(_dbContext.CustomCellContent):
                    orders = _dbContext.CustomCellContent;
                    break;
                case nameof(_dbContext.CustomColum):
                    orders = _dbContext.CustomColum;
                    break;
                case nameof(_dbContext.CustomForm):
                    orders = _dbContext.CustomForm;
                    break;
                case nameof(_dbContext.CustomFormAccount):
                    orders = _dbContext.CustomFormAccount;
                    break;
                case nameof(_dbContext.CustomFormBody):
                    orders = _dbContext.CustomFormBody;
                    break;
                case nameof(_dbContext.CustomFormContent):
                    orders = _dbContext.CustomFormContent;
                    break;
                //case nameof(_dbContext.CustomFormContentApprove):
                //    orders = _dbContext.CustomFormContentApprove;
                //    break;
                case nameof(_dbContext.CustomTable):
                    orders = _dbContext.CustomTable;
                    break;
                //case nameof(_dbContext.DeviceAccount):
                //    orders = _dbContext.DeviceAccount;
                //    break;
                case nameof(_dbContext.DocumentReleased):
                    orders = _dbContext.DocumentReleased;
                    break;
                case nameof(_dbContext.DocumentReleasedAccount):
                    orders = _dbContext.DocumentReleasedAccount;
                    break;
                case nameof(_dbContext.DocumentReleasedLog):
                    orders = _dbContext.DocumentReleasedLog;
                    break;
                case nameof(_dbContext.DocumentType):
                    orders = _dbContext.DocumentType;
                    break;
                case nameof(_dbContext.FilesAttachment):
                    orders = _dbContext.FilesAttachment;
                    break;
                //case nameof(_dbContext.Functions):
                //    orders = _dbContext.Functions;
                //    break;
                case nameof(_dbContext.GroupAccount):
                    orders = _dbContext.GroupAccount;
                    break;
                //case nameof(_dbContext.GroupAction):
                //    orders = _dbContext.GroupAction;
                //    break;
                //case nameof(_dbContext.GroupActionPermistion):
                //    orders = _dbContext.GroupActionPermistion;
                //    break;
                //case nameof(_dbContext.GroupFunctionPermistion):
                //    orders = _dbContext.GroupFunctionPermistion;
                //    break;
                //case nameof(_dbContext.GroupPermistion):
                //    orders = _dbContext.GroupPermistion;
                //    break;
                case nameof(_dbContext.Groups):
                    orders = _dbContext.Groups;
                    break;
                case nameof(_dbContext.GroupStages):
                    orders = _dbContext.GroupStages;
                    break;
                //case nameof(_dbContext.GroupStepProcessPermistion):
                //    orders = _dbContext.GroupStepProcessPermistion;
                //    break;
                //case nameof(_dbContext.LogEvent):
                //    orders = _dbContext.LogEvent;
                //    break;
                case nameof(_dbContext.Notify):
                    orders = _dbContext.Notify;
                    break;
                case nameof(_dbContext.NotifyAccount):
                    orders = _dbContext.NotifyAccount;
                    break;
                case nameof(_dbContext.NotifyTemplate):
                    orders = _dbContext.NotifyTemplate;
                    break;
                case nameof(_dbContext.NS_CongViec):
                    orders = _dbContext.NS_CongViec;
                    break;
                case nameof(_dbContext.NS_CongViecDetail):
                    orders = _dbContext.NS_CongViecDetail;
                    break;
                //case nameof(_dbContext.NS_CongViecDetail_GoiThau):
                //    orders = _dbContext.NS_CongViecDetail_GoiThau;
                //    break;
                case nameof(_dbContext.NS_DuChi):
                    orders = _dbContext.NS_DuChi;
                    break;
                case nameof(_dbContext.NS_GiaiDoan):
                    orders = _dbContext.NS_GiaiDoan;
                    break;
                case nameof(_dbContext.NS_GoiThau):
                    orders = _dbContext.NS_GoiThau;
                    break;
                case nameof(_dbContext.NS_HangMuc):
                    orders = _dbContext.NS_HangMuc;
                    break;
                case nameof(_dbContext.NS_HangMucDetail):
                    orders = _dbContext.NS_HangMucDetail;
                    break;
                case nameof(_dbContext.NS_KhauTru):
                    orders = _dbContext.NS_KhauTru;
                    break;
                case nameof(_dbContext.NS_KhauTru_TheoDoi):
                    orders = _dbContext.NS_KhauTru_TheoDoi;
                    break;
                case nameof(_dbContext.NS_LoaiCongViec):
                    orders = _dbContext.NS_LoaiCongViec;
                    break;
                //case nameof(_dbContext.NS_NghiemThu):
                //    orders = _dbContext.NS_NghiemThu;
                //    break;
                case nameof(_dbContext.NS_NhomChiPhi):
                    orders = _dbContext.NS_NhomChiPhi;
                    break;
                case nameof(_dbContext.NS_NhomCongViec):
                    orders = _dbContext.NS_NhomCongViec;
                    break;
                case nameof(_dbContext.NS_NhomCongViecDetail):
                    orders = _dbContext.NS_NhomCongViecDetail;
                    break;
                case nameof(_dbContext.NS_Phat):
                    orders = _dbContext.NS_Phat;
                    break;
                case nameof(_dbContext.NS_Phat_Nhom):
                    orders = _dbContext.NS_Phat_Nhom;
                    break;
                case nameof(_dbContext.NS_Phat_TheoDoi):
                    orders = _dbContext.NS_Phat_TheoDoi;
                    break;
                case nameof(_dbContext.NS_Reason):
                    orders = _dbContext.NS_Reason;
                    break;
                case nameof(_dbContext.NS_TamUng):
                    orders = _dbContext.NS_TamUng;
                    break;
                case nameof(_dbContext.NS_TamUng_TheoDoi):
                    orders = _dbContext.NS_TamUng_TheoDoi;
                    break;
                case nameof(_dbContext.NS_ThucChi):
                    orders = _dbContext.NS_ThucChi;
                    break;
                case nameof(_dbContext.OperationProcess):
                    orders = _dbContext.OperationProcess;
                    break;
                //case nameof(_dbContext.Permistions):
                //    orders = _dbContext.Permistions;
                //    break;
                case nameof(_dbContext.PlanAccount):
                    orders = _dbContext.PlanAccount;
                    break;
                case nameof(_dbContext.PlanJob):
                    orders = _dbContext.PlanJob;
                    break;
                case nameof(_dbContext.PlanMaster):
                    orders = _dbContext.PlanMaster;
                    break;
                case nameof(_dbContext.PlanProject):
                    orders = _dbContext.PlanProject;
                    break;
                case nameof(_dbContext.PlanRegister):
                    orders = _dbContext.PlanRegister;
                    break;
                case nameof(_dbContext.PlanReport):
                    orders = _dbContext.PlanReport;
                    break;
                case nameof(_dbContext.PlanSchedule):
                    orders = _dbContext.PlanSchedule;
                    break;
                case nameof(_dbContext.ProblemCategory):
                    orders = _dbContext.ProblemCategory;
                    break;
                //case nameof(_dbContext.Projects):
                //    orders = _dbContext.Projects;
                //    break;
                //case nameof(_dbContext.RelationTable):
                //    orders = _dbContext.RelationTable;
                //    break;
                case nameof(_dbContext.Reply):
                    orders = _dbContext.Reply;
                    break;
                case nameof(_dbContext.RequestDetail):
                    orders = _dbContext.RequestDetail;
                    break;
                case nameof(_dbContext.RequestRegist):
                    orders = _dbContext.RequestRegist;
                    break;
                case nameof(_dbContext.Requests):
                    orders = _dbContext.Requests;
                    break;
                case nameof(_dbContext.ResponseRegist):
                    orders = _dbContext.ResponseRegist;
                    break;
                case nameof(_dbContext.ResponseRegistReply):
                    orders = _dbContext.ResponseRegistReply;
                    break;
                //case nameof(_dbContext.StaffTayHo):
                //    orders = _dbContext.StaffTayHo;
                //    break;
                case nameof(_dbContext.Stages):
                    orders = _dbContext.Stages;
                    break;
                case nameof(_dbContext.StepsProcess):
                    orders = _dbContext.StepsProcess;
                    break;

                default:
                    orders = null;
                    break;
            }
            return orders;
        }
    }
}
