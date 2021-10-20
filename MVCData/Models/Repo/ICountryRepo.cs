using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.Repo
{
    public interface ICountryRepo
    {
        public Country Create(string name);
        public List<Country> Read();
        public Country Read(int id);
        Country Update(Country country);
        bool Delete(Country country);
    }
}
