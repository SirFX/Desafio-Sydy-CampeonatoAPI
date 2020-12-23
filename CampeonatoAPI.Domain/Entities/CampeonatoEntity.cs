using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Domain.Entities
{
    public class CampeonatoEntity : BaseEntity
    {
        public CampeonatoEntity()
        {
            Partidas = new List<PartidaEntity>();
        }
        public string Nome { get; set; }
        public virtual List<PartidaEntity> Partidas { get; set; }
        public virtual TimeEntity Campeao { get; set; }
        public virtual TimeEntity Vici { get; set; }
        public virtual TimeEntity Terceiro { get; set; }
    }
}
