class SlidingWindow
{
  private List<int> Measurements;

  public SlidingWindow(List<int> measurements) => Measurements = measurements;

  public List<int> GroupsOf(int groupSize)
  {
    var groupings = new List<int> { };

    for (int i = 0; i < Measurements.Count(); i++)
    {
      if (i >= groupSize-1) {
        var sum = Enumerable.Range(0, groupSize).Sum(s => Measurements[i-s]);
        groupings.Add(sum);
      }
    }

    return groupings;
  }
}
