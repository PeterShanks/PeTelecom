using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Services
{
    internal class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        private void ReleaseUnmanagedResources()
        {
            if(_connection.State != ConnectionState.Closed)
                _connection?.Dispose();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~SqlConnectionFactory()
        {
            ReleaseUnmanagedResources();
        }
    }
}
