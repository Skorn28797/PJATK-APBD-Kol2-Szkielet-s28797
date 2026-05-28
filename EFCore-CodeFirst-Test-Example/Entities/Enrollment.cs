namespace EFCore_CodeFirst_Test_Example.Entities;

public class Enrollment
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public int Grade { get; set; }
    public string Status { get; set; }
    
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
    
}