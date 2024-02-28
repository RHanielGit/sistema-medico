using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMédico2._0
{
    class Consultas
    {
        private int numConsulta;
        private int idMedico;
        private int idPaciente;
        private TimeSpan horarioAgendado = new TimeSpan();
        private DateOnly dateTime = new DateOnly();

        public int IDMedico => idMedico;
        

        public void Agendar(int dia, int mes, int ano, string horario, int _idMedico, int _idPaciente)
        {
            dateTime = new DateOnly(ano, mes, dia);
            Random rdn = new Random(1000);
            numConsulta = rdn.Next(1000, 10000);
            idMedico = _idMedico;
            idPaciente = _idPaciente;
            horarioAgendado = TimeSpan.Parse(horario);
        }

        public void ConsultasAgendadas()
        {
            Console.WriteLine($"Data: {dateTime}\nHorario: {horarioAgendado}\nMédico: {idMedico}\nPaciente: {idPaciente}");
        }

        public void ImprimirConsultasMedico()
        {
            Console.WriteLine($"Número da Consulta: {numConsulta}\nPaciente: {idPaciente}\nData: {dateTime}\nHorário: {horarioAgendado}");
        }
    }
}
