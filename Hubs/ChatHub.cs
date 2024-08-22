using System.Text.Json;
using ChatApp_backend.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;

namespace ChatApp_backend.Hubs;

public interface IChatClient
{
    public Task ReceiveMessage(string userName, string message);
}


public class ChatHub : Hub<IChatClient>
{
    private readonly IDistributedCache _cache;

    public ChatHub(IDistributedCache cache)
    {
        _cache = cache;
    }
    
    public async Task JoinChat(UserConnection conn)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
        
        var stringConnection = JsonSerializer.Serialize(conn);
        
        await _cache.SetStringAsync(Context.ConnectionId,stringConnection);

        await Clients
            .Group(conn.ChatRoom)
            .ReceiveMessage("admin",$"{conn.Username} connected");
    }

    public async Task SendMessage(string message)
    {
        
        var stringConnection = await _cache.GetAsync(Context.ConnectionId);
        
        var conn = JsonSerializer.Deserialize<UserConnection>(stringConnection);

        if (conn is not null)
        {
            await Clients
                .Group(conn.ChatRoom)
                .ReceiveMessage(conn.Username, message);
        }
        
        
    }


    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var stringConnection = await _cache.GetAsync(Context.ConnectionId);
        
        var conn = JsonSerializer.Deserialize<UserConnection>(stringConnection);

        if (conn is not null)
        {
            await _cache.RemoveAsync(Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conn.ChatRoom);
            
            await Clients
                .Group(conn.ChatRoom)
                .ReceiveMessage("Admin",$"{conn.Username} вышел из чата");
        }
        
        
        
        await base.OnDisconnectedAsync(exception);
    }
}

