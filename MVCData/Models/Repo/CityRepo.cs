using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Data;
using MVCData.Models;

namespace MVCData.Models.Repo
{
    public class CityRepo : ICityRepo
    {
        private PeopleRepoDbContext _context;
        private ICountryRepo _countryRepo;

        public CityRepo(PeopleRepoDbContext context, ICountryRepo countryRepo)
        {
            _context = context;
            _countryRepo = countryRepo;
        }

        public City Create(string name, Country country)
        {
            if (_context.Countries.Contains(country))
            {
                City city = new City
                {
                    Name = name
                };
                _context.Cities.Add(city);
                _context.SaveChanges();
                country.Cities.Add(city);
                _countryRepo.Update(country);        
                _context.SaveChanges();
                return city;
            }
            else throw new Exception("Cannot add city to nonexistent country");
        }
        public List<City> Read()
        {
            return _context.Cities.ToList();
        }
        public City Read(int id)
        {
            return _context.Cities.FirstOrDefault(c => c.CityId == id);

        }
        public City Update(City city)
        {
            City ci =
                (City)(from c in _context.Cities
                          where c.CityId == city.CountryId
                          select c);
            ci.Name = city.Name;
            ci.People = city.People;
            _context.SaveChanges();
            return ci;

        }
        public bool Delete(City city)
        {
            if (_context.Cities.Contains(city))
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
