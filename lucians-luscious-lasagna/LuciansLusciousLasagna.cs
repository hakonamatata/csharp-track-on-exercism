using System;
using System.Collections.Generic;

class Lasagna
{
  public int ExpectedMinutesInOven()
  {
    return 40;
  }

  public int RemainingMinutesInOven(int v)
  {
    return 40 - v;
  }

  public int PreparationTimeInMinutes(int v)
  {
    return 2 * v;
  }

  public int ElapsedTimeInMinutes(int v1, int v2)
  {
    return v1 * 2 + v2;
  }
}
