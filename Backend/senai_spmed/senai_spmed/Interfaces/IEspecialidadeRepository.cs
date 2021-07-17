using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Interfaces
{
    interface IEspecialidadeRepository
    {

        List<Especialidade> ListarTodos();

        Especialidade BuscarPorId(int idEspecialidade);

        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(int idEspecialidade, Especialidade especialidadeAtualizada);

        void Deletar(int idEspecialidade);
    }
}
