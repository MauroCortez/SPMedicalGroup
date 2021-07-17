using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Interfaces
{
    interface ISituacaoRepository
    {

        List<Situacao> ListarTodos();

        Situacao BuscarPorId(int idSituacao);

        void Cadastrar(Situacao novaSituacao);

        void Atualizar(int idSituacao, Situacao situacaoAtualizada);

        void Deletar(int idSituacao);
    }
}
