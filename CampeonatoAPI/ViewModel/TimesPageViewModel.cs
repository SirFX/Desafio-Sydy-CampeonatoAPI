using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAPI.ViewModel
{
    public class TimesPageViewModel
    {
        public TimesPageViewModel()
        {
            Times = new List<TimeViewModel>();
        }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdPagina { get; set; }
        public List<TimeViewModel> Times { get; set; }
    }
}
