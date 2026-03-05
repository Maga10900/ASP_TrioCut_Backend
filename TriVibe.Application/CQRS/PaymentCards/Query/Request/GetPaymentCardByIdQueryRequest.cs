using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.PaymentCards.Query.Request;

public class GetPaymentCardByIdQueryRequest : IRequest<ResponseModel<GetPaymentCardByIdQueryResponse>>
{
    public Guid Id { get; set; }
}
