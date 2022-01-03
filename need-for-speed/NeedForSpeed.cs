using System;

class RemoteControlCar
{
    private int Speed;
    private int BatteryDrain;

    private int Distance = 0;
    private int Batteri = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.Speed = speed;
        this.BatteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => this.Batteri < this.BatteryDrain;

    public int DistanceDriven()
    {
        return this.Distance;
    }

    public void Drive()
    {
        if (this.BatteryDrained())
        {
            return;
        }

        this.Distance += this.Speed;
        this.Batteri -= this.BatteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int Distance;

    public RaceTrack(int distance)
    {
       this.Distance = distance;
    }

    public bool CarCanFinish(RemoteControlCar car)
    {
        while (car.BatteryDrained() == false)
        {
            car.Drive();
        }

        if (car.DistanceDriven() >= this.Distance)
        {
            return true;
        }

        return false;
    }
}
