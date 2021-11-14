using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.ViewModels
{
    public class EditPersonViewModel
    {
        public int Id { get; set; }
        public string NewName { get; set; }
        public int NewPhoneNumber { get; set; }
        public int NewCityId { get; set; }
    }
}
