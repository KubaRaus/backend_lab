using System.Collections.Generic;
using System.Linq;

namespace BackendLab01;

public class ChatUserService : IChatUserService
{
    private readonly MemoryGenericRepository<(string ConnectionId, string Username)> _repository;
    
    public ChatUserService()
    {
        _repository = new MemoryGenericRepository<(string, string)>();
    }
    
    public void Add(string connectionId, string username)
    {
        _repository.Add((connectionId, username));
    }

    public void RemoveByName(string username)
    {
        var user = _repository.GetAll().FirstOrDefault(u => u.Username == username);
        if (user != default)
        {
            _repository.Remove(user);
        }
    }

    public string GetConnectionIdByName(string username)
    {
        return _repository.GetAll()
            .Where(u => u.Username == username)
            .Select(u => u.ConnectionId)
            .FirstOrDefault();
    }


    public IEnumerable<(string ConnectionId, string Username)> GetAll()
    {
        return _repository.GetAll();
    }

}

internal class MemoryGenericRepository<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }
}