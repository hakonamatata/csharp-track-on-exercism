using System;

class RemoteControlCar
{
    public int Battery { get; set; }
    public int Distance { get; set; }

    public RemoteControlCar()
    {
        Battery = 100;
        Distance = 0;
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {this.Distance} meters";

    public string BatteryDisplay() {

        if (this.Battery <= 0) {
            return "Battery empty";
        }

        return $"Battery at {this.Battery}%";
    }

    public void Drive() {

        if (this.Battery <= 0)
        {
            return;
        }

        this.Distance += 20;
        this.Battery -= 1;
    }
}
