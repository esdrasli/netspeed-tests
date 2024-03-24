using System;

class Alunos
{
    static void Main(string[] args)
    {
        int codigoAluno;
        double nota1, nota2, nota3;

        while (true)
        {
            // Solicita o número do aluno
            Console.Write("Digite o número do aluno (ou 0 para encerrar): ");
            codigoAluno = int.Parse(Console.ReadLine());

            // Verifica se o número do aluno é zero para encerrar o programa
            if (codigoAluno == 0)
            {
                break;
            }

            // Solicita as notas do aluno
            Console.Write("Digite a primeira nota: ");
            nota1 = double.Parse(Console.ReadLine());
            Console.Write("Digite a segunda nota: ");
            nota2 = double.Parse(Console.ReadLine());
            Console.Write("Digite a terceira nota: ");
            nota3 = double.Parse(Console.ReadLine());

            // Calcula a média ponderada
            double maiorNota = Math.Max(Math.Max(nota1, nota2), nota3);
            double media = (4 * maiorNota + 3 * (nota1 + nota2 + nota3 - maiorNota)) / 7;

            // Exibe os resultados
            Console.WriteLine("\nAluno: " + codigoAluno);
            Console.WriteLine("Notas: {0}, {1}, {2}", nota1, nota2, nota3);
            Console.WriteLine("Média: " + media.ToString("F2"));

            // Verifica se o aluno foi aprovado ou reprovado
            if (media >= 6)
            {
                Console.WriteLine("Situação: APROVADO\n");
            }
            else
            {
                Console.WriteLine("Situação: REPROVADO\n");
            }
        }
    }
}
