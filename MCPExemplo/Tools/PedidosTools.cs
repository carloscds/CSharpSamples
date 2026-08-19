using MCPExemplo.Dados;
using MCPExemplo.Domain;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

[McpServerToolType]
public class PedidosTools
{
    [McpServerTool]
    [Description("listar pedidos de um cliente")]
    public CallToolResult ListarPedidosCliente(
        [Description("id do cliente")] int clienteID)
    {
        var pedidos = BaseDados.Pedidos.Where(w => w.ClienteId == clienteID);
        var retorno = JsonSerializer.Serialize(pedidos);
        
        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = retorno
                }
            }
        };
        return result;
    }

    [McpServerTool]
    [Description("adicionar pedido para um cliente")]
    public CallToolResult AdicionarPedidoParaCliente(
        [Description("id do cliente")] int clienteID,
        [Description("items do pedido")] List<PedidoItem> items)
    {
        var retorno = "";
        var cliente = BaseDados.Clientes.FirstOrDefault(w => w.Id == clienteID);
        if (cliente == null)
        {
            retorno = "Cliente não encontrado";
        }
        else
        {
            var pedido = new Pedido
            {
                Id = BaseDados.Pedidos.Count+1,
                ClienteId = clienteID,
                Data = DateTime.Now.AddDays(-5),
            };
            pedido.Items.AddRange(items);
            pedido.Valor = BaseDados.CalculaTotalPedido(pedido);
            BaseDados.Pedidos.Add(pedido);
            retorno = $"Pedido {pedido.Id} adicionado ao cliente {cliente.Nome}";
        }

        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = retorno
                }
            }
        };
        return result;
    }

}
