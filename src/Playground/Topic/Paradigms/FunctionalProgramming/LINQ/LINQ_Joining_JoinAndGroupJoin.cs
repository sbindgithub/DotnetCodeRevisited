using Playground.Domain;
using System.Collections;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class LINQ_Joining_JoinAndGroupJoin : ExampleBase
{
    public LINQ_Joining_JoinAndGroupJoin()
        : base("LINQ_Joining_JoinAndGroupJoin Example", TopicType.LINQ)
    {
    }

    private record Student(int Id, string Name);
    private record Mark(int StudentId, int Score);

    public override void Run()
    {
        var students = new List<Student>
        {
            new(1, "John"),
            new(2, "Alice"),
            new(3, "Bob") // No marks → will be excluded (inner join)
        };

        var marks = new List<Mark>
        {
            new(1, 90),
            new(1, 80), // multiple marks for John
            new(2, 85)
        };

        var joined = students.Join(
            marks,
            student => student.Id,
            mark => mark.StudentId,
            (student, mark) => new
            {
                student.Name,
                mark.Score
            });

        foreach (var item in joined)
        {
            Console.WriteLine($"Student: {item.Name}, Score: {item.Score}");
        }

        //GroupJoin
        //Write a LINQ query to group marks under each student(one-to - many).
        var result = students
        .GroupJoin(
            marks,
            student => student.Id,
            mark => mark.StudentId,
            (student, studentMarks) => new
            {
                student.Name,
                Scores = studentMarks.Select(m => m.Score),
                Count = studentMarks.Count(),
                Average = studentMarks.Any()
                    ? studentMarks.Average(m => m.Score)
                    : 0
            });

        foreach (var item in result)
        {
            Console.WriteLine($"Student: {item.Name}");
            Console.WriteLine($"Scores: {(item.Count > 0 ? string.Join(", ", item.Scores) : "No Marks")}");
            Console.WriteLine($"Total Subjects: {item.Count}");
            Console.WriteLine($"Average Score: {item.Average}");
            Console.WriteLine(new string('-', 40));
        }


    }
}

