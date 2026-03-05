using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.PaymentCards.Command.Request;

public class UpdatePaymentCardCommandRequest : IRequest<ResponseModel<UpdatePaymentCardCommandResponse>>
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
}
