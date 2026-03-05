using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.PaymentCards.Command.Request;

public class DeletePaymentCardCommandRequest : IRequest<ResponseModel<DeletePaymentCardCommandResponse>>
{
    public Guid Id { get; set; }
}
