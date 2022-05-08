using APIStandBy.Context;
using APIStandBy.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    "Data Source=localhost;Initial Catalog=standby_org;Integrated Security=false;User ID=sa;Password=123adr;"));

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();


//app.MapGet("/", () => "Hello World!");

app.MapPost("AdicionarCliente", async (tb_clientes cliente, AppDbContext contexto) =>
{
    contexto.tb_clientes.Add(cliente);
    await contexto.SaveChangesAsync();
    return contexto.tb_clientes.FirstOrDefault(x => x == cliente);
});

app.MapPost("BuscarCliente/{id}", async (int id, AppDbContext contexto) =>
{
    return await contexto.tb_clientes.FirstOrDefaultAsync(p => p.cl_id == id);
});

app.MapGet("BuscarTodosClientes", async (AppDbContext contexto) =>
{
    return await contexto.tb_clientes.OrderByDescending(x => x.cl_nome).ToListAsync();
});



app.UseSwaggerUI();
app.Run();
