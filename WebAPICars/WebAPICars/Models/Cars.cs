using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICars.Models
{
    public class Cars
    {

        [Key]
        public int id { get; set; }
        public string Pedido { get; set; }
        public string Bastidor { get; set; }

        public string Modelo { get; set; }

        public string Matricula { get; set; }

        public string fecha { get; set; }
    }
}
