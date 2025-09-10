// File: Infrastructure/Services/DatabaseService.cs
using System;
using System.Threading.Tasks;
using SQLite;
using HomeCareAI.Models;

namespace HomeCareAI.Infrastructure.Services;

public sealed class DatabaseService : IDisposable
{
    private readonly SQLiteAsyncConnection _connection;

    public DatabaseService(string dbPath)
    {
        if (string.IsNullOrWhiteSpace(dbPath))
            throw new ArgumentException("Database path is required.", nameof(dbPath));

        _connection = new SQLiteAsyncConnection(dbPath);
    }

    public SQLiteAsyncConnection Connection => _connection;

    public async Task InitializeAsync()
    {
        await _connection.CreateTableAsync<TaskItem>(CreateFlags.AllImplicit).ConfigureAwait(false);
    }

    public void Dispose()
    {
        _connection.GetConnection().Close();
    }
}
