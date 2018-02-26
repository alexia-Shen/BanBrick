using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Extensions
{
    public static class DatabaseExtensions
    {
        public static void EnsureMigrate(this DatabaseFacade databaseFacade)
        {
            using (var connection = databaseFacade.GetDbConnection())
            {
                var database = connection.Database;
                connection.ClearDatabase();
                connection.Open();

                connection.CreateDatabase(database);
                connection.ChangeDatabase(database);
                connection.CreateHistoryTable();
            }

            databaseFacade.Migrate();
        }

        public static void CreateDatabase(this IDbConnection dbConnection, string database)
        {
            string script = $"CREATE DATABASE IF NOT EXISTS {database}";
            ExecuteNonQuery(script, dbConnection);
        }
        
        public static void CreateHistoryTable(this IDbConnection dbConnection)
        {
            string script = "CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (`MigrationId` nvarchar(150) NOT NULL, `ProductVersion` nvarchar(32) NOT NULL, PRIMARY KEY(`MigrationId`));";
            ExecuteNonQuery(script, dbConnection);
        }

        public static void ClearDatabase(this IDbConnection dbConnection)
        {
            var connectionString = string.Join(";", dbConnection.ConnectionString.Split(';')
                .Select(x => x.Split('=').Select(y => y.Trim()).ToList())
                .Where(x => !x[0].Equals("database", StringComparison.CurrentCultureIgnoreCase))
                .Select(x => $"{x[0]}={x[1]}"));

            dbConnection.ConnectionString = connectionString;
        }

        private static void ExecuteNonQuery(string script, IDbConnection connection)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = script;
                command.ExecuteNonQuery();
            }
        }

        private static string ExecuteScalar(string script, IDbConnection connection)
        {
            string result;
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = script;
                result = command.ExecuteScalar().ToString();
            }
            return result;
        }
    }
}
