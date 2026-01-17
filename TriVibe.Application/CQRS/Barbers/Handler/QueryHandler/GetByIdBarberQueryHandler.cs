using MediatR;
using TriVibe.Application.CQRS.Barbers.Query.Request;
using TriVibe.Application.CQRS.Barbers.Query.Response;
using TriVibe.Common.Exceptions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Barbers.Handler.QueryHandler;

public class GetByIdBarberQueryHandler : IRequestHandler<GetByIdBarberQueryRequest, ResponseModel<GetByIdBarberQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdBarberQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<GetByIdBarberQueryResponse>> Handle(GetByIdBarberQueryRequest request, CancellationToken cancellationToken)
    {
        var barber = await _unitOfWork.Barbers.GetByIdAsync(request.Id);
        if (barber == null)
        {
            throw new NotFoundException("Category not found");
        }
        var response = new GetByIdBarberQueryResponse()
        {
            Id = barber.Id,
            FirstName = barber.FirstName,
            LastName = barber.LastName,
            Description = barber.Description,
            Email = barber.Email,
            PhoneNumber = barber.PhoneNumber,
            Age = barber.Age

		};
        return new ResponseModel<GetByIdBarberQueryResponse>(response);


    }
}