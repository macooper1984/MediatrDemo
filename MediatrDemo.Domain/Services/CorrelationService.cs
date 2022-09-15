using System;
using System.Threading;

namespace MediatrDemo.Domain.Services
{
    public static class CorrelationService
    {
        private static AsyncLocal<Guid?> traceId = new AsyncLocal<Guid?>();


        public static Guid TraceId
        {
            get
            {
                if (HasTraceId)
                {
                    return traceId.Value.Value;
                }
                else
                {
                    return Guid.Empty;
                }
            } 
            set => traceId.Value = value;
        }
        public static bool HasTraceId => traceId.Value != null;
    }
}
