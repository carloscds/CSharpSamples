using MCPExemplo.Dados;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

[McpServerToolType]
public class UtilTools
{
    [McpServerTool]
    [Description("popular a base")]
    public CallToolResult PopularBase()
    {
        BaseDados.Seed();
        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = $"Base populada com Cliente, Produto e Pedidos!"
                }
            }
        };
        return result;
    }

    [McpServerTool]
    [Description("limpar a base")]
    public CallToolResult LimparBase()
    {
        BaseDados.Delete();
        var result = new CallToolResult
        {
            IsError = false,
            Content = new List<ContentBlock>
            {
                new TextContentBlock
                {
                    Text = $"Base limpa!"
                }
            }
        };
        return result;
    }
}
