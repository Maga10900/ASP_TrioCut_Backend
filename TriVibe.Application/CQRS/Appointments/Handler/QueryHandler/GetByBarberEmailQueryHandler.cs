using MediatR;
using TriVibe.Application.CQRS.Appointments.Query.Request;
using TriVibe.Application.CQRS.Appointments.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Appointments.Handler.QueryHandler;

public class GetByBarberEmailQueryHandler : IRequestHandler<GetByBarberEmailQueryRequest, Pagination<GetByBarberEmailQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetByBarberEmailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Pagination<GetByBarberEmailQueryResponse>> Handle(GetByBarberEmailQueryRequest request, CancellationToken cancellationToken)
    {
        var apps = await _unitOfWork.Appointments.GetByBarberEmailAsync(request.BarberEmail);
        var totalItems = apps.Count;
        var pagedApps = apps
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(b => new GetByBarberEmailQueryResponse
            {
                Id = b.Id,
                AppointmentDate = b.AppointmentDate,
                Status = b.Status,
                CustomerEmail = b.CustomerEmail,
                ServiceName = b.ServiceName,
                CustomerName =  (_unitOfWork.Customers.GetByEmailAsync(b.CustomerEmail).Result as Customer).FirstName + " " + (_unitOfWork.Customers.GetByEmailAsync(b.CustomerEmail).Result as Customer).LastName
            });
        var response = new Pagination<GetByBarberEmailQueryResponse>(pagedApps.ToList(), totalItems, request.Page, request.Size);
        return response;
    }
}
