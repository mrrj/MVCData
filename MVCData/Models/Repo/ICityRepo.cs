using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.Repo
{
    public interface ICityRepo
    {
        public City Create(string name, Country country);
        public List<City> Read();
        public City Read(int id);
        
        City Update(City city);
        
        public bool Delete(City city);
        
    }
}

