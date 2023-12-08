// See https://aka.ms/new-console-template for more information

using Library;

Console.WriteLine("Replaying old data");
var inputFile = args.Length == 0 ? "15b5c1df-0c04-49f4-b021-298ecd47a815" : args[0];
var input = File.ReadAllLines(inputFile);
var mapped = input.Select(ToAccelerationMeasurement);
var signalRConnection = new SignalRClient();
await signalRConnection.Start();
await signalRConnection.SendMeasurements(mapped);

AccelerationMeasurement ToAccelerationMeasurement(string line)
{
    var parts = line.Split(' ');
    if (parts.Length != 4)
    {
        throw new Exception("Invalid line");
    }

    return new AccelerationMeasurement(DateTime.Parse(parts[0]), new Acceleration(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
}