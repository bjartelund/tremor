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
        var outputPath = Guid.NewGuid().ToString();
        var reduced = tremorServiceTimedMeasurements
            .ReducedAccelerationMeasurement()
            .ToList();

        var fourierTransformed = reduced.FourierTransform();

        File.WriteAllLines(outputPath+".csv",tremorServiceTimedMeasurements
            .Select(am=>am.ToString()));
        File.WriteAllLines(outputPath+ "-reduced.csv", reduced
            .Select(am => am.ToString()));
        _tremorService.TimedMeasurements = tremorServiceTimedMeasurements;
        _tremorService.ReducedTimedMeasurements = reduced;
        _tremorService.FourierTransformed = fourierTransformed;
    }
    
}