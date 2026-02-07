namespace eCommerce.Core.DTOs;

public record RegisterRequest(string? Email, string? Password, string? Name, GenderOptions Gender);