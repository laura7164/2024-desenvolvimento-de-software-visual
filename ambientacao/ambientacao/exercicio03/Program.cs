// Receber dois números inteiros e informar qual valor lido é o menor e qual é o maior

Console.Write("Digite um número inteiro: ");
int numero1 = int.Parse(Console.ReadLine());

Console.Write("Digite outro número inteiro: ");
int numero2 = int.Parse(Console.ReadLine());

Console.WriteLine("Valores inserios: " + numero1 + " e " +  numero2);
if (numero1 >= numero2) {
    Console.WriteLine("Menor valor: " + numero2);
    Console.WriteLine("Maior valor: " + numero1);
} else {
    Console.WriteLine("Menor valor: " + numero1);
    Console.WriteLine("Maior valor: " + numero2);
}