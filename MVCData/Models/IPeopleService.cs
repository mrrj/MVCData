﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;using MVCData.ViewModels;


namespace MVCData.Models
{
    interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
        Person FindBy(int id);
        Person Edit(int id, Person person);
        bool Remove(int id);


    }
}
