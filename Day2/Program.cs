// https://adventofcode.com/2021/day/2

var instructions = File.ReadAllText("input")
  .Split('\n')
  .ToList()
  .FindAll(line => !string.IsNullOrWhiteSpace(line))
  .Select(line => line.Split(' '))
  .Select(parts => new Command(parts[0], int.Parse(parts[1])))
  .ToList();

var initialPosition = new Position(Horizontal: 0, Depth: 0);
var position = instructions.Aggregate(initialPosition, (pos, comm) => comm.Direction switch
{
  "forward" => pos with { Horizontal = pos.Horizontal + comm.Distance },
  "down" => pos with { Depth = pos.Depth + comm.Distance },
  "up" => pos with { Depth = pos.Depth - comm.Distance },
  _ => pos
});

Console.WriteLine($"Part 1: {position.Horizontal * position.Depth}");

var initialPositionWithAim = new PositionWithAim(Aim: 0, Horizontal: 0, Depth: 0);
var positionWithAim = instructions.Aggregate(initialPositionWithAim, (pos, comm) => comm.Direction switch
{
  "forward" => pos with { Horizontal = pos.Horizontal + comm.Distance, Depth = pos.Depth + pos.Aim * comm.Distance },
  "down" => pos with { Aim = pos.Aim + comm.Distance },
  "up" => pos with { Aim = pos.Aim - comm.Distance },
  _ => pos
});

Console.WriteLine($"Part 2: {positionWithAim.Horizontal * positionWithAim.Depth}");

record struct Command(string Direction, int Distance);
record class Position(int Horizontal, int Depth);
record class PositionWithAim(int Aim, int Horizontal, int Depth);
