using SistemaMédico2._0;
using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static int Menu()
    {
        Console.WriteLine("\n=-=-= Selecione sua opção =-=-=");
        Console.WriteLine("1 - Agendar Consulta\n2 - Cadastrar Paciente\n3 - Ver Pacientes Cadastrados\n4 - Informações de Paciente\n5 - Cadastrar Médico\n6 - Ver Médicos Cadastrados\n7 - Informações do Médico\n8 - Ver Consultas Agendadas\n0 - Sair");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        Console.Write("Opção: ");
        int Resp = int.Parse(Console.ReadLine());

        return Resp;
    }
    public static void Main(string[] args)
    {
        int Resp = 0;
        int ContPacientes = 0;
        int ContMedicos = 0;
        int ContConsultas = 0;
        Paciente[] pacientes = new Paciente[3];
        Medico[] medicos = new Medico[3];
        Consultas[] consultas = new Consultas[3];

        do
        {
            Resp = Menu();
            switch (Resp)
            {
                case 1:
                    int dia, mes, ano, idMedico, idPaciente;
                    string horario;
                    bool fimDeSemana = true;
                    bool foraDoHorario = true;
                    bool idFalso = true;
                    TimeSpan horaConsulta = new TimeSpan();
                    do
                    {
                        do
                        {
                            Console.WriteLine("Dia: ");
                            dia = int.Parse(Console.ReadLine());
                            Console.WriteLine("Mês: ");
                            mes = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ano: ");
                            ano = int.Parse(Console.ReadLine());
                            DateOnly dateTime = new DateOnly(ano, mes, dia);
                            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
                            {
                                Console.WriteLine("O consultório não atende em finais de semana!");
                            }
                            else
                            {
                                fimDeSemana = false;
                            }
                        } while(fimDeSemana == true);
                        Console.Write("Digite o ID do paciente a ser consultado: ");
                        idPaciente = int.Parse(Console.ReadLine());

                        do
                        {
                            Console.Write("Digite o ID do médico que realizará a consulta: ");
                            idMedico = int.Parse(Console.ReadLine());
                            for (int i = 0; i < ContMedicos; i++)
                            {
                                if (medicos[i].ID == idMedico)
                                {
                                    medicos[i].AgendarConsulta();
                                    idFalso = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"O ID {idMedico} informado não existe.");
                                }
                            }
                        } while (idFalso == true);
                        do
                        {
                            TimeSpan horaInicio = new TimeSpan(8, 0, 0); // 08:00
                            TimeSpan horaFim = new TimeSpan(18, 0, 0); // 18:00
                            Console.WriteLine("Horário do atendimento: ");
                            horario = Console.ReadLine();
                            horaConsulta = TimeSpan.Parse(horario);
                            if(horaConsulta >= horaInicio && horaConsulta <= horaFim)
                            {
                                foraDoHorario = false;
                            }
                            else
                            {
                                Console.WriteLine("O horário da consulta está fora do horário de funcionamento do consultório!");
                            }
                        } while (foraDoHorario == true);
                    } while(fimDeSemana == true && foraDoHorario == true);
                    if (ContConsultas < consultas.Length)
                    {
                        consultas[ContConsultas] = new Consultas();
                        consultas[ContConsultas].Agendar(dia, mes, ano, horario, idMedico, idPaciente);
                        ContConsultas++;
                    }
                    break;
                case 2:
                    if (ContPacientes < pacientes.Length)
                    {
                        pacientes[ContPacientes] = new Paciente();
                        pacientes[ContPacientes].Cadastrar();
                        ContPacientes++;
                    }
                    else
                    {
                        Console.WriteLine("Número máximo de pacientes cadastrados atingido!");
                    }
                    break;
                case 3:
                    Console.WriteLine("Pacientes:");
                    for (int i = 0; i < ContPacientes; i++)
                    {
                        pacientes[i].ImprimirLista();
                    }
                    break;
                case 4:
                    Console.WriteLine("Digite o ID do paciente:");
                    int ID = int.Parse(Console.ReadLine());
                    for(int i = 0; i < ContPacientes; i++)
                    {
                        if (pacientes[i].ID == ID)
                        {
                            pacientes[i].Imprimir();
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"O ID {ID} informado não existe.");
                        }
                    }
                    break;
                case 5:
                    if (ContMedicos < medicos.Length)
                    {
                        medicos[ContMedicos] = new Medico();
                        medicos[ContMedicos].Cadastrar();
                        ContMedicos++;
                    }
                    else
                    {
                        Console.WriteLine("Número máximo de médicos cadastrados atingido!");
                    }
                    break;
                case 6:
                    Console.WriteLine("Médicos:");
                    for (int i = 0; i < ContMedicos; i++)
                    {
                        medicos[i].ImprimirLista();
                    }
                    break;
                case 7:
                    Console.WriteLine("Digite o ID do médico:");
                    ID = int.Parse(Console.ReadLine());
                    for (int i = 0; i < ContMedicos; i++)
                    {
                        if (medicos[i].ID == ID)
                        {
                            medicos[i].Imprimir();
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"O ID {ID} informado não existe.");
                        }
                    }
                    break;
                case 8:
                    if(consultas == null || consultas.Length == 0)
                    {
                        Console.WriteLine("Nenhuma consulta marcada!");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < ContConsultas; i++)
                        {
                            Console.WriteLine($"Consultas marcadas: {ContConsultas}");
                            consultas[i].ConsultasAgendadas();
                        }
                    }
                    break;
            }
        } while(Resp != 0);
    }
}