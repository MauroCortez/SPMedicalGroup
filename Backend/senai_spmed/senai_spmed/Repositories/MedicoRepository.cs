using senai_spmed.Contexts;
using senai_spmed.Domains;
using senai_spmed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        SpmedContext ctx = new SpmedContext();
        public void Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            if (medicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.Find(idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            ctx.Medicos.Remove(BuscarPorId(idMedico));

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}
