using Library;

namespace GraphTimedMeasurements;
public interface ITremorService
{
    int RawMovement { get; set; }
    bool IsHighTremor { get; set; }
    IEnumerable<AccelerationMeasurement> TimedMeasurements { get; set; }
    List<AccelerationMeasurement> ReducedTimedMeasurements { get; set; }
}

public class TremorService : ITremorService
{
    public bool IsHighTremor { get; set; }
    public IEnumerable<AccelerationMeasurement> TimedMeasurements { get; set; } = new List<AccelerationMeasurement>();
    public List<AccelerationMeasurement> ReducedTimedMeasurements { get; set; } = new List<AccelerationMeasurement>();
    public int RawMovement { get; set; }
}