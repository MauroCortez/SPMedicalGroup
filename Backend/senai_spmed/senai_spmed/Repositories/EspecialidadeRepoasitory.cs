using senai_spmed.Contexts;
using senai_spmed.Domains;
using senai_spmed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Repositories
{
    public class EspecialidadeRepoasitory : IEspecialidadeRepository
    {

        SpmedContext ctx = new SpmedContext();
        public void Atualizar(int idEspecialidade, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = BuscarPorId(idEspecialidade);

            if (especialidadeAtualizada.NomeEspecialidade != null)
            {
                especialidadeBuscada.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;
            }

            ctx.Especialidades.Update(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int idEspecialidade)
        {
            return ctx.Especialidades.Find(idEspecialidade);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idEspecialidade)
        {
            ctx.Especialidades.Remove(BuscarPorId(idEspecialidade));

            ctx.SaveChanges();
        }

        public List<Especialidade> ListarTodos()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
