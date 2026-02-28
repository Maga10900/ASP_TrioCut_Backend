using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Application.CQRS.Workers.Query.Response;

public class GetAllWorkerQueryResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string? ProfilePhoto { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }
    public string? Job { get; set; }
}
