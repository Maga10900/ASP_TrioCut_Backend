using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Request;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.QueryHandler;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, ResponseModel<GetOrderByIdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);

        var response = new GetOrderByIdQueryResponse
        {
            Id = order.Id,
            WorkerId = order.WorkerId,
            Salary = order.Salary,
            Address = order.Address,
            Photos = order.Photos,
            Details = order.Details,
            CreatedDate = order.CreatedDate
        };

        return new ResponseModel<GetOrderByIdQueryResponse>(response);
    }
}
