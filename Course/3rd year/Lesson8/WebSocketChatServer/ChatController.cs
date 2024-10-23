using System.Net.WebSockets;
using System.Threading;
using System.Text;
using Microsoft.AspNetCore.Mvc;

public static class ChatController
{
    private static List<WebSocket> _clients = new List<WebSocket>();

    public static async Task HandleWebSocketConnection(WebSocket webSocket)
    {
        _clients.Add(webSocket);
        await NotifyUsersAsync("новый пользователь присоединился к чату");

        while (webSocket.State == WebSocketState.Open)
        {
            var buffer = new byte[1024];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None);
                _clients.Remove(webSocket);
                await NotifyUsersAsync("пользователь покинул чат");
            }

            else
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                await NotifyUsersAsync(message);
            }
        }
    }

    private static async Task NotifyUsersAsync(string message)
    {
        var buffer = Encoding.UTF8.GetBytes(message);
        foreach (var client in _clients)
        {
            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }

}