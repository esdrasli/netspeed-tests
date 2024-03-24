using System;

class Boletos
{
    static void Main(string[] args)
    {
        DateTime vencimentoOriginal, vencimentoNovo;

        Console.WriteLine("Informe a data de vencimento original (dd/mm/aaaa):");
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out vencimentoOriginal))
        {
            Console.WriteLine("Data inválida. Por favor, informe no formato dd/mm/aaaa:");
        }

        Console.WriteLine("Informe a data de vencimento nova (data de pagamento) (dd/mm/aaaa):");
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out vencimentoNovo))
        {
            Console.WriteLine("Data inválida. Por favor, informe no formato dd/mm/aaaa:");
        }

        Console.WriteLine("Informe o valor do boleto:");
        double valorBoleto = double.Parse(Console.ReadLine());

        double jurosPorDia = 0.03;
        double multa = 2.00;

        double valorRecalculado = CalcularValorRecalculado(vencimentoOriginal, vencimentoNovo, valorBoleto, jurosPorDia, multa);
        Console.WriteLine($"Valor do boleto recalculado: R$ {valorRecalculado:F2}");

        double totalJuros = CalcularTotalJuros(vencimentoOriginal, vencimentoNovo, jurosPorDia, multa);
        Console.WriteLine($"Valor total dos juros: R$ {totalJuros:F2}");
    }

    static double CalcularValorRecalculado(DateTime vencimentoOriginal, DateTime vencimentoNovo, double valorBoleto, double jurosPorDia, double multa)
    {
        double valorRecalculado = valorBoleto;

        if (vencimentoNovo <= vencimentoOriginal)
        {
            return valorRecalculado;
        }

        TimeSpan periodo = vencimentoNovo - vencimentoOriginal;
        int dias = periodo.Days;

        if (VerificaFinalDeSemana(vencimentoOriginal) || VerificaFeriado(vencimentoOriginal))
        {
            vencimentoOriginal = ProximoDiaUtil(vencimentoOriginal);
        }

        double juros = 0;

        for (int i = 0; i < dias; i++)
        {
            if (VerificaFeriado(vencimentoOriginal.AddDays(i)) || VerificaFinalDeSemana(vencimentoOriginal.AddDays(i)))
            {
                juros += jurosPorDia;
            }
        }

        valorRecalculado += juros;
        valorRecalculado += multa;

        return valorRecalculado;
    }

    static double CalcularTotalJuros(DateTime vencimentoOriginal, DateTime vencimentoNovo, double jurosPorDia, double multa)
    {
        double totalJuros = 0;

        if (vencimentoNovo <= vencimentoOriginal)
        {
            return totalJuros;
        }

        TimeSpan periodo = vencimentoNovo - vencimentoOriginal;
        int dias = periodo.Days;

        if (VerificaFinalDeSemana(vencimentoOriginal) || VerificaFeriado(vencimentoOriginal))
        {
            vencimentoOriginal = ProximoDiaUtil(vencimentoOriginal);
        }

        for (int i = 0; i < dias; i++)
        {
            if (VerificaFeriado(vencimentoOriginal.AddDays(i)) || VerificaFinalDeSemana(vencimentoOriginal.AddDays(i)))
            {
                totalJuros += jurosPorDia;
            }
        }

        totalJuros += multa;

        return totalJuros;
    }

    static bool VerificaFeriado(DateTime data)
    {
        return false;
    }

    static bool VerificaFinalDeSemana(DateTime data)
    {
        return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
    }

    static DateTime ProximoDiaUtil(DateTime data)
    {
        do
        {
            data = data.AddDays(1);
        }
        while (VerificaFinalDeSemana(data) || VerificaFeriado(data));

        return data;
    }
}
