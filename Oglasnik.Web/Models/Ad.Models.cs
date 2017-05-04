using Oglasnik.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.Web.Models
{
    public class AdFilterModel : IAdFilter
    {
        public string Kategorija { get; set; }

    }
}