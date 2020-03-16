using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFInterception
{
    public class InterceptaSQL: IDbCommandInterceptor
    {

        private string arquivoLog;
        public InterceptaSQL()
        {
            string caminho = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            arquivoLog = Path.Combine(caminho, "Log.txt");
        }

        private void EscreveLog(string s)
        {
            StreamWriter log = File.AppendText(arquivoLog);
            log.WriteLine(string.Format("{0} - {1}\n", DateTime.Now.ToString(), s));
            log.Close();
        }
        public void NonQueryExecuting(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            GravaLog("Executando SQL",command, interceptionContext);
        }

        public void NonQueryExecuted(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            GravaLog("SQL executado",command, interceptionContext);
        }

        public void ReaderExecuting(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            GravaLog("Executando Reader",command, interceptionContext);
        }

        public void ReaderExecuted(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            GravaLog("Reader executado",command, interceptionContext);
        }

        public void ScalarExecuting(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            GravaLog("SQL Scalar executando",command, interceptionContext);
        }

        public void ScalarExecuted(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            GravaLog("SQL Scalar executado",command, interceptionContext);
        }

        private void GravaLog<TResult>(string TipoComando,
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception != null)
            {
                EscreveLog(string.Format("ERRO - Comando SQL: {0},  falhou com exceção: {1}",
                    command.CommandText, interceptionContext.Exception));
            }
            else
            {
                EscreveLog(string.Format("{0}: {1}",TipoComando, command.CommandText));
            }
        }
    }
    
}
