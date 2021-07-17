using senai_spmed.Contexts;
using senai_spmed.Domains;
using senai_spmed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Repositories
{

    
    public class ClinicaRepository : IClinicaRepository
    {

        SpmedContext ctx = new SpmedContext();
        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            if (clinicaAtualizada.HorarioAbertura = TimeZoneInfo.)
            {
                clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
            }

            if (clinicaAtualizada.HorarioFechamento = TimeZoneInfo.)
            {
                clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;
            }

            if (clinicaAtualizada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            }

            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.Find(idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            ctx.Clinicas.Remove(BuscarPorId(idClinica));

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
