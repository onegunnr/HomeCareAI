using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// File: Domain/Models/TaskItem.cs
using System;
using SQLite;

namespace HomeCareAI.Models;

/// <summary>
/// Lightweight POCO for sqlite-net-pcl.
/// </summary>
[Table("TaskItems")]
public class TaskItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Notes { get; set; }

    [Indexed]
    public DateTime? DueDateUtc { get; set; }

    [Indexed]
    public bool IsCompleted { get; set; }

    public DateTime? CompletedAtUtc { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime UpdatedAtUtc { get; set; }

    /// <summary>
    /// Factory with sensible defaults:
    /// - trims title, enforces max length (200)
    /// - IsCompleted = false
    /// - CreatedAtUtc/UpdatedAtUtc = UtcNow
    /// - optional notes and due date
    /// </summary>
    public static TaskItem New(string title, string? notes = null, DateTime? dueDateUtc = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));

        var trimmed = title.Trim();
        if (trimmed.Length > 200)
            trimmed = trimmed.Substring(0, 200);

        var now = DateTime.UtcNow;

        return new TaskItem
        {
            Title = trimmed,
            Notes = notes,
            DueDateUtc = dueDateUtc,
            IsCompleted = false,
            CompletedAtUtc = null,
            CreatedAtUtc = now,
            UpdatedAtUtc = now
        };
    }
}


