using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Hubs;

public class RealTimeHub : Hub
{
    public async Task NotifyUpdate(string message)
    {
        await Clients.All.SendAsync("ReceiveUpdate", message);
    }
}