using senai_spmed.Contexts;
using senai_spmed.Domains;
using senai_spmed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {

        SpmedContext ctx = new SpmedContext();
        public void Atualizar(int idSituacao, Situacao situacaoAtualizada)
        {
            Situacao situacaoBuscada = BuscarPorId(idSituacao);

            if (situacaoAtualizada.Situacao1 != null)
            {
                situacaoBuscada.Situacao1 = situacaoAtualizada.Situacao1;
            }

            ctx.Situacaos.Update(situacaoBuscada);

            ctx.SaveChanges();
        }

        public Situacao BuscarPorId(int idSituacao)
        {
            return ctx.Situacaos.Find(idSituacao);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            ctx.Situacaos.Remove(BuscarPorId(idSituacao));

            ctx.SaveChanges();
        }

        public List<Situacao> ListarTodos()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
