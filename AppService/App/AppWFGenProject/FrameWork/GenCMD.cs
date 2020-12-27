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
        /// function genCMD : gen domain entity 
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
        
    }
}
