using System;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static async Task Main(string[] args)
    {
        string uri = "ws://localhost:5000/ws";
        using var webSocket = new ClientWebSocket();
        await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

        Console.Write("Введите ваше имя: ");
        string username = Console.ReadLine();

        _ = Task.Run(() => ReceiveMessages(webSocket)); // Стартуем поток для получения сообщений

        string message;
        while ((message = Console.ReadLine()) != "/exit")
        {
            await SendMessage(webSocket, $"{username}: {message}");
        }

        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by user", CancellationToken.None);
    }

    private static async Task ReceiveMessages(ClientWebSocket webSocket)
    {
        var buffer = new byte[1024];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine(message);
        }
    }

    private static async Task SendMessage(ClientWebSocket webSocket, string message)
    {
        var buffer = Encoding.UTF8.GetBytes(message);
        await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}