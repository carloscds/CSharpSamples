using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Em produção: a identidade gerenciada do serviço.
// Em desenvolvimento: o usuário logado no Azure CLI (az login).
var clientId = builder.Configuration["Azure:ManagedIdentityClientId"];
TokenCredential credencial = builder.Environment.IsDevelopment()
    ? new AzureCliCredential()
    : new ManagedIdentityCredential(string.IsNullOrEmpty(clientId)
        ? ManagedIdentityId.SystemAssigned
        : ManagedIdentityId.FromUserAssignedClientId(clientId));

// Os segredos do Key Vault passam a fazer parte do IConfiguration
builder.Configuration.AddAzureKeyVault(
    new Uri(builder.Configuration["Azure:KeyVaultUri"]!), credencial);

builder.Services.AddAzureClients(clients =>
{
    clients.AddBlobServiceClient(new Uri(builder.Configuration["Azure:StorageUri"]!));
    clients.UseCredential(credencial);
});

var app = builder.Build();

app.MapGet("/segredo", (IConfiguration config) =>
    Results.Ok(new { carregado = !string.IsNullOrEmpty(config["ChaveApiParceiro"]) }));

app.MapGet("/arquivos", async (BlobServiceClient blobs) =>
{
    var container = blobs.GetBlobContainerClient("documentos");
    var nomes = new List<string>();
    await foreach (var blob in container.GetBlobsAsync())
        nomes.Add(blob.Name);
    return Results.Ok(nomes);
});

app.MapGet("/banco", async (IConfiguration config) =>
{
    await using var conexao = new SqlConnection(config.GetConnectionString("Banco"))
    {
        // O token do Entra ID é obtido pela mesma credencial usada acima
        AccessTokenCallback = async (contexto, cancelamento) =>
        {
            var token = await credencial.GetTokenAsync(
                new TokenRequestContext(["https://database.windows.net/.default"]), cancelamento);
            return new SqlAuthenticationToken(token.Token, token.ExpiresOn);
        }
    };
    await conexao.OpenAsync();
    await using var comando = new SqlCommand("SELECT SUSER_SNAME()", conexao);
    return Results.Ok(new { usuario = await comando.ExecuteScalarAsync() });
});

app.Run();
