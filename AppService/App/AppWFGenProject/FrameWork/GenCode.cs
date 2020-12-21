using AppWFGenProject.Extensions;
using System.Collections.Generic;
using System.Data;

namespace AppWFGenProject.FrameWork
{
    public class GenCode
    {
        public GenOB CreateGenOBCMD(string Server, string User, string Pass, string DB ,string NameTable, GenOB GenOB)
        {
            Connection connection = new Connection();
            ReadTemplate readTemplate = new ReadTemplate();
            DataSet ds = connection.GetAllCode(Server, User, Pass, DB, NameTable);
            FileHelper fileHelper = new FileHelper();

            /// gen entity 
            string pathentitytxt = @"F:\TayHo\SystemCore\AppService\App\AppWFGenProject\Content\TemPlate\CMD\Domain\Entity.txt";
            string entitytxt = readTemplate.ReadTxtAll(pathentitytxt);
            fileHelper.CompileFile(pathentitytxt, "Entity", GenOB.Entity);

            DataTable dtEntity = ds.Tables[0];
            foreach (DataRow row in dtEntity.Rows)
            {
                GenOB.builderFields += GenOB.builderFields + row["PrivateOBJ"].ToString()+"\r\n";
                GenOB.builderFields += GenOB.paramCreate + row["PublicParameter"].ToString();
                GenOB.builderFields += GenOB.functionCreate + row["FunctionPublic"].ToString() + "\r\n";
                GenOB.builderFields += GenOB.builderFields + row["PropertiesOBJ"].ToString() + "\r\n";
                //GenOB.builderFields += GenOB.builderFields + row["FunctionBehavior"].ToString() + "\r\n";
            }
            Dictionary<string, string> getDic = new Dictionary<string, string>(GenOB.getDictionatyChange());
            var abc = getDic.Keys;

            fileHelper.ReplaceLine(pathentitytxt.Replace("Entity", GenOB.Entity), getDic);
            //fileHelper.ReplaceLine(pathentitytxt, "{Entity}", GenOB.Entity);
            //fileHelper.ReplaceLine(pathentitytxt, "{paramCreate}", GenOB.paramCreate.Remove(GenOB.paramCreate.Length-1));
            //fileHelper.ReplaceLine(pathentitytxt, "{functionCreate}", GenOB.functionCreate);
            //fileHelper.ReplaceLine(pathentitytxt, "{builderProperties}", GenOB.builderProperties);
            //fileHelper.ReplaceLine(pathentitytxt, "{builderBehaviours}", GenOB.builderBehaviours);

            return GenOB;
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
