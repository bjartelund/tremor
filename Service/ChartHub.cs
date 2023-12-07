using System.Diagnostics.Metrics;
using Library;
using Microsoft.AspNetCore.SignalR;

namespace SimpleTresholdService;

public class ChartHub : Hub
{
    private readonly ITremorService _tremorService;

    public ChartHub(ITremorService tremorService)
    {
        _tremorService = tremorService;
    }
    public void SendTremor(int tremor)
    {
        _tremorService.RawMovement = tremor;
        var sampleData = new Tremor.ModelInput() { Movement = tremor };
        var prediction = Tremor.Predict(sampleData);
        _tremorService.IsHighTremor = prediction.PredictedLabel.Equals(1);
    }

    public void SendMeasurements(IEnumerable<AccelerationMeasurement> measurements)
    {
        Console.WriteLine("Received measurements");
        foreach (var accelerationMeasurement in measurements)
        {
            Console.WriteLine(accelerationMeasurement);
        }
        _tremorService.TimedMeasurements = measurements;
    }
    
}