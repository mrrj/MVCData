﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCData.Models.Service;
 

namespace MVCData.Models.ViewModels
{
    public class CreatePersonViewModel
    {
       
        public int PhoneNumber { get; set; }  
        [Required]
        public string Name { get; set; }
        public int CityId { get; set; }



    }
}
