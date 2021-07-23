import { Component } from "react";
import axios from "axios";

export default class Consultas extends Component{
  constructor(props){
    super(props);
    this.state = {
      // nomeEstado : valorInicial
      listaConsultas : [],
      idMedico : 0,
      idPaciente : 0,
      descricao : '',
      dataConsulta : new Date(),
      horaConsulta : '',
      idSituacao : 0,
      listaMedicos : [],
      listaPacientes : [],
      listaSituacoes : []
    };
  };

  buscarConsultas = () => {
    console.log('Esta função traz todos os atendimentos.')

    fetch('http://localhost:5000/api/consultas', {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      }

      return resposta.json();
    })

    .then(resposta => this.setState({ listaConsultas : resposta }))

    .catch(erro => console.log(erro));
  };

  buscarMedicos = () => {
    fetch('http://localhost:5000/api/medicos', {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      }

      return resposta.json();
    })

    .then(resposta => this.setState({ listaMedicos : resposta }))

    .catch(erro => console.log(erro));
  };

  buscarPacientes = () => {
    fetch('http://localhost:5000/api/pacientes', {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      }

      return resposta.json();
    })

    .then(resposta => this.setState({ listaPacientes : resposta }))

    .catch(erro => console.log(erro));
  };

  buscarSituacoes = () => {
    fetch('http://localhost:5000/api/situacoes', {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      }

      return resposta.json();
    })

    .then(resposta => this.setState({ listaSituacoes : resposta }))

    .catch(erro => console.log(erro));
  };

  componentDidMount(){
    this.buscarConsultas();
    this.buscarMedicos();
    this.buscarPacientes();
    this.buscarSituacoes();
  };

  cadastrarAtendimento = (event) => {
    event.preventDefault();

    let consulta = {
      idPaciente                :     this.state.idPaciente,
      idMedico                  :     this.state.idMedico,
      descricao                 :     this.state.descricao,
      dataConsulta              :     this.state.data + 'T' + this.state.hora,
      idSituacao                :     this.state.idSituacao
    };

    axios.post('http://localhost:5000/api/consultas', consulta, {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if (resposta.status === 201) {
        console.log('Um novo atendimento foi agendado!')
      }
    })

    .catch(erro => console.log(erro))

    .then(this.buscarConsultas);
  }

  atualizaStateCampo = (campo) => {
    // exemplo          idPet           :       1
    this.setState({ [campo.target.name] : campo.target.value })
  };

  render(){
    return(
      <div>
        <h1>Gerenciar Atendimentos</h1>

        <section>
          <h2>Lista de Atendimentos</h2>

          <table>

            <thead>
              <tr>
                <th>#</th>
                <th>Paciente</th>
                <th>Médico</th>
                <th>Descrição</th>
                <th>Data da Consulta</th>
                <th>Situação</th>
              </tr>
            </thead>

            <tbody>

              {
                this.state.listaConsultas.map( (consulta) => {
                  return(

                    <tr key={consulta.idConsulta}>
                      <td>{consulta.idConsulta}</td>
                      {/*<td>{consulta.IdPacienteNavigation.nomePaciente}</td>*/}
                      {/*<td>{consulta.IdMedicoNavigation.nomeMedico}</td>*/}
                      <td>{consulta.descricao}</td>
                      <td>{Intl.DateTimeFormat("pt-BR", {
                        year: 'numeric', month: 'numeric', day: 'numeric',
                        hour: 'numeric', minute: 'numeric',
                        hour12: false
                      }).format(new Date(consulta.dataConsulta))}</td>
                      <td>{consulta.idSituacaoNavigation.nomeSituacao}</td>
                    </tr>

                  )
                } )
              }

            </tbody>

          </table>
        </section>

        <section>
          <h2>Cadastro de Atendimentos</h2>

          {/* Formulário de cadastro */}

          <form onSubmit={this.cadastrarConsulta}>

        
          <select
              name="IdPaciente"
              value={this.state.idPaciente}
              onChange={this.atualizaStateCampo}
            >

              <option value="0">Selecione o paciente que será a consulta</option>

              {
                this.state.listaPacientes.map( (paciente) => {
                  return(
                    <option key={paciente.idPaciente} value={paciente.idPaciente}>{paciente.nomePaciente}</option>
                  )
                } )
              }

            </select>
            {/* <input 
              // Pet
              type="number"
              name="idPet"
              value={this.state.idPet}
              onChange={this.atualizaStateCampo}
            /> */}

            <select
              name="IdMedico"
              value={this.state.idMedico}
              onChange={this.atualizaStateCampo}
            >

              <option value="0">Selecione o Medico que fará a consultas</option>

              {
                this.state.listaConsultas.map( (medico) => {
                  return(
                    <option key={medico.idMedico} value={medico.idMedico}>{medico.nomeMedico}</option>
                  )
                } )
              }

            </select>

            {/* 
            Outra forma
            
            <input 
              // Veterinário
              type="number"
              name="idVeterinario"
              value={this.state.idVeterinario}
              onChange={this.atualizaStateCampo}
            /> 
            
            */}

            <input 
              // Descrição
              type="text"
              name="descricao"
              value={this.state.descricao}
              onChange={this.atualizaStateCampo}
            />

            <input 
              // Data do atendimento
              type="date"
              name="data"
              value={this.state.data}
              onChange={this.atualizaStateCampo}
            />

            <input 
              // Hora do atendimento
              type="time"
              name="hora"
              value={this.state.hora}
              onChange={this.atualizaStateCampo}
            />

              <select
              name="IdSituacao"
              value={this.state.idSituacao}
              onChange={this.atualizaStateCampo}
            >

              <option value="0">Qual a situação da consultas</option>

              {
                this.state.listaSituacoes.map( (situacao) => {
                  return(
                    <option key={situacao.idSituacao} value={situacao.idSituacao}>{situacao.nomeSituacao}</option>
                  )
                } )
              }

            </select>

            {/* <input 
              // Situação
              type="number"
              name="idSituacao"
              value={this.state.idSituacao}
              onChange={this.atualizaStateCampo}
            /> */}

            <button type="submit">
              Cadastrar
            </button>

          </form>

        </section>
      </div>
    )
  }
}

// export default Atendimentos;