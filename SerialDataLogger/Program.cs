using Library;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Movement,Anomaly");

var portReader = new PortReader();
var signalRConnection = new SignalRClient();
await signalRConnection.Start();
while (true)
{
    try
    {
        var samples =Sample();
        var aggregatedMovement = samples.Aggregate(0, (acc, s) => AccelerationUtilities.PythagoranTremorVector(s) + acc);
        var anomaly = aggregatedMovement > 11000 ? "1" : "0";
        Console.WriteLine($"{aggregatedMovement},{anomaly}");
        await signalRConnection.SendTremor(aggregatedMovement);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

IEnumerable<Acceleration> Sample()
{
    for (var i = 0; i < 10; i++)
    {
        var line = portReader.ReadLine();
        var acceleration = AccelerationUtilities.ToAcceleration(line);
        yield return acceleration;
        //await signalRConnection.SendAcceleration(acceleration);
    }
}

