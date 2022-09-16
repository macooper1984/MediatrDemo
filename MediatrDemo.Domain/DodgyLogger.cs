using MediatrDemo.Domain.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MediatrDemo.Domain
{
    public static class DodgyLogger
    {
        public static async Task LogAsync(string message, string fileName = "c:/code/pipelineOutput.txt")
        {
            var str = $"{DateTime.Now.ToShortTimeString()} - {CorrelationService.TraceId} - {message}";

            await File.AppendAllLinesAsync(fileName, new string[] { str });
        }
    }
}
