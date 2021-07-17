use senai_spmed;
go

insert into tipoUsuario (tituloTipoUsuario)
values					('Administrador')
					   ,('Médico')
					   ,('Paciente');
go

insert into Usuario (idTipoUsuario, email, senha)
values	             (1, 'adm@adm.com', 'adm123')
         			,(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123')
					,(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle123')
					,(2, 'helena.souza@spmedicalgroup.com.br', 'helena123')
					,(3, 'marta@gmail.com', 'marta123')
					,(3, 'alex@gmail.com', 'alex123')
					,(3, 'marquinhos@gmail.com', 'marquinhos123')
					,(3, 'daniel@gmail.com', 'daniel123')
					,(3, 'thiago@gmail.com', 'thiago123')
					,(3, 'bruno@gmail.com', 'bruno123')
					,(3, 'angelica@outlook.com', 'angelica123')
go

insert into especialidade (nomeEspecialidade)
values					  ('Acupuntura')
						 ,('Anestesiologia')
						 ,('Angiologia')
						 ,('Cardiologia')
						 ,('Cirurgia Cardiovascular')
						 ,('Cirurgia de Mão')
						 ,('Cirurgia do Aparelho Digestivo')
						 ,('Cirurgia Geral')
						 ,('Cirurgia Pediátrica')
						 ,('Cirurgia Plástica')
						 ,('Cirurgia Torácica')
						 ,('Cirurgia Vascular')
						 ,('Dermatologia')
						 ,('Radioterapia')
						 ,('Urologia')
						 ,('Pediatria')
						 ,('Psiquiatria');
go

insert into clinica (CNPJ,horarioAbertura, horarioFechamento, endereco, nomeFantasia, razaoSocial)
values				('86412992456130','8:30', '21:30', 'Av. Barão Limeira, 532', 'Clinica Possarle', 'SP Médical Group');
go

insert into medico (idUsuario, idEspecialidade, idClinica, nomeMedico,CRM)
values			   (2, 2, 1,'Ricardo Lemos','12345-SP')
				  ,(3, 17, 1, 'Roberto Possarle' ,'54321-SP')
				  ,(4, 16, 1, 'Helena Strada' ,'11111-SP');
go

insert into paciente (idUsuario, dataNascimento, nomePaciente, RG, CPF, telefone, endereco)
values				 (5, '10/03/1983', 'Marta','594556311', '15625489632', '1195846321', 'Rua Patolino 240, Rua do Bruxo, São Paulo, 74005-666')
					,(6, '07/03/2001', 'Alex','284631587', '13697468251', '11956565656', 'Av. Pernalonga, 1578 - Toca, São Paulo - SP, 16548-200')
					,(7, '10/10/1978', 'Marquinhos','168745239', '13974682593', null, 'Av. Frajola - Itaquera, 2927,  São Paulo - SP, 04269-200')
					,(8, '13/10/1985', 'Daniel','125478963', '16482000146', '11922546433', 'R. Taz, 120 - Barueri - SP, 96402-900')
					,(9, '27/08/1975', 'Thiago','156874632', '16849100560', '11912344321', 'R. Lola, 66 - Casa Verde- SP, 59605-380')
					,(10, '21/03/1972', 'Bruno','951647826', '48468465132', '11955684712', 'Alameda dos Lonneytoones, 945 - Capao Redondo, São Paulo - SP, 01111-111')
					,(11, '05/03/2018','Angelica','136548269', '16495321658', null, 'R Gaguinho, 232 - Vila Universal, Helipa - SP, 17771-141');
go

insert into situacao (situacao)
values				 ('Realizada')
					,('Cancelada')
					,('Agendada');
go

insert into consulta (idMedico, idPaciente, idSituacao, idEspecialidade, dataConsulta, horaConsulta, descricao)
values				 (3, 7, 1, 16, '14/04/2021', '12:30', 'Bronquite e Sinisute atacada')
					,(2, 2, 2, 17, '28/03/2021', '11:30', 'Paciente com ansiedade')
					,(2, 3, 1, 17, '29/03/2021', '10:00', 'Paciente com sindrome de burnout')
					,(2, 2, 1, 17, '08/04/2021', '15:00', 'Paciente com tendencia de automutilacao')
					,(1, 4, 2, 1, '21/05/2021', '14:00', 'anemia')
					,(3, 7, 3, 16, '30/03/2021', '14:30', 'Criança com dor nas costas')
					,(1, 4, 3, 13, '06/04/2021', '13:00', 'Manchas na pele');
go