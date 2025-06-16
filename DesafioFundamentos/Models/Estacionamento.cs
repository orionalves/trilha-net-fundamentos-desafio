using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private string padrão = @"^[a-zA-Z]{3}\d[a-zA-Z0-9]\d{2}$";
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string novoVeiculo = Console.ReadLine();
            if (veiculos.Any(x => x.ToUpper() == novoVeiculo.ToUpper()))
            {
                Console.WriteLine("Desculpe, esse veículo já está estacionado aqui. Confira se digitou a placa corretamente");
            }
            else if (Regex.IsMatch(novoVeiculo, padrão))
            {
                veiculos.Add(novoVeiculo);
                Console.WriteLine($"Veículo {novoVeiculo} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Desculpe, a placa precisa estar no padrão alfanumério brasileiro: LLLNNNN ou LLLNLNN");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                bool horasVálidas = false;
                while (!horasVálidas)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    horasVálidas = int.TryParse(Console.ReadLine(), out horas);
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal.ToString("C", new CultureInfo("pt-BR"))}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
