using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAPI.ViewModel
{
    public class CampeonatoViewModel
    {
        public string Nome { get; set;}
        public List<PartidaViewModel> Partidas { get; set; }
        public string Campeao { get; set; }
        public string Vice { get; set; }
        public string Terceiro { get; set; }
    }
}
