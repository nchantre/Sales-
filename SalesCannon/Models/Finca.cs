using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCannon.Models
{
    public class Finca
    {
        [Key]
        public int IdFinca { get; set; }
        public string NomFinca { get; set; }
        public string TelefonoFinca { get; set; }
        public string CantidadPultpaFinca { get; set; }
        public string CoordenadasFinca { get; set; }
        public string ImgFinca { get; set; }
        public DateTime FechaFinca { get; set; }
    }
}
