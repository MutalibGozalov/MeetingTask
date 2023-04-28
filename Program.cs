using Models;
internal partial class Program
{
    private static void Main(string[] args)
    {
      try
      {
Console.WriteLine("Student class -----------------------");
          Student student = new("John", "Doe", age: 18, iqRank: 75, languageRank: 90);
          student.ExamResult(30, 89);
  
          Student student2 = new("Sue", "Storm", age: 20, iqRank: 100, languageRank: 95);
          student2.ExamResult(100, 99);   


Console.WriteLine("\nEmployee class -----------------------");
          Employee employee = new("Peter", "Parker", age: 19, workingHour: 150, salaryOfHour: 10);
          decimal salary = employee.CalculateSalary();
          
          Employee employee2 = new("Gwen", "Stacy", age: 23, workingHour: 240, salaryOfHour: 30);
          decimal salary2 = employee2.CalculateSalary();
          
      }
      catch(Exception ex) 
      {
            Console.WriteLine(ex.Message);
      }
      finally
      {
        Console.WriteLine("\n----------");
      }
    }
}