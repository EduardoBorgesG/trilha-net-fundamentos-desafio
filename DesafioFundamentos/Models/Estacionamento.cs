using System.Security.Cryptography.X509Certificates;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placaVeiculo;
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placaVeiculo = Console.ReadLine();
            //Verifica se a placa do veiculo não é NULL e adiciona na lista
            if (!String.IsNullOrEmpty(placaVeiculo)){
                if (veiculos.IndexOf(placaVeiculo)<0){
                    veiculos.Add(placaVeiculo.ToUpper());
                }
            }
        }

        public void RemoverVeiculo()
        {
            string placa;
            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();
            placa = placa.ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                //Efetua o calculo do valor que precisa ser pago pelo tempo que o carro ficou no estacionamento         
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Percorre a lista e mostra os veiculos que estão cadastrados
                foreach (var listaVeiculos in veiculos)
                {
                    Console.WriteLine(listaVeiculos);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
