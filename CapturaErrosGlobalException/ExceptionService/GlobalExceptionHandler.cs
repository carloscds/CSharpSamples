using CapturaErros.DTO;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace CapturaErros.ExceptionHandler
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var _modelErros = new List<ModelErrors>();
            MontaMensagemErro(_modelErros, exception);
            var errorJson = System.Text.Json.JsonSerializer.Serialize(_modelErros);
            logger.LogError(errorJson);
            httpContext.Response.ContentType = Application.Json;
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(errorJson, cancellationToken).ConfigureAwait(false);
            return true;
        }

        private void MontaMensagemErro(List<ModelErrors> _modelErros, Exception ex)
        {
            _modelErros.Add(new ModelErrors { Mensagem = ex.Message, CodeTrace = ex.StackTrace });
            if (ex.InnerException != null)
            {
                MontaMensagemErro(_modelErros, ex.InnerException);
            }
        }
    }
}
