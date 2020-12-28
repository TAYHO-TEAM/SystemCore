using AppWFGenProject.Extensions;
using System.Collections.Generic;
using System.Data;

namespace AppWFGenProject.FrameWork
{
    public class GenCode
    {
        public void CreateGenOBCMD(string Server, string User, string Pass, string DB ,string NameTable, GenOB GenOB)
        {
            Connection connection = new Connection();
            ReadTemplate readTemplate = new ReadTemplate();
            DataSet ds = connection.GetAllCode(Server, User, Pass, DB, NameTable);
            FileHelper fileHelper = new FileHelper();
            

            /// gen entity 
            string pathentitytxt = ConstPath.CMDDomain+ ConstFileNameTxt.Entity;
            DataTable dtEntity = ds.Tables[ConstTable.DomainOB];
            //Gen domain entity
            GenCMD genCMD = new GenCMD();
            genCMD.GenEntity(dtEntity, GenOB);
            genCMD.GenIRespositories( GenOB);
            genCMD.GenEntityConfig(ds.Tables[ConstTable.EFConfig], GenOB);
            genCMD.GenRepositories(GenOB);
            genCMD.GenCommandBase(ds.Tables[ConstTable.Command], GenOB);
            genCMD.GenCMDAll(ds.Tables[ConstTable.Command], GenOB);
            genCMD.GenController( GenOB);
            genCMD.GenEntityProfile(ds.Tables[ConstTable.MappingCMD], GenOB);
        }
        public GenOB CreateGenOBRed(string NameTable)
        {
            GenOB genOB = new GenOB();
            return genOB;
        }
        public GenOB CreateGenOBHTML(string NameTable)
        {
            GenOB genOB = new GenOB();
            return genOB;
        }
      
    }
}
