using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Data;

namespace MVCData.Models.Repo

{
    public class CountryRepo : ICountryRepo
    {


        private PeopleRepoDbContext _context;

        public CountryRepo(PeopleRepoDbContext context)
        {
            _context = context;
        }

        public Country Create(string name)
        {
            Country country = new Country
            {
                Name = name
            };

            _context.Countries.Add(country);
            _context.SaveChanges();
            return country;

        }
        public List<Country> Read()
        {
            return _context.Countries.ToList();
        }
        public Country Read(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.CountryId == id);

        }
        public Country Update(Country country)
        {
            Country count = _context.Countries.Find(country.CountryId);
            count.Name = country.Name;
            count.Cities = country.Cities;
            _context.SaveChanges();
            return count;

        }
        public bool Delete(Country country)
        {
            if (_context.Countries.Contains(country))
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
