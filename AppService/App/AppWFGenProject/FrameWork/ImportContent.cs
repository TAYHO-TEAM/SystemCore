using AppWFGenProject.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppWFGenProject.FrameWork
{
    public class ImportContent
    {
        public string ReplaceLine()
        {
            return "";
        }
        public Dictionary<string,string> getDictionatyChange(GenOB genOB)
        {
            Dictionary<string, string> _dictionary = new Dictionary<string, string>();
            _dictionary.Add(EnumClass.nameproject,genOB.nameproject);
            _dictionary.Add(EnumClass.common, genOB.common);
            _dictionary.Add(EnumClass.db, genOB.db);
            _dictionary.Add(EnumClass.Entity, genOB.Entity);
            _dictionary.Add(EnumClass.entity, genOB.entity);
            _dictionary.Add(EnumClass._entity, genOB._entity);
            _dictionary.Add(EnumClass.version, genOB.version);
            _dictionary.Add(EnumClass.builderConfig, genOB.builderConfig);
            _dictionary.Add(EnumClass.builderFields, genOB.builderFields);
            _dictionary.Add(EnumClass.paramCreate, genOB.paramCreate);
            _dictionary.Add(EnumClass.functionCreate, genOB.functionCreate);
            _dictionary.Add(EnumClass.builderProperties, genOB.builderProperties);
            _dictionary.Add(EnumClass.builderBehaviours, genOB.builderBehaviours);
            _dictionary.Add(EnumClass.biulderRegister, genOB.biulderRegister);
            _dictionary.Add(EnumClass.builderRequestParam, genOB.builderRequestParam);
            _dictionary.Add(EnumClass.builderSetUpdate, genOB.builderSetUpdate);
            _dictionary.Add(EnumClass.builderPublic, genOB.builderPublic);
            return _dictionary;
        }
    }
}
