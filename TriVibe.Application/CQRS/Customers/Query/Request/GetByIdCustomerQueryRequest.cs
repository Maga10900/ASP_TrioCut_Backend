using MediatR;
using TriVibe.Application.CQRS.Customers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Customers.Query.Request;

public class GetByIdCustomerQueryRequest:IRequest<ResponseModel<GetByIdCustomerQueryResponse>>
{
    public Guid Id { get; set; }
}
