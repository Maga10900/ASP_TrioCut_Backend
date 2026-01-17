using MediatR;
using TriVibe.Application.CQRS.Customers.Query.Response;
using TriVibe.Application.CQRS.Customers.Query.Request;
using TriVibe.Application.CQRS.Customers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Customers.Handler.QueryHandler;

public class GetAllCustomersQueryHandler:IRequestHandler<GetAllCustomersQueryRequest, Pagination<GetAllCustomersQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Pagination<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.Customers.GetAllAsync();
        var totalItems = customers.Count;
        var pagedCategories = customers
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(b => new GetAllCustomersQueryResponse
            {
                Id = b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Email = b.Email,
                Phone = b.PhoneNumber,
                UserType = b.UserType,
                Age = b.Age
			})
            .ToList();
        var response = new Pagination<GetAllCustomersQueryResponse>(pagedCategories, totalItems, request.Page, request.Size);
        return response;
    }
}
