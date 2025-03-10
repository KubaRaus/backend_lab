using ApplicationCore.Commons.Repository;

namespace ApplicationCore.Models;

public class ChatUser : User
{ 
    public string? ConnectionId { get; init; }
}