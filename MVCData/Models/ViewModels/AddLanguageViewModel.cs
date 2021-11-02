using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.ViewModels
{
    public class AddLanguageViewModel
    {
        //public Person Person { get; set; }
        //public Language Language { get; set; }

        public int PersonId { get; set; }
        public int LanguageId { get; set; }

        public List<Language> AvailableLanguages { get; set; }
    }
}
