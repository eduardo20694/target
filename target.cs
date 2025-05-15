/*  
1) Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0;
Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
Imprimir(SOMA);
Ao final do processamento, qual será o valor da variável SOMA?   */

using System;

class Program {
    static void Main() {
        int INDICE = 13;
        int SOMA = 0;
        int K = 0;

        while (K < INDICE) {
            K = K + 1;
            SOMA = SOMA + K;
        }

        Console.WriteLine("O valor final de SOMA é: " + SOMA);
    }
}



/*
2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), 
escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.

IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código; */

using System;

class Program {
    static string VerificaFibonacci(int numero) {
        int a = 0;
        int b = 1;

        while (a <= numero) {
            if (a == numero) {
                return $"O número {numero} pertence à sequência de Fibonacci.";
            }

            int proximo = a + b;
            a = b;
            b = proximo;
        }

        return $"O número {numero} não pertence à sequência de Fibonacci.";
    }

    static void Main() {
        int numeroInformado = 13;
        Console.WriteLine(VerificaFibonacci(numeroInformado));
    }
}



/* 
3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
• O menor valor de faturamento ocorrido em um dia do mês;
• O maior valor de faturamento ocorrido em um dia do mês;
• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

IMPORTANTE:
a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média; */

using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public class FaturamentoDia {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    static void Main() {

        List<FaturamentoDia> faturamentoMensal = new List<FaturamentoDia> {
            new FaturamentoDia { Dia = 1, Valor = 22174.1664 },
            new FaturamentoDia { Dia = 2, Valor = 24537.6698 },
            new FaturamentoDia { Dia = 3, Valor = 26139.6134 },
            new FaturamentoDia { Dia = 4, Valor = 0.0 },
            new FaturamentoDia { Dia = 5, Valor = 0.0 },
            new FaturamentoDia { Dia = 6, Valor = 26742.6612 },
            new FaturamentoDia { Dia = 7, Valor = 0.0 },
            new FaturamentoDia { Dia = 8, Valor = 42889.2258 },
            new FaturamentoDia { Dia = 9, Valor = 46251.174 },
            new FaturamentoDia { Dia = 10, Valor = 11191.4722 },
            new FaturamentoDia { Dia = 11, Valor = 0.0 },
            new FaturamentoDia { Dia = 12, Valor = 0.0 },
            new FaturamentoDia { Dia = 13, Valor = 3847.4823 },
            new FaturamentoDia { Dia = 14, Valor = 373.7838 },
            new FaturamentoDia { Dia = 15, Valor = 2659.7563 },
            new FaturamentoDia { Dia = 16, Valor = 48924.2448 },
            new FaturamentoDia { Dia = 17, Valor = 18419.2614 },
            new FaturamentoDia { Dia = 18, Valor = 0.0 },
            new FaturamentoDia { Dia = 19, Valor = 0.0 },
            new FaturamentoDia { Dia = 20, Valor = 35240.1826 },
            new FaturamentoDia { Dia = 21, Valor = 43829.1667 },
            new FaturamentoDia { Dia = 22, Valor = 18235.6852 },
            new FaturamentoDia { Dia = 23, Valor = 4355.0662 },
            new FaturamentoDia { Dia = 24, Valor = 13327.1025 },
            new FaturamentoDia { Dia = 25, Valor = 0.0 },
            new FaturamentoDia { Dia = 26, Valor = 0.0 },
            new FaturamentoDia { Dia = 27, Valor = 25681.8318 },
            new FaturamentoDia { Dia = 28, Valor = 1718.1221 },
            new FaturamentoDia { Dia = 29, Valor = 13220.495 },
            new FaturamentoDia { Dia = 30, Valor = 8414.61 }
        };

        var diasComFaturamento = faturamentoMensal.Where(d => d.Valor > 0).ToList();

        double menorValor = diasComFaturamento.Min(d => d.Valor);
        double maiorValor = diasComFaturamento.Max(d => d.Valor);
        double soma = diasComFaturamento.Sum(d => d.Valor);
        double media = soma / diasComFaturamento.Count;

        int diasAcimaDaMedia = diasComFaturamento.Count(d => d.Valor > media);

        Console.WriteLine($"Menor faturamento diário: R$ {menorValor:F2}");
        Console.WriteLine($"Maior faturamento diário: R$ {maiorValor:F2}");
        Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaDaMedia}");
    }
}



/*
4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
• SP – R$67.836,43
• RJ – R$36.678,66
• MG – R$29.229,88
• ES – R$27.165,48
• Outros – R$19.849,53

Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  
*/


using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
    
        var faturamento = new Dictionary<string, double> {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double total = faturamento.Values.Sum();

        foreach (var estado in faturamento) {
            double percentual = (estado.Value / total) * 100;
            Console.WriteLine($"{estado.Key}: R${estado.Value:F2} - Representa {percentual:F2}% do faturamento total.");
        }
    }
}



/* 5) Escreva um programa que inverta os caracteres de um string.

IMPORTANTE:
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
b) Evite usar funções prontas, como, por exemplo, reverse;

*/

using System;

class Program {
    static string InverterString(string texto) {
        string resultado = "";

        for (int i = texto.Length - 1; i >= 0; i--) {
            resultado += texto[i];
        }

        return resultado;
    }

    static void Main() {
        string texto = "Eduardo";
        string invertido = InverterString(texto);

        Console.WriteLine("Texto original: " + texto);
        Console.WriteLine("Texto invertido: " + invertido);
    }
}
