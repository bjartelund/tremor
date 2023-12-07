using System.IO.Ports;

namespace Library;

public class PortReader
{
    private static readonly SerialPort SerialPort = new SerialPort();

    public PortReader()
    {
        SerialPort.PortName = "COM8";
        SerialPort.BaudRate = 115200;
        SerialPort.DataBits = 8;
        SerialPort.Parity = Parity.None;
        SerialPort.StopBits = StopBits.One;
        SerialPort.Open();
    }

    public string ReadLine()
    {
        return SerialPort.ReadLine();
    }
}