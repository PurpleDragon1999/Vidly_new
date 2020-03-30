using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_new.Models;

namespace Vidly_new.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}