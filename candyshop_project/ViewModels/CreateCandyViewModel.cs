using Candyshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace candyshop_project.ViewModels
{
    public class CreateCandyViewModel : Candy
    {
        public List<Category> Categories { get; set; }
    }
}
