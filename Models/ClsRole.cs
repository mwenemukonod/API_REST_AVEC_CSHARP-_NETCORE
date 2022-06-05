using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MairieTaxeAPI.Models
{
    public class ClsRole
    {
        [Key]  // pour definir la clé primaire
        public long id { get; set; }
        public string role { get; set; }
    }
}
