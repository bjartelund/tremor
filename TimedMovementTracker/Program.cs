// See https://aka.ms/new-console-template for more information

using Library;

Console.WriteLine("Press ESC to stop");

var portReader = new PortReader();
var signalRConnection = new SignalRClient();
await signalRConnection.Start();
Console.WriteLine("Timestamp X Y Z");
List<AccelerationMeasurement> measurements = new();
while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
{
    try
    {
        var measurement = portReader.ReadLine();
        var acceleration = AccelerationUtilities.ToAcceleration(measurement);
        var accelerationMeasurement = acceleration.ToAccelerationMeasurement();
        Console.WriteLine(accelerationMeasurement);
        measurements.Add(accelerationMeasurement);
    }
    catch
    {
        // ignored
    }
}
await signalRConnection.SendMeasurements(measurements);