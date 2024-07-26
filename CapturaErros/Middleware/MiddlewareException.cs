using CapturaErros.DTO;
using System.Diagnostics;
using System.Net;

namespace CapturaErros.Middleware
{
    public class MiddlewareException
    {
        private readonly RequestDelegate _next;

        public MiddlewareException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var _modelErros = new List<ModelErrors>();
            MontaMensagemErro(_modelErros, ex);
            var result = System.Text.Json.JsonSerializer.Serialize(_modelErros);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
            return context.Response.WriteAsync(result);
        }

        private static void MontaMensagemErro(List<ModelErrors> _modelErros, Exception ex)
        {
            _modelErros.Add(new ModelErrors { Mensagem = ex.Message, CodeTrace = ex.StackTrace });
            if (ex.InnerException != null)
            {
                MontaMensagemErro(_modelErros, ex.InnerException);
            }
        }
    }
}
