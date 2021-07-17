using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Interfaces
{
    interface IPacienteRepository
    {

        List<Paciente> ListarTodos();

        Paciente BuscarPorId(int idPaciente);

        void Cadastrar(Paciente novoPaciente);

        void Atualizar(int idPaciente, Paciente pacienteAtualizado);

        void Deletar(int idPaciente);
    }
}
