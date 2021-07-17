using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmed.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Consulta = new HashSet<Consultum>();
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }
        public string NomeEspecialidade { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
