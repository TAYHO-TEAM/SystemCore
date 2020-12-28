using AppWFGenProject.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppWFGenProject.FrameWork
{
    public class GenCMD
    {
        /// <summary>
        /// function genCMD : gen domain object
        /// </summary>
        public void GenEntity(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathentitytxt = ConstPath.CMDDomain + ConstFileNameTxt.Entity;
            foreach (DataRow row in dt.Rows)
            {
                GenOB.builderFields += row["PrivateOBJ"].ToString() + "\r\n\t";
                GenOB.paramCreate += row["PublicParameter"].ToString().TrimEnd(','); ;
                GenOB.functionCreate += row["FunctionPublic"].ToString() + "\r\n\t";
                GenOB.builderBehaviours += row["PropertiesOBJ"].ToString() + "\r\n\t";
            }
            fileHelper.CreateFileFrom(pathentitytxt, (direct.DomainObjects + ConstFileNameTxt.Entity).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
        public void GenIRespositories(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get repos  
            string pathRepository = ConstPath.CMDDomain + ConstFileNameTxt.IEntityRepository;
         
            fileHelper.CreateFileFrom(pathRepository, (direct.IRepositories + ConstFileNameTxt.IEntityRepository).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
        /// <summary>
        /// function genCMD : gen Infra
        /// </summary>
        public void GenEntityConfig(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get path entity config  
            string pathEntityConfig = ConstPath.CMDInfra + ConstFileNameTxt.EntityConfiguration;
            foreach (DataRow row in dt.Rows)
            {
                GenOB.builderConfig += row[0].ToString() + "\r\n\t";
            }
            fileHelper.CreateFileFrom(pathEntityConfig, (direct.IRepositories + ConstFileNameTxt.EntityConfiguration).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
        public void GenRepositories( GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get path config  
            string pathEntityConfig = ConstPath.CMDInfra + ConstFileNameTxt.EntityRepository;
          
            fileHelper.CreateFileFrom(pathEntityConfig, (direct.Repositories + ConstFileNameTxt.EntityRepository).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
        /// <summary>
        /// function genCMD : gen Controller
        /// </summary>
        /// 
        public void GenCommandBase(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathEntityConfig = ConstPath.CMDCommandBase + ConstFileNameTxt.EntityCommand;
            string pathEntityCommandHandler = ConstPath.CMDCommandBase + ConstFileNameTxt.EntityCommandHandler;
            string pathEntityCommandSet = ConstPath.CMDCommandBase + ConstFileNameTxt.EntityCommandSet;

            foreach (DataRow row in dt.Rows)
            {
                GenOB.builderPublic += row[0].ToString() + "\r\n\t";
            }

            fileHelper.CreateFileFrom(pathEntityConfig, (direct.CommandBaseClasses + ConstFileNameTxt.EntityCommand).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathEntityConfig, (direct.CommandBaseClasses + ConstFileNameTxt.EntityCommandHandler).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathEntityConfig, (direct.CommandBaseClasses + ConstFileNameTxt.EntityCommandSet).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
        public void GenCMDAll(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathCreate = ConstPath.CMDCommand + ConstFileNameTxt.CreateEntityCommand;
            string pathCreateHandler = ConstPath.CMDCommand + ConstFileNameTxt.CreateEntityCommandHandler;
            string pathDelete = ConstPath.CMDCommand + ConstFileNameTxt.DeleteEntityCommand;
            string pathDeleteHandler = ConstPath.CMDCommand + ConstFileNameTxt.DeleteEntityCommandHandler;
            string pathUpdate = ConstPath.CMDCommand + ConstFileNameTxt.UpdateEntityCommand;
            string pathUpdateHandler = ConstPath.CMDCommand + ConstFileNameTxt.UpdateEntityCommandHandler;

            foreach (DataRow row in dt.Rows)
            {
                GenOB.builderPublic += row[0].ToString() + "\r\n\t";
                GenOB.builderRequestParam += row["Request"].ToString();
                GenOB.builderSetUpdate += row["UpdateSet"].ToString() + "\r\n\t";
            }

            fileHelper.CreateFileFrom(pathCreate, (direct.Command + ConstFileNameTxt.CreateEntityCommand).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathCreateHandler, (direct.Command + ConstFileNameTxt.CreateEntityCommandHandler).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathDelete, (direct.Command + ConstFileNameTxt.DeleteEntityCommand).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathDeleteHandler, (direct.Command + ConstFileNameTxt.DeleteEntityCommandHandler).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathUpdate, (direct.Command + ConstFileNameTxt.UpdateEntityCommand).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathUpdateHandler, (direct.Command + ConstFileNameTxt.UpdateEntityCommandHandler).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
        public void GenController( GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathController = ConstPath.CMDControllers + ConstFileNameTxt.CMDEntityController;
            fileHelper.CreateFileFrom(pathController, (direct.Controllers + ConstFileNameTxt.CMDEntityController).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
        public void GenEntityProfile(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathEntityProfile = ConstPath.CMDMappings + ConstFileNameTxt.CMDEntityProfile;
            fileHelper.CreateFileFrom(pathEntityProfile, (direct.Mappings + ConstFileNameTxt.CMDEntityProfile).Replace("Entity", GenOB.Entity).Replace("{Entity}", GenOB.Entity), GenOB.getDictionatyChange());
        }
    }
}
