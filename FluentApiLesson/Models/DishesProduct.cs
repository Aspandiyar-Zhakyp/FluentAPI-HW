using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Models
{
    public class DishesProducts : Entity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
