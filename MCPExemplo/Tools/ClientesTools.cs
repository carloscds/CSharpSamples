using MCPExemplo.Dados;
using MCPExemplo.Domain;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

[McpServerToolType]
public class ClientesTools
{
    [McpServerTool]
    [Description("adiciona um novo cliente")]
    public CallToolResult Adicionar(
        McpServer server,
        RequestContext<CallToolRequestParams> context,
        [Description("nome do cliente")] string nomeCliente)
    {
        var perguntaChat = context.Params.Arguments["chatInput"].ToString();
        BaseDados.Clientes.Add(new Cliente { Nome = nomeCliente, Id = BaseDados.Clientes.Count + 1 });

        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = $"Cliente {nomeCliente} adicionado com sucesso!"
                }
            }
        };
        return result;
    }

    [McpServerTool]
    [Description("retorna codigo do cliente")]
    public CallToolResult RetornaCodigo(
        McpServer server,
        RequestContext<CallToolRequestParams> context,
        [Description("nome do cliente")] string nomeCliente)
    {
        var dadosRetorno = "";
        var dados = BaseDados.Clientes.FirstOrDefault(w => w.Nome.Contains(nomeCliente));
        if(dados != null)
        {
            dadosRetorno = dados.Id.ToString();
        }
        else
        {
            dadosRetorno = "Cliente não encontrado";
        }
        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = dadosRetorno
                }
            }
        };
        return result;
    }

    [McpServerTool]
    [Description("deleta ou apaga um cliente")]
    public CallToolResult Deletar([Description("nome do cliente")] string nomeCliente)
    {
        var dadosRetorno = "";
        var dados = BaseDados.Clientes.FirstOrDefault(w => w.Nome.Contains(nomeCliente));
        if (dados != null)
        {
            BaseDados.Clientes.Remove(dados);
            dadosRetorno = $"Cliente {nomeCliente} deletado com sucesso!";
        }
        else
        {
            dadosRetorno = "Cliente não encontrado";
        }
        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = dadosRetorno
                }
            }
        };
        return result;
    }

    [McpServerTool]
    [Description("lista os clientes")]
    public CallToolResult Listar()
    {
        string jsonString = JsonSerializer.Serialize(BaseDados.Clientes);
        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text =jsonString
                }
            }
        };
        return result;
    }

    [McpServerTool]
    [Description("limpe a lista de clientes")]
    public CallToolResult Limpar()
    {
        BaseDados.Clientes.Clear();
        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = "Lista de clientes limpa com sucesso!"
                }
            }
        };
        return result;
    }
}
