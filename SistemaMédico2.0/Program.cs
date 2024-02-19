using SistemaMédico2._0;
using System;
using System.IO;

class Program
{
    static int Menu()
    {
        Console.WriteLine("\n=-=-= Selecione sua opção =-=-=");
        Console.WriteLine("1 - Agendar Consulta\n2 - Cadastrar Paciente\n3 - Ver Pacientes Cadastrados\n4 - Informações de Paciente\n5 - Cadastrar Médico\n6 - Ver Médicos Cadastrados\n7 - Informações do Médico\n7 - Ver Consultas Agendadas\n0 - Sair");
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

        do
        {
            Resp = Menu();
            switch (Resp)
            {
                case 2:
                    if (ContPacientes <= pacientes.Length)
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
                            break;
                        }
                    }
                    break;
                case 5:
                    if (ContMedicos <= medicos.Length)
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
            }
        } while(Resp != 0);
    }
}