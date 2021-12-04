// https://adventofcode.com/2021/day/3

var lines = File.ReadAllText("input")
  .Split('\n')
  .ToList()
  .FindAll(line => !string.IsNullOrWhiteSpace(line));

var bits = Enumerable.Range(0, lines[0].Length);

var mostCommon = (List<string> lines, int i) => lines.Count(line => line[i] == '1') * 2 >= lines.Count() ? '1' : '0';
var leastCommon = (List<string> lines, int i) => mostCommon(lines, i) == '1' ? '0' : '1';

var calculateRate = (List<string> lines, Func<List<string>, int, char> selector) =>
  bits.Select(i => selector(lines, i)).Aggregate("", (acc, item) => acc += item);

var gammaRate = Convert.ToInt32(calculateRate(lines, mostCommon), 2);
var epsilonRate = Convert.ToInt32(calculateRate(lines, leastCommon), 2);

Console.WriteLine($"Part 1: {gammaRate * epsilonRate}");

var findRate = (List<string> lines, Func<List<string>, int, char> selector) => bits
  .Aggregate(lines, (acc, i) => acc.Count() == 1 ? acc : acc.FindAll(line => line[i] == selector(acc, i)))
  .First();

var oxygenRate = Convert.ToInt32(findRate(lines, mostCommon), 2);
var co2Rate = Convert.ToInt32(findRate(lines, leastCommon), 2);

Console.WriteLine($"Part 2: {oxygenRate * co2Rate}");
