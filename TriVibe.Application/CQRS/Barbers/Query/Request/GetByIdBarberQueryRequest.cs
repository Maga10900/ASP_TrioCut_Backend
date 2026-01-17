using MediatR;
using TriVibe.Application.CQRS.Barbers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Barbers.Query.Request;

public class GetByIdBarberQueryRequest:IRequest<ResponseModel<GetByIdBarberQueryResponse>>
{
   public Guid Id { get; set; }
}
