//Person classı yaradılır və Name, Surname, Age propertyləri olur.
namespace Models;

public class Person
{
    public Person(){ }
    public string Name { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public byte Age { get; set; }
}
