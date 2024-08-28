// Escrever um algoritmo que receba a altura e a largura de um retângulo e calcule a sua área

Console.Write("Digite a altura do retângulo: ");
float altura = float.Parse(Console.ReadLine());

Console.Write("Digite a largura do retângulo: ");
float largura = float.Parse(Console.ReadLine());

float area = altura * largura;

Console.WriteLine("Área do retângulo: " + area);