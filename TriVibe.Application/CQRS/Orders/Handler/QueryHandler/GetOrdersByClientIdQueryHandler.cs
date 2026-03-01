using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Request;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.QueryHandler;

public class GetOrdersByClientIdQueryHandler : IRequestHandler<GetOrdersByClientIdQueryRequest, ResponseModel<List<GetOrdersByClientIdQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrdersByClientIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<List<GetOrdersByClientIdQueryResponse>>> Handle(GetOrdersByClientIdQueryRequest request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();

        var response = orders
            .Where(o => o.ClientId == request.ClientId)
            .Select(o => new GetOrdersByClientIdQueryResponse
            {
                Id = o.Id,
                WorkerId = o.WorkerId,
                ClientId = o.ClientId,
                Salary = o.Salary,
                Address = o.Address,
                Photos = o.Photos,
                Details = o.Details,
                CreatedDate = o.CreatedDate,
                Status = o.Status
            })
            .ToList();

        return new ResponseModel<List<GetOrdersByClientIdQueryResponse>>(response);
    }
}
