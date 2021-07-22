using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmed.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public int IdSituacao { get; set; }
        public int? IdEspecialidade { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime HoraConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
