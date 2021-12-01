class IncrementCounter
{
  private List<int> Measurements;
  public IncrementCounter(List<int> measurements) => Measurements = measurements;

  public int Count()
  {
    int? previous = null;
    return Measurements.Count(m =>
    {
      var isIncrement = previous != null && m > previous;
      previous = m;
      return isIncrement;
    });
  }
}


