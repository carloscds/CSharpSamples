using System;

namespace InjecaoDependenciaHttpFactory.Models
{
    public class CurrentTime : ICurrentTime
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }
    }
}