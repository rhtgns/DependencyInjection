// Base Interface for Teacher
public interface ITeacher
{
    string GetInfo();
}

// Teacher Class implementing ITeacher
public class Teacher : ITeacher
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Teacher(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetInfo()
    {
        return $"Teacher: {FirstName} {LastName}";
    }
}

// ClassRoom Class with Dependency Injection for Teacher
public class ClassRoom
{
    private readonly ITeacher _teacher;

    public ClassRoom(ITeacher teacher)  // Constructor Injection
    {
        _teacher = teacher;
    }

    public string GetTeacherInfo()
    {
        return _teacher.GetInfo();
    }
}

// Main program
class DependencyInjection
{
    static void Main(string[] args)
    {
        // Creating a Teacher instance
        ITeacher teacher = new Teacher("John", "Doe");

        // Injecting Teacher instance into ClassRoom
        ClassRoom classRoom = new ClassRoom(teacher);

        // Getting teacher info from ClassRoom
        string teacherInfo = classRoom.GetTeacherInfo();

        // Displaying the teacher info
        Console.WriteLine(teacherInfo);
    }
}
