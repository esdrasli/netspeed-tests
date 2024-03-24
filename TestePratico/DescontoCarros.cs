using System;

class DescontoCarros
{
    static void Main(string[] args)
    {
        char continuar;
        int totalAte2000 = 0;
        int totalGeral = 0;

        do
        {
            Console.WriteLine("Informe o ano do veículo:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor do veículo:");
            double valor = double.Parse(Console.ReadLine());

            double desconto;

            if (ano <= 2000)
            {
                desconto = valor * 0.12;
                totalAte2000++;
            }
            else
            {
                desconto = valor * 0.07;
            }

            double valorComDesconto = valor - desconto;

            Console.WriteLine($"Desconto: R${desconto:F2}");
            Console.WriteLine($"Valor a ser pago: R${valorComDesconto:F2}");

            totalGeral++;

            Console.WriteLine("Deseja continuar calculando desconto? (S/N)");
            continuar = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
        } while (continuar == 'S');

        Console.WriteLine($"Total de carros com ano até 2000: {totalAte2000}");
        Console.WriteLine($"Total geral de carros: {totalGeral}");
    }
}
