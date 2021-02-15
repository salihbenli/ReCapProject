using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customers : IEntity
    {
        public int UsersMId { get; set; }
        public string CompanyName { get; set; }
    }
}
