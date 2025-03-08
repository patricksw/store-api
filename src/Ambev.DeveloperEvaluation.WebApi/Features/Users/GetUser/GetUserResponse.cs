using Ambev.DeveloperEvaluation.Domain.Enums;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

public class GetUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
}