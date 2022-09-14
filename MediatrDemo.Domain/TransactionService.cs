using System.Data.Common;
using System.Threading;

namespace MediatrDemo.Domain
{
    public static class ConnectionService
    {
        private static AsyncLocal<DbConnection> connection = new AsyncLocal<DbConnection>();
        private static AsyncLocal<DbTransaction> transaction = new AsyncLocal<DbTransaction>();

        public static DbConnection Connection
        {
            get => connection.Value;
            set => connection.Value = value;
        }

        public static DbTransaction Transaction
        {
            get => transaction.Value;
            set => transaction.Value = value;
        }
        public static bool HasConnection => connection.Value != null;
    }
}
