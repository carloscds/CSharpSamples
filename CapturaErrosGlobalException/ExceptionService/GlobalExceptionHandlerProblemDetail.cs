using CapturaErros.DTO;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Net;

namespace CapturaErros.ExceptionHandler
{
    public class GlobalExceptionHandlerProblemDetail(ILogger<GlobalExceptionHandlerProblemDetail> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var _pd = new List<ProblemDetails>();
            MontaMensagemErroPD(_pd, httpContext.Request.Path.ToString(), exception);
            var errorJson = System.Text.Json.JsonSerializer.Serialize(_pd);
            logger.LogError("{ProblemDetails}", errorJson);
            httpContext.Response.ContentType = Application.Json;
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(errorJson, cancellationToken).ConfigureAwait(false);
            return true;
        }

        private void MontaMensagemErroPD(List<ProblemDetails> _pd, string pathString, Exception ex)
        {
            _pd.Add(new ProblemDetails{ Instance = pathString, Title = ex.Message, Detail = ex.StackTrace });
            if (ex.InnerException != null)
            {
                MontaMensagemErroPD(_pd, pathString, ex.InnerException);
            }
        }
    }
}
