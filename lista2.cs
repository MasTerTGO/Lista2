using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    public class Ex1
    {

        string nomeArquivo = "Funcionarios.xml";
        List<Funcionario> funcionarios = new List<Funcionario>();
        public void Executar()
        {
            CarregarFuncionarios();

        }
        public class Funcionario
        {
            public string Cpf { get; set; }
            public DateTime DataAniversario { get; set; }
            public DateTime DataIngresso { get; set; }
        }
        public void AdicionaFuncionario()
        {
            Funcionario novoFuncionario = new Funcionario();
            Console.WriteLine("Informe o seu CPF");
            novoFuncionario.Cpf = Console.ReadLine();

            Console.WriteLine("Informe a sua data de aniversário (dd/mm/yyyy)");
            string dataAtualInformada = Console.ReadLine();
            novoFuncionario.DataAniversario = DateTime.ParseExact(dataAtualInformada, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            Console.WriteLine("Informe a data que você ingressou na empresa (dd/mm/yyyy)");
            dataAtualInformada = Console.ReadLine();
            novoFuncionario.DataIngresso = DateTime.ParseExact(dataAtualInformada, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            funcionarios.Add(novoFuncionario);
            SalvarFuncionarios();
        }
        private void SalvarFuncionarios()
        {
            StreamWriter arquivo = new StreamWriter(nomeArquivo);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Funcionario>));
            xmlSerializer.Serialize(arquivo, funcionarios);
            arquivo.Close();
        }
        private void CarregarFuncionarios()
        {
            if (File.Exists(nomeArquivo))
            {
                FileStream stream = System.IO.File.OpenRead(nomeArquivo);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));
                funcionarios = serializer.Deserialize(stream) as List<Funcionario>;
                stream.Close();
            }
            else
            {
                funcionarios = new List<Funcionario>();
            }
        }
        
    }
}
