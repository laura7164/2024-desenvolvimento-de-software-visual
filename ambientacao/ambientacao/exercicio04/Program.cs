/* Desenvolver um algoritmo para ler o valor inteiro da idade de uma pessoa e imprimir uma das mensagens: se idade <= 13: Criança, 
se idade > 13 e <= 18: Adolescente, se idade > 18 e <= 60: Adulto e se idade > 60: Idoso. */

Console.Write("Insira a sua idade: ");
int idade = int.Parse(Console.ReadLine());

if (idade <= 13) {
    Console.WriteLine("Criança");
} else if (idade > 13 && idade <= 18) {
    Console.WriteLine("Adolescente");
} else if (idade > 18 && idade <= 60) {
    Console.WriteLine("Adulto");
} else {
    Console.WriteLine("Idoso");
}