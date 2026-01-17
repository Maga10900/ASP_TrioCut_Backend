using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.DTOs;

namespace TriVibe.Application.CQRS.Barbers.Command.Request;

public class AddBarberCommandRequest:IRequest<ResponseModel<AddBarberCommandResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string? ImageUrl { get; set; }//Profil Sekli
    public string? Description { get; set; }// Haqqında qısa məlumat
    public double Rating { get; set; } // Bərbərin reytinqi
}
