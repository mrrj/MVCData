using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.Repo
{
    public interface ILanguageRepo
    {

        public Language Create(string name);
        public Language Read(int id);
        public List<Language> Read();
        public bool Delete(Language language);

        public Language Update(Language language);
    }
}
