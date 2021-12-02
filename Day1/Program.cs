var measurements = File.ReadAllText("input")
  .Split('\n')
  .ToList()
  .FindAll(line => !string.IsNullOrWhiteSpace(line))
  .Select(int.Parse);

var threeMeasurementSlidingWindow = measurements.Skip(2)
  .Zip(measurements.Skip(1), (curr, prev) => curr + prev)
  .Zip(measurements, (curr, prev) => curr + prev);

var countIncrements = (IEnumerable<int> m) => m.Skip(1).Zip(m, (c, p) => c > p).Count(b => b);

Console.WriteLine($"Part 1: {countIncrements(measurements)}");
Console.WriteLine($"Part 2: {countIncrements(threeMeasurementSlidingWindow)}");
