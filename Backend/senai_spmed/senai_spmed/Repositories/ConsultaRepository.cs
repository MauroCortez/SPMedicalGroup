using Microsoft.EntityFrameworkCore;
using senai_spmed.Contexts;
using senai_spmed.Domains;
using senai_spmed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        SpmedContext ctx = new SpmedContext();
        public void AlterarStatus(int idConsulta, int idNovaSituacao)
        {
            Consultum consultaBuscada = BuscarPorId(idConsulta);

            if (idNovaSituacao == 1 || idNovaSituacao == 2 || idNovaSituacao == 3)
            {
                consultaBuscada.IdSituacao = idNovaSituacao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            Consultum consultaBuscada = BuscarPorId(idConsulta);

            if (consultaAtualizada.IdPaciente > 0)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            if (consultaAtualizada.IdMedico > 0)
            {
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.IdSituacao > 0)
            {
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            if (consultaAtualizada.Descricao != null)
            {
                consultaBuscada.Descricao = consultaAtualizada.Descricao;
            }

            if (consultaAtualizada.DataConsulta >= DateTime.Now)
            {
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            if (consultaAtualizada.IdEspecialidade > 0)
            {
                consultaBuscada.IdEspecialidade = consultaAtualizada.IdEspecialidade;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.Find(idConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            ctx.Consulta.Remove(BuscarPorId(idConsulta));

            ctx.SaveChanges();
        }

        public List<Consultum> ListarMeusMedico(int idUsuario)
        {
            return ctx.Consulta
                .Include("IdMedicoNavigation")
                .Include(i => i.IdPacienteNavigation)
                .Include(i => i.IdSituacaoNavigation)
                .Where(a => a.IdMedicoNavigation.IdUsuario == idUsuario || a.IdPacienteNavigation.IdUsuario == idUsuario)
                .ToList();
        }

        public List<Consultum> ListarMeusPaciente(int idUsuario)
        {
            return ctx.Consulta
                .Include("IdPacienteNavigation")
                .Include(i => i.IdMedicoNavigation)
                .Include(i => i.IdSituacaoNavigation)
                .Where(a => a.IdPacienteNavigation.IdUsuario == idUsuario || a.IdMedicoNavigation.IdUsuario == idUsuario)
                .ToList();
        }

        public List<Consultum> ListarTodos()
        {

            return ctx.Consulta
                .Include(i => i.IdMedicoNavigation)
                .Include(i => i.IdPacienteNavigation)
                .Include(i => i.IdSituacaoNavigation)
                .ToList();
        }
    }
}
