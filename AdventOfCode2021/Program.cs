using AdventOfCode2021;
using Autofac;
using System.Reflection;

var builder = new ContainerBuilder();
builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
    .Where(x => x.IsAssignableTo(typeof(IPuzzle)))
    .AsImplementedInterfaces();

var container = builder.Build();

var puzzles = container.Resolve<IList<IPuzzle>>();

var latestPuzzle = puzzles.OrderByDescending(x => x.Day).First();

Console.WriteLine($"Day {latestPuzzle.Day}: {latestPuzzle.GetSolution()}");

Console.WriteLine();

Console.WriteLine("Type 'ALL' to run all days.");
Console.WriteLine("Type day (ex '1A') to run specific day puzzle.");
Console.WriteLine("Type 'END' to quit");
var command = Console.ReadLine();
while(command.ToUpper() != "END")
{
    if(command.ToUpper() == "ALL")
    {
        foreach(var puzzle in puzzles.OrderBy(x => x.Day))
        {
            Console.WriteLine($"Day {puzzle.Day}: {puzzle.GetSolution()}");
        }
    }
    else if(puzzles.Any(x => x.Day == command.ToUpper()))
    {
        var puzzle = puzzles.FirstOrDefault(x => x.Day == command.ToUpper());
        Console.WriteLine($"Day {puzzle.Day}: {puzzle.GetSolution()}");
    }
    Console.WriteLine();
    Console.Write("Command: ");
    command = Console.ReadLine();
}
