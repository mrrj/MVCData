using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCData.Models.ViewModels
{
    public class CreatePersonViewModel
    {

        
        public int PhoneNumber { get; set; }  
        [Required]
        public string Name { get; set; }
        public City City { get; set; }
        public SelectList SelectCity { get; set; }


    }
}
