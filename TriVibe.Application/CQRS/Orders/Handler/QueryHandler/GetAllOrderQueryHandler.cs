using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Request;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.QueryHandler;

public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, ResponseModel<List<GetAllOrderQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrderQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<List<GetAllOrderQueryResponse>>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();

        var response = orders.Select(o => new GetAllOrderQueryResponse
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
        }).ToList();

        return new ResponseModel<List<GetAllOrderQueryResponse>>(response);
    }
}
