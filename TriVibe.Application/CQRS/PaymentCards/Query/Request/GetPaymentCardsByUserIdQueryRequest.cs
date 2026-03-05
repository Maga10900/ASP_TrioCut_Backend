using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.PaymentCards.Query.Request;

public class GetPaymentCardsByUserIdQueryRequest : IRequest<ResponseModel<GetPaymentCardsByUserIdQueryResponse>>
{
    public Guid UserId { get; set; }
}
