using System;
using System.Threading;

namespace MediatrDemo.Domain
{
    public static class CorrelationService
    {
        private static AsyncLocal<Guid?> traceId = new AsyncLocal<Guid?>();


        public static Guid TraceId
        {
            get => traceId.Value.Value;
            set => traceId.Value = value;
        }
        public static bool HasTraceId => traceId.Value != null;
    }
}
