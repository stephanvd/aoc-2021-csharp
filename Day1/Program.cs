var measurements = new MeasurementReader("input").Read();
var increments = new IncrementCounter(measurements).Count();
Console.WriteLine($"Counted increments: {increments}");

var slidingWindow = new SlidingWindow(measurements).GroupsOf(3);
var slidingIncrements = new IncrementCounter(slidingWindow).Count();
Console.WriteLine($"Sliding increments: {slidingIncrements}");
