using MediatR;
using TriVibe.Application.CQRS.Appointments.Query.Request;
using TriVibe.Application.CQRS.Appointments.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Appointments.Handler.QueryHandler;

public class GetByCustomerEmailQueryHandler : IRequestHandler<GetByCustomerEmailQueryRequest, Pagination<GetByCustomerEmailQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByCustomerEmailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Pagination<GetByCustomerEmailQueryResponse>> Handle(GetByCustomerEmailQueryRequest request, CancellationToken cancellationToken)
    {
        var customerApps = await _unitOfWork.Appointments.GetByCustomerEmailAsync(request.CustomerEmail);
        var totalItems = customerApps.Count;
        var pagedApps = customerApps
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(b => new GetByCustomerEmailQueryResponse
            {
                Id = b.Id,
                AppointmentDate = b.AppointmentDate,
                Status = b.Status,
                BarberEmail = b.BarberEmail,
                ServiceName = b.ServiceName
            })
            .ToList();
        var response = new Pagination<GetByCustomerEmailQueryResponse>(pagedApps, totalItems, request.Page, request.Size);
        return response;
    }
}
