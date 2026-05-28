namespace EFCore_CodeFirst_Test_Example.Entities;

public class Departament
{
    public int DepartamentId { get; set; }
    public string Name { get; set; } =  String.Empty;
    public string FacultyBuilding { get; set; } =  String.Empty;
    public double Budget { get; set; }
    
    public ICollection<Professor> Professors { get; set; } = new List<Professor>();
}