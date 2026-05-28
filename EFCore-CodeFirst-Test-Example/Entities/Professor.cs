namespace EFCore_CodeFirst_Test_Example.Entities;

public class Professor
{
    public int ProfessorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int DepartmentId { get; set; }
    
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public Departament Departament { get; set; } = null!;


}