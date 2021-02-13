using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:User
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }


    }
}
