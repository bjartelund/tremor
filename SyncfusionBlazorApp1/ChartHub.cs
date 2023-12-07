using Library;
using Microsoft.AspNetCore.SignalR;

namespace GraphTimedMeasurements;

public class ChartHub : Hub
{
    private readonly ITremorService _tremorService;

    public ChartHub(ITremorService tremorService)
    {
        _tremorService = tremorService;
    }

    public void SendMeasurements(IEnumerable<AccelerationMeasurement> measurements)
    {
        Console.WriteLine("Received measurements");
        var tremorServiceTimedMeasurements = measurements.ToList();
        foreach (var accelerationMeasurement in tremorServiceTimedMeasurements)
        {
            Console.WriteLine(accelerationMeasurement);
        }
        _tremorService.TimedMeasurements = tremorServiceTimedMeasurements;
    }
    
}