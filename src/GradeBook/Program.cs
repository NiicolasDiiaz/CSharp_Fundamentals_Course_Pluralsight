using GradeBook;

var book = new Book("Scott's Grade Book");

do
{
    Console.WriteLine("Please enter a grade or 'Q' to quit");
    var input = Console.ReadLine();

    if(input == "Q")
    {
        break;
    }

    try
    {
        var grade = Convert.ToDouble(input);
        book.AddGrade(grade);
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }

} while (true);

var stats = book.GetStatistics();

Console.WriteLine($"The lowest grade is {stats.Low}");
Console.WriteLine($"The highest grade is {stats.High}");
Console.WriteLine($"The average grade is {stats.Average:N1}");
Console.WriteLine($"The letter grade is {stats.Letter}");
