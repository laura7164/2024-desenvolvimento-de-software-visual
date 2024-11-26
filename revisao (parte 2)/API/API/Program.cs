using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();

List<Produto> produtos =
[
    new Produto() { Nome = "Notebook", Preco = 5000, Quantidade = 54 },
    new Produto() { Nome = "Desktop", Preco = 3500, Quantidade = 150 },
    new Produto() { Nome = "Monitor", Preco = 1200, Quantidade = 15 },
    new Produto() { Nome = "Caixa de Som", Preco = 650, Quantidade = 70 },
];

app.MapGet("/", () => "API de Produtos");

// CATEGORIA
// GET: /api/categoria/listar
app.MapGet("/api/categoria/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Categorias.Any()) {
        return Results.Ok(ctx.Categorias.ToList());
    }

    return Results.NotFound();
});

// POST: /api/categoria/cadastrar
app.MapPost("/api/categoria/cadastrar", ([FromBody] Categoria categoria, [FromServices] AppDataContext ctx) =>
{
    ctx.Categorias.Add(categoria);
    ctx.SaveChanges();

    return Results.Created("", categoria);
});


// PRODUTO
// GET: /api/produto/listar
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Any()) {
        return Results.Ok(ctx.Produtos.Include(x => x.Categoria).ToList());
    }

    return Results.NotFound();
});

// GET: /api/produto/buscar/{id}
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.Find(id);

    if (produto == null) {
        return Results.NotFound();
    }

    return Results.Ok(produto);
});

// POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto, [FromServices] AppDataContext ctx) =>
{
    Categoria? categoria = ctx.Categorias.Find(produto.CategoriaId);

    if (categoria is null) {
        return Results.NotFound();
    }

    produto.Categoria = categoria;
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();

    return Results.Created("", produto);
});

// DELETE: /api/produto/deletar/{id}
app.MapDelete("/api/produto/deletar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) => {
    Produto? produto = ctx.Produtos.Find(id);

    if (produto == null) {
        return Results.NotFound();
    }

    ctx.Produtos.Remove(produto);
    ctx.SaveChanges();

    return Results.Ok(produto);
});

// PUT: /api/produto/alterar/{id}
app.MapPut("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado, [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.Find(id);

    if (produto == null) {
        return Results.NotFound();
    }

    Categoria? categoria = ctx.Categorias.Find(produto.CategoriaId);

    if (categoria is null) {
        return Results.NotFound();
    }

    produto.Categoria = categoria;
    produto.Nome = produtoAlterado.Nome;
    produto.Quantidade = produtoAlterado.Quantidade;
    produto.Preco = produtoAlterado.Preco;

    ctx.Produtos.Update(produto);
    ctx.SaveChanges();
    
    return Results.Ok(produto);
});

app.UseCors("Acesso Total");

app.Run();