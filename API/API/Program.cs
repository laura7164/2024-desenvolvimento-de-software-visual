using API.Migrations;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Folha de pagamento");

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }

    return Results.NotFound();
});

app.MapPost("/api/folha/cadastrar", ([FromBody] FolhaPagamento folha, [FromServices] AppDataContext ctx) =>
{   
    Funcionario? funcionario = ctx.Funcionarios.Find(folha.FuncionarioId);
    if (funcionario == null)
    {
        return Results.NotFound();
    }

    folha.Funcionario = funcionario;

    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("/api/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    List<FolhaPagamento> folhas = ctx.Folhas.Include(f => f.Funcionario).ToList();
    
    if (ctx.Folhas.Any())
    {
        return Results.Ok(ctx.Folhas.ToList());
    }

    return Results.NotFound();
});

app.MapGet("/api/folha/buscar/{cpf}/{ano}/{mes}", ([FromRoute] string? cpf, [FromRoute] int ano, [FromRoute] int mes, [FromServices] AppDataContext ctx) =>
{
    FolhaPagamento? folha = ctx.Folhas.Include(f => f.Funcionario).FirstOrDefault(f => f.Funcionario.CPF == cpf && f.Ano == ano && f.Mes == mes);
    
    if (folha is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(folha);
});

app.MapDelete("/api/funcionrio/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{
    Funcionario? funcionario = ctx.Funcionarios.Find(id);

    if (funcionario is null)
    {
        return Results.NotFound();
    }
    ctx.Funcionarios.Remove(funcionario);
    ctx.SaveChanges();
    return Results.Ok(funcionario);
});

app.Run();
