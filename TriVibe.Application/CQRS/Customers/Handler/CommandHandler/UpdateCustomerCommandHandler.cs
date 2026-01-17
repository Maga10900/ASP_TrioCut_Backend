using MediatR;
using TriVibe.Application.CQRS.Customers.Command.Response;
using TriVibe.Application.CQRS.Customers.Command.Request;
using TriVibe.Application.CQRS.Customers.Command.Response;
using TriVibe.Common.Exceptions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Customers.Handler.CommandHandler;

public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommandRequest, ResponseModel<UpdateCustomerCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateCustomerCommandResponse>> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new NotFoundException("Barber not found");
        }
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.PhoneNumber = request.PhoneNumber;
        customer.Age = request.Age;
        _unitOfWork.Customers.Update(customer);
        await _unitOfWork.SaveChangesAsync();
        var response = new UpdateCustomerCommandResponse()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Age = customer.Age,
        };
        return new ResponseModel<UpdateCustomerCommandResponse>(response);
    }
}
