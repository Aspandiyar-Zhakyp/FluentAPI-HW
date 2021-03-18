using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Models
{
    public class Dish : Entity
    {
        public string Name { get; set; }
        public ICollection<DishesProducts> DishesProducts { get; set; }
    }
}
