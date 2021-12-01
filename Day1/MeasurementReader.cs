class MeasurementReader
{
  private string Path;

  public MeasurementReader(string path) => Path = path;

  public List<int> Read()
  {
    var measurements = new List<int> { };
    var file = File.OpenText(Path);
    var line = "";
    while ((line = file.ReadLine()) != null)
    {
      var measurement = int.Parse(line);
      measurements.Add(measurement);
    }
    return measurements;
  }
}
