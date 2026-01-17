using MediatR;
using TriVibe.Application.CQRS.Customers.Command.Request;
using TriVibe.Application.CQRS.Customers.Command.Response;
using TriVibe.Common.Extensions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Customers.Handler.CommandHandler;

public class AddCustomerCommandHandler:IRequestHandler<AddCustomerCommandRequest, ResponseModel<AddCustomerCommandResponse>>
{
    private IUnitOfWork _unitOfWork;

    public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddCustomerCommandResponse>> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var hashedPass = PasswordHasher.ComputeStringToSha256Hash(request.PasswordHash);
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = hashedPass,
            PhoneNumber = request.PhoneNumber,
            Age = request.Age,
            UserType = UserType.Customer
		};
        await _unitOfWork.Customers.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();
        var response = new AddCustomerCommandResponse
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email
        };
        return new ResponseModel<AddCustomerCommandResponse>(response);
    }
}
