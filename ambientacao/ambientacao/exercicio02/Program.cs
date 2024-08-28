/* Crie um algoritmo que permita fazer três conversões monetárias. O algoritmo deve receber o valor em real (R$) e 
apresentar os valores convertidos em:
    1. Dólar (1 dólar = 5,17 reais)
    2. Euro (1 euro = 6,14 reais)
    3. Peso argentino (1 peso argentino = 0,05 reais) */

Console.Write("Digite em reais o valor a ser convertido: " );
float valor = float.Parse(Console.ReadLine());

Console.WriteLine("Valor em reais inserido: " + valor + " R$");
Console.WriteLine("Conversões feitas:");
Console.WriteLine("1. Dólar: " + (valor / 5.17).ToString("N2") + " dólares");
Console.WriteLine("2. Euro: " + (valor / 6.14).ToString("N2") + " euros");
Console.WriteLine("3. Peso argentino: " + (valor * 168.47) + " pesos argentinos");

// ToString("N2") -> deixar só 2 números depois da virgula