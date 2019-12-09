using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProAgilEmpresa.Infra.CrossCutting.Identity.Identity
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "varchar(150)")]
        public string FullName { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
