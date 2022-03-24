using GradeBook;

var book = new DiskBook("Scott's Grade Book");
book.GradeAdded += OnGradeAdded;

EnterGrades(book);

var stats = book.GetStatistics();

Console.WriteLine($"For the book named {book.Name}");
Console.WriteLine($"The lowest grade is {stats.Low}");
Console.WriteLine($"The highest grade is {stats.High}");
Console.WriteLine($"The average grade is {stats.Average:N1}");
Console.WriteLine($"The letter grade is {stats.Letter}");

static void OnGradeAdded(object sender, EventArgs e)
{
    Console.WriteLine("A grade was added");
}

static void EnterGrades(IBook book)
{
    do
    {
        Console.WriteLine("Please enter a grade or 'Q' to quit");
        var input = Console.ReadLine();

        if (input == "Q")
        {
            break;
        }

        try
        {
            var grade = Convert.ToDouble(input);
            book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("***");
            Console.WriteLine();
        }

    } while (true);
}