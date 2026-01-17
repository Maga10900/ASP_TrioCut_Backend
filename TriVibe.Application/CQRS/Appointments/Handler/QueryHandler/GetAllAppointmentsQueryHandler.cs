using MediatR;
using TriVibe.Application.CQRS.Appointments.Query.Request;
using TriVibe.Application.CQRS.Appointments.Query.Response;
using TriVibe.Application.CQRS.Barbers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Appointments.Handler.QueryHandler;

public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQueryRequest, Pagination<GetAllAppointmentsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllAppointmentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Pagination<GetAllAppointmentsQueryResponse>> Handle(GetAllAppointmentsQueryRequest request, CancellationToken cancellationToken)
    {
        var apps = await _unitOfWork.Appointments.GetAllAsync();
        var totalItems = apps.Count;
        var pagedApps = apps
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(b => new GetAllAppointmentsQueryResponse
            {
                Id = b.Id,
                Status = b.Status,
                AppointmentDate = b.AppointmentDate,
                BarberEmail = b.BarberEmail,
                CustomerEmail = b.CustomerEmail,
                ServiceName = b.ServiceName,
                ServicePrice = ((_unitOfWork.Services.GetByNameAsync(b.ServiceName).Result) as Service).Price,
            })
            .ToList();
        var response = new Pagination<GetAllAppointmentsQueryResponse>(pagedApps, totalItems, request.Page, request.Size);
        return response;
    }

}
