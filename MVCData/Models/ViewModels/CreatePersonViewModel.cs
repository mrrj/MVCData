using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MVCData.Models.ViewModels
{
    public class CreatePersonViewModel
    {

        
        public int PhoneNumber { get; set; }  
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public Country Country { get; set; }
        public City City { get; set; }


    }
}
