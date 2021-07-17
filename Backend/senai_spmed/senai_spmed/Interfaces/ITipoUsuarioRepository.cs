using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Interfaces
{
    interface ITipoUsuarioRepository
    {

        List<TipoUsuario> ListarTodos();

        TipoUsuario BuscarPorId(int idTipoUsuario);

        void Cadastrar(TipoUsuario novotipoUsuario);

        void Atualizar(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado);

        void Deletar(int idTipoUsuario);
    }
}
