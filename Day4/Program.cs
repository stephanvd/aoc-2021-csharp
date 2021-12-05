// https://adventofcode.com/2021/day/4

using System.Text.RegularExpressions;

var lines = File.ReadAllText("input").Split('\n').ToList();

var draws = lines.First().Split(',').Select(int.Parse).ToList();
var boards = new List<Board>();

var i = 2;
while (i < lines.Count() - 5)
{
  boards.Add(new Board(lines.Skip(i).Take(5).ToList()));
  i += 6;
}

var part1 = new Bingo(boards);
var round = 0;
int? score = null;
while(score == null)
{
  score = part1.Play(draws[round]);
  round += 1;
}
Console.WriteLine($"Part 1: {score}");

class Board
{
  public List<List<int>> Numbers;

  public Board(List<string> lines)
  {
    Numbers = lines
    .Select(l => Regex.Split(l.Trim(), @"\s+").ToList().Select(int.Parse).ToList())
    .ToList();
  }

  public int Score(List<int> draws) {
    var unmarked = Numbers.Sum(row => row.Sum(number => draws.Contains(number) ? 0 : number));
    return unmarked * draws.Last();
  }

  public bool Check(List<int> draws) =>
    CheckHorizontal(draws) || CheckVertical(draws);

  private bool CheckHorizontal(List<int> draws) =>
    Numbers.Any(line => line.All(draws.Contains));

  private bool CheckVertical(List<int> draws) =>
    VerticalLines().Any(line => line.All(draws.Contains));

  private List<List<int>> VerticalLines() =>
    Enumerable.Range(0, Numbers.First().Count()).Select(i => Numbers.Select(n => n[i]).ToList()).ToList();
};

class Bingo
{
  public List<Board> Boards;
  public List<int> Draws = new List<int>();

  public Bingo(List<Board> boards)
  {
    Boards = boards;
  }

  public int? Play(int draw)
  {
    Draws.Add(draw);
    var winners = Boards.FindAll(b => b.Check(Draws));

    return winners.Any() ? winners.First().Score(Draws) : null;
  }
}
