using MediatrDemo.Domain.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MediatrDemo.Domain
{
    public static class DodgyLogger
    {
        public static async Task LogAsync(string message)
        {
            var str = $"{DateTime.UtcNow.ToShortTimeString()} - {CorrelationService.TraceId} - {message}";

            await File.AppendAllLinesAsync("c:/code/pipelineOutput.txt", new string[] { str });
        }
    }
}
