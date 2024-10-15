using API.Models;
namespace API.Migrations;

public class FolhaPagamento
{
    public FolhaPagamento(int quantidade, double valor) {
        Quantidade = quantidade;
        Valor = valor;
        CalcularSalarioBruto();
    }

    public int FolhaPagamentoId {get; set;}
    public double Valor {get; set;}
    public int Quantidade {get; set;}
    public int Mes {get; set;}
    public int Ano {get; set;}
    public int FuncionarioId {get; set;}
    public Funcionario? Funcionario {get; set;}
    public double SalarioBruto {get; set;}

    public void CalcularSalarioBruto(){
        SalarioBruto = Valor * Quantidade;
    }

}
