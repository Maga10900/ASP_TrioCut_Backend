using MediatR;
using TriVibe.Application.CQRS.Customers.Command.Request;
using TriVibe.Application.CQRS.Customers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Customers.Handler.CommandHandler;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, ResponseModel<DeleteCustomerCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;


    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteCustomerCommandResponse>> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
        await _unitOfWork.Customers.DeleteAsync(customer);
        await _unitOfWork.SaveChangesAsync();
        var response = new DeleteCustomerCommandResponse
        {
            Success = true
        };
        return new ResponseModel<DeleteCustomerCommandResponse>(response);
    }
}
