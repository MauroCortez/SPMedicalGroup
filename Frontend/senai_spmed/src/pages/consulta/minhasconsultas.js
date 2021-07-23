import { Component } from "react";

export default class MinhasConsultas extends Component{
  constructor(props){
    super(props);
    this.state = {
      // nomeEstado : valorInicial
      listaConsultas : []
    };
  };

  buscarConsultas = () => {
    console.log('Esta função traz todos os atendimentos.')

    fetch('http://localhost:5000/api/atendimentos/meus', {
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

  componentDidMount(){
    this.buscarConsultas();
  };

  render(){
    return(
      <div>
        <h1>Meus Atendimentos</h1>

        <section>
          <h2>Lista de Atendimentos</h2>

          <table>

            <thead>
              <tr>
                <th>#</th>
                <th>Pet</th>
                <th>Veterinário</th>
                <th>Descrição</th>
                <th>Data de Atendimento</th>
                <th>Situação</th>
              </tr>
            </thead>

            <tbody>

              {
                this.state.listaConsulta.map( (consulta) => {
                  return(

                    <tr key={consulta.idConsulta}>
                      <td>{consulta.idConsulta}</td>
                      <td>{consulta.idPacienteNavigation.nomePaciente}</td>
                      <td>{consulta.idMedicoNavigation.nomeMedico}</td>
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
        </section>
      </div>
    )
  }
}

// export default Atendimentos;