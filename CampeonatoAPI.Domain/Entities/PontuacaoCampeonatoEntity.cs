using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Domain.Entities
{
    public class PontuacaoCampeonatoEntity : BaseEntity
    {
        public virtual TimeEntity Time { get; set; }
        public string CodigoCampeonato { get; set; }
        public int PontuacaoTime { get; set; }
    }
}
