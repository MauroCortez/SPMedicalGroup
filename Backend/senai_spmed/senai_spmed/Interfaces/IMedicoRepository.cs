using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Interfaces
{
    interface IMedicoRepository
    {

        List<Medico> ListarTodos();

        Medico BuscarPorId(int idMedico);

        void Cadastrar(Medico novoMedico);

        void Atualizar(int idMedico, Medico medicoAtualizado);

        void Deletar(int idMedico);
    }
}
