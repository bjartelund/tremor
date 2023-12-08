namespace Library;

public record AccelerationMeasurement(DateTime Timestamp, Acceleration Acceleration)
{
    public override string ToString() => $"{Timestamp:O} {Acceleration}";
}