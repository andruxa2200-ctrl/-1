using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Викторина.Cabinet;
using Викторина.Data;
using Викторина.Interfaces;
using Викторина.Models;

Menu.Show();

ICrud db = new RegistrationRepository();
User user = new();
Profile.Show(db,user);










return 0;
