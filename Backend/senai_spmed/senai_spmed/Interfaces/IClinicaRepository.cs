using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Interfaces
{
    interface IClinicaRepository
    {

        List<Clinica> ListarTodos();

        Clinica BuscarPorId(int idClinica);

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int idClinica, Clinica clinicaAtualizada);

        void Deletar(int idClinica);
    }
}
