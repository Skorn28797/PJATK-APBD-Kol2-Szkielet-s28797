namespace EFCore_CodeFirst_Test_Example.Entities;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; } = String.Empty;
    public int Credits { get; set; }
    public int Semester { get; set; }
    public int ProfessorId { get; set; }
    
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public Professor Professor { get; set; } = null!;
}