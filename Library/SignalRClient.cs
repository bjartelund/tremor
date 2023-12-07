using Microsoft.AspNetCore.SignalR.Client;

namespace Library;

public class SignalRClient
{
    private readonly HubConnection _connection;

    public SignalRClient()
    {
        _connection = new HubConnectionBuilder().WithUrl("https://localhost:7212/charthub")
            .WithAutomaticReconnect()
            .Build();
    }

    public async Task Start()
    {
        await _connection.StartAsync();
    }

    public async Task SendAcceleration(Acceleration acceleration)
    {
        await _connection.InvokeAsync("SendAcceleration", acceleration);
    }

    public async Task SendTremor(int tremor)
    {
        await _connection.InvokeAsync("SendTremor", tremor);
    }

    public async Task SendMeasurements(IEnumerable<AccelerationMeasurement> measurements)
    {
        await _connection.InvokeAsync("SendMeasurements", measurements);
    }

}