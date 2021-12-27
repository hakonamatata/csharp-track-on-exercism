using System;

static class AssemblyLine
{
    static double CarsProducedPerHour = 221;

    public static double SuccessRate(int speed)
    {
        if (speed == 0) {
            return 0;
        } else if (speed >= 1 && speed <= 4) {
            return 1;
        } else if (speed >= 5 && speed <= 8) {
            return .9;
        } else if (speed == 9) {
            return .8;
        } else if (speed == 10) {
            return .77;
        }

        throw new ArgumentException("Invalid speed");
    }

    public static double ProductionRatePerHour(int speed) => speed * CarsProducedPerHour * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => Convert.ToInt32(Math.Floor(ProductionRatePerHour(speed) / 60));
}
