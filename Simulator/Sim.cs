using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management.Instrumentation;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BikeAppA3
{
  public class Sim : Bike
  {

    public string Id { get; set; }
    public double Pulse { get; set; }
    public double RPM { get; set; }
    public double Speed { get; set; }
    public double Distance { get; set; }
    public double Energy { get; set; }
    public TimeSpan Time { get; set; }
    public TimeSpan Stopwatch { get; set; }
    public double PowerUsage { get; set; }
    public string Chatbox { get; set; }
    public SerialPort Port { get; set; }
    public static Random rnd = new Random();
    public bool Connected { get; set; }

    /**
    *** Constructor - initialises the Simulator
    **/

    public Sim(double pulse, double rpm, double speed, double distance, double energy, TimeSpan time, TimeSpan stopwatch,
      double powerUsage, string chatbox)
    {
      Id = "SIM";
      Port = new SerialPort(); // no port is used with the simulation
      Pulse = pulse;
      RPM = rpm;
      Speed = speed;
      Distance = distance;
      Energy = energy;
      Time = time;
      Stopwatch = stopwatch;
      PowerUsage = powerUsage;
      Chatbox = chatbox;
    }

      public Sim()
      {
            Id = "SIM";
            Port = new SerialPort(); // no port is used with the simulation
            Pulse = 1;
            RPM = 1;
            Speed = 1;
            Distance = 1;
            Energy = 1;
            Time = new TimeSpan();
            Stopwatch = new TimeSpan();
            PowerUsage = 1;
            Chatbox = "";
            GenerateData();
      }

    /**
    *** @return List containing all the data necessary for display.
    **/

    public List<string> ReadData()
    {
        GenerateData();
        System.Collections.Generic.List<string> data = new List<string>();
        try
        {
            data.Add(Id.ToString());
            data.Add(Pulse.ToString());
            data.Add(Port.ToString());
            data.Add(Speed.ToString());
            data.Add(Distance.ToString());
            data.Add(Energy.ToString());
            data.Add(Time.ToString());
            data.Add(Stopwatch.ToString());
            data.Add(PowerUsage.ToString());
            data.Add(Chatbox);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
        }

        return data;
    }

    /**
    *** Send a command to the machine, returning values or setting values.
    *** Most commands in the simulation will return parameters, because it has no physical machine.
    *** @command string - Input given by the user to send to the machine.
    **/

    public void SendCommand(string command)
    {
      //@TODO most commands
      switch (command)
      {
        case "CD":
          break;
        case "CM":
          break;
        case "ID":
          Console.WriteLine(Id);
              break;
        case "PW":
          Console.WriteLine("Expected value; FORMAT PW <Value>");
              break;
        case "PW%":
          break;
        case "RD":
          break;
        case "ST":
          ReadData();
          break;
        case "VE":
          break;
        case "VS":
          Console.WriteLine("Expected value; FORMA VS <Value>");
              break;
        case "VS%":
          break;
        default:
          Console.WriteLine("Unrecognised Command!");
          break;
      }
    }

    /**
    *** Saves the data to the database
    *** @TODO figure out table fields, query, database class usage etc.
    **/

    public string SaveToDatabase(string query)
    {
      throw new NotImplementedException();
    }

    /**
    *** GenerateData generates the data to fill into the parameters.
    *** This is needed because the Simulation does not get any input values from a machine.
    **/

    public void GenerateData()
    {
      Pulse = rndInt(0, 120);
      RPM = rndInt(0, 110);
      Speed = rndDouble(0, 60);
      Distance = rndDouble(0, 999);
      Energy = rndInt(0, 200);
      PowerUsage = rndInt(0, 999);
      /*
      Time, StopWatch,

      int minutes = rndInt(0, 59);
      int seconds = rndInt(0, 59);
      String datetime = String.Format($"{minutes}:{seconds}"); */
    }

    /**
    *** @return string containing all parameters(data)
    **/

    public override string ToString()
    {
      Console.WriteLine("ID: {0} - Pulse: {1} - RPM: {2} - Speed: {3} - Distance: {4} - Energy: {5} - Time: {6} - Stopwatch: {7} -" +
        " PowerUsage: {8}",
      this.Id,
      this.Pulse.ToString(),
      this.RPM.ToString(),
      this.Speed.ToString(),
      this.Distance.ToString(),
      this.Energy.ToString(),
      this.Time.ToString(),
      this.Stopwatch.ToString(),
      this.PowerUsage.ToString());

        return "";
    }

    public static double rndDouble(double min, double max)
    {
      double range = max - min;
      double difference = 0 + min;
      double newDouble;
      newDouble = (rnd.NextDouble() * range) + difference;
      return newDouble;
    }

    public static int rndInt(int min, int max)
    {
      int newInt;
      newInt = rnd.Next(min, max);
      return newInt;
    }

  }
}