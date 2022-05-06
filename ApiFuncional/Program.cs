using ApiFuncional.Contexto;
using ApiFuncional.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>
(options => options.UseSqlServer("Data Source=DESKTOP-JIFS59M\\SQLEXPRESS;Initial Catalog=API_FUNCIONAL;Integrated Security=False;User ID=admin;Password=1234;Connect Timeout= 15;Encrypt=False;TrustServerCertificate=False"));


builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AdicionaProduto", async (Produto produto, Contexto contexto) =>
    {
        contexto.Produto.Add(produto);
        await contexto.SaveChangesAsync();
    });

app.MapPost("ExcluirProduto/{id}", async (int id, Contexto contexto) =>
{
    var produtoExcluir = await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);
    if (produtoExcluir != null)
    {
        contexto.Produto.Remove(produtoExcluir);
        await contexto.SaveChangesAsync();
    }
});

app.MapPost("ListarProdutos/{id}", async (Contexto contexto) =>
{
    return await contexto.Produto.ToListAsync();
    
});


app.MapPost("ObterProduto/{id}", async (int id, Contexto contexto) =>
{
    return await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);
});

app.UseSwaggerUI();

app.Run();

