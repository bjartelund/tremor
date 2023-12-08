namespace Library;

public static class AccelerationUtilities
{
    public static int PythagoranTremorVector(Acceleration acceleration) => (int)Math.Sqrt(
        acceleration.X * acceleration.X + acceleration.Y * acceleration.Y + acceleration.Z * acceleration.Z);

    public static Acceleration ToAcceleration(string line)
    {
        var parts = line.Split(' ');
        if (parts.Length != 3)
        {
            throw new Exception("Invalid line");
        }

        return new Acceleration(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }

    public static AccelerationMeasurement ToAccelerationMeasurement(this Acceleration acceleration) =>
        new(DateTime.Now, acceleration);

    public static IEnumerable<AccelerationMeasurement> ReducedAccelerationMeasurement(
        this IEnumerable<AccelerationMeasurement> accelerationMeasurements)
    {
        var measurements = accelerationMeasurements.ToList();
        var acceleration = measurements.Select(am => am.Acceleration).ToList();
        var windowed = acceleration.Zip(acceleration.Skip(1), (a1, a2) => (a1, a2));
        var reduced = windowed.Select(w => new Acceleration(
                       w.a2.X - w.a1.X,
                                  w.a2.Y - w.a1.Y,
                                  w.a2.Z - w.a1.Z
                              ));
        var timestamps = measurements.Select(am => am.Timestamp);
        return reduced.Zip(timestamps, (a, t) => new AccelerationMeasurement(t, a));
    }
}