namespace eCommerce.Core.DTOs;

public record AuthenticationResponse(
    Guid UserID,
    string? Email,
    string? Name,
    string? Gender,
    string? Token,
    bool Success
);
