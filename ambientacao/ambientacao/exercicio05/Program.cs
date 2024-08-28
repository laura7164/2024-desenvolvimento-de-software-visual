/* Criar um algoritmo que receba um valor positivo inteiro e imprima a sequência Fibonacci até o valor lido. Por 
exemplo: caso o usuário insira o número 15, o programa deve imprimir na tela os números 0, 1, 1, 2, 3, 5, 8, 13. */

void fibonacci(int numero) {
    if (numero < 0) return;

    int primeiro = 0, segundo = 1, proximo;
        
    Console.Write(primeiro);

    while (segundo <= numero) {
        Console.Write(", " + segundo);

        proximo =  primeiro + segundo;
        primeiro = segundo;
        segundo = proximo;
    }
}

Console.Write("Digite um número inteiro: ");
int numero = int.Parse(Console.ReadLine());

fibonacci(numero);