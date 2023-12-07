namespace Library;

public record Acceleration(int X, int Y, int Z)
{
    public override string ToString() => $"{X} {Y} {Z}";
}