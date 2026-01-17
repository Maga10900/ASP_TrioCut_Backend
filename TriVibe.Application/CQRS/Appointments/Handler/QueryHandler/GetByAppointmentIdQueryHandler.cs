using MediatR;
using TriVibe.Application.CQRS.Appointments.Query.Request;
using TriVibe.Application.CQRS.Appointments.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Appointments.Handler.QueryHandler;

public class GetByAppointmentIdQueryHandler : IRequestHandler<GetByAppointmentIdQueryRequest, ResponseModel<GetByAppointmentIdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetByAppointmentIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<GetByAppointmentIdQueryResponse>> Handle(GetByAppointmentIdQueryRequest request, CancellationToken cancellationToken)
    {
        var app = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);
        var response = new GetByAppointmentIdQueryResponse
        {
            Id = app.Id,
            AppointmentDate = app.AppointmentDate,
            Status = app.Status,
            BarberEmail = app.BarberEmail,
            CustomerEmail = app.CustomerEmail,
            ServiceName = app.ServiceName
        };
        return new ResponseModel<GetByAppointmentIdQueryResponse>(response);
    }
}
