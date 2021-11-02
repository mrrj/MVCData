using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; } = new List<PersonLanguage>();

    }
}
