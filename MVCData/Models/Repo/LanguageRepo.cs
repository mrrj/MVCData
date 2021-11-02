using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Data;

namespace MVCData.Models.Repo
{
    public class LanguageRepo : ILanguageRepo
    {
        PeopleRepoDbContext _context;

        public LanguageRepo(PeopleRepoDbContext context)
        {
            _context = context;
        }

        public Language Create(string name)
        {
            Language language = new Language()
            {
                Name = name
            };

            _context.Languages.Add(language);
            _context.SaveChanges();

            return language;
        }

        public bool Delete(Language language)
        {
            if (_context.Languages.Contains(language))
            {
                _context.Languages.Remove(language);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }


        public Language Read(int id)
        {
            return _context.Languages.FirstOrDefault(l => l.LanguageId == id);
        }

        public List<Language> Read()
        {
            return _context.Languages.ToList();
        }

        public Language Update(Language language)
        {
            Language lang = _context.Languages.Find(language.LanguageId);
            lang.Name = language.Name;
            lang.PersonLanguages = language.PersonLanguages;
            _context.SaveChanges();
            return lang;
        }

    }
}
