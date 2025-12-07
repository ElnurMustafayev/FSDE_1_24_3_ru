using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string password_hash { get; set; }

    public override string ToString() => $"#{Id}: {Username} {Email} {password_hash[..3]}***";
}