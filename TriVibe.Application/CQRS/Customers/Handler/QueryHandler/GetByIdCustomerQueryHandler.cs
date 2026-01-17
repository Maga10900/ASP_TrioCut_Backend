using MediatR;
using TriVibe.Application.CQRS.Customers.Query.Response;
using TriVibe.Application.CQRS.Customers.Query.Request;
using TriVibe.Common.Exceptions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Customers.Handler.QueryHandler;

public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, ResponseModel<GetByIdCustomerQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCustomerQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseModel<GetByIdCustomerQueryResponse>> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new NotFoundException("Customer not found");
        }
        var response = new GetByIdCustomerQueryResponse()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Age = customer.Age

		};
        return new ResponseModel<GetByIdCustomerQueryResponse>(response);
    }
}
