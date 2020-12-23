using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Domain.Entities
{
    public class PartidaEntity : BaseEntity
    {
        public virtual TimeEntity TimeA { get; set; }
        public int GolsA { get; set; }
        public virtual TimeEntity TimeB { get; set; }        
        public int GolsB { get; set; }

        public string CodigoCampeonato { get; set; }
    }
}
