// https://adventofcode.com/2021/day/3

var report = File.ReadAllText("input")
  .Split('\n')
  .ToList()
  .FindAll(line => !string.IsNullOrWhiteSpace(line))
  .Select(line => line.ToCharArray().Select(char.ToString).Select(int.Parse).ToList())
  .ToList();

var bits = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
var sums = report.Aggregate(bits, (acc, item) => acc.Zip(item, (a, i) => a + i).ToList());

var result = (Func<int, char> fn) =>  Convert.ToInt64(new string(sums.Select(fn).ToArray()), 2);
var count = report.Count();
var gamma = result(sum => sum > count / 2 ? '1' : '0');
var epsilon = result(sum => sum < count / 2 ? '1' : '0');

Console.WriteLine($"Part 1: {gamma * epsilon}"); // Answer: 1131506

