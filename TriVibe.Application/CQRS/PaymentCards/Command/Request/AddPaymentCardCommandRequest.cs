using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.PaymentCards.Command.Request;

public class AddPaymentCardCommandRequest : IRequest<ResponseModel<AddPaymentCardCommandResponse>>
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
    public Guid UserId { get; set; }
}
