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
}