using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;

namespace BikeAppA3
{
  public interface Bike
  {
    string Id { get; set; }
    double Pulse { get; set; }
    double RPM { get; set; }
    double Speed { get; set; }
    double Distance { get; set; }
    double Energy { get; set; }
    TimeSpan Time { get; set; }
    TimeSpan Stopwatch { get; set; }
    double PowerUsage { get; set; }
    string Chatbox { get; set; }
    SerialPort Port { get; set; }
    bool Connected { get; set; }

    List<string> ReadData();
    void SendCommand(string command);
    string SaveToDatabase(string query);

  }
}