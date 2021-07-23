using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Interfaces
{
    interface IConsultaRepository
    {

        List<Consultum> ListarTodos();

        Consultum BuscarPorId(int idConsulta);

        void Cadastrar(Consultum novaConsulta);

        void Atualizar(int idConsulta, Consultum consultaAtualizada);

        void Deletar(int idConsulta);

        List<Consultum> ListarMeus(int idUsuario);

        void AlterarStatus(int idConsulta, int idNovaSituacao);
    }
}
