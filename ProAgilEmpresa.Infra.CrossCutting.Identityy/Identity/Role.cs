using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Infra.CrossCutting.Identity.Identity
{
   public class Role : IdentityRole<int>
    {
        public List<UserRole> Users { get; set; }
    }
}
