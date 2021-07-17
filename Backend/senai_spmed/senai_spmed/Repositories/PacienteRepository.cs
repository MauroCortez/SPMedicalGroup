using senai_spmed.Contexts;
using senai_spmed.Domains;
using senai_spmed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {

        SpmedContext ctx = new SpmedContext();
        public void Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            if (pacienteAtualizado.NomePaciente != null)
            {
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
            }

            if (pacienteAtualizado.Endereco != null)
            {
                pacienteBuscado.Endereco = pacienteAtualizado.Endereco;
            }

            if (pacienteAtualizado.Telefone != null)
            {
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
            }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.Find(idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            ctx.Pacientes.Remove(BuscarPorId(idPaciente));

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
