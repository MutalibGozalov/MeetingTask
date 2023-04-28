//Person classı yaradılır və Name, Surname, Age propertyləri olur.
namespace Models;

public class Person
{
    public string Name { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public byte Age { get; set; }
}


// Persondan miras alan Employee classı olur. Employee classında
// - SalaryOfHour (saatbaşı qazandığı maaş)
// - WorkingHour (30 gün ərzində neçə saat işlədiyi)
// - CalculateSalary() - Ümumi maaşı hesablayan method.
// memberləri olur.
public class Employee : Person
{
//     Name, Surname, Age, SalaryOfHour, WorkingHour məlumatlarını daxil etmədən işçi yaratmaq mümkün olmasın.    
    public Employee(string name, string surname, byte age, decimal salaryOfHour, byte workingHour)
    {
       if (age >= 18)     //İşçi 18 yaşın altındadırsa işləmə hüququ yoxdur.
       {
            this.Name = name;
            this.SurName = surname;
            this.Age = age;
            //this.SalaryOfHour = salaryOfHour; this wouldn't work because SalaryOfHour validates using WorkingHour property so mus be init 1st
            this.WorkingHour = workingHour;
            this.SalaryOfHour = salaryOfHour;
       }
       else throw new Exception("Persons under 18 can'not be employeed");
    }


    private decimal _salaryOfHour; //saatbaşı maaş
    public decimal SalaryOfHour { 
        get
        {
            return _salaryOfHour;
        } 
        set
        {   //  Aylıq maaşı 250 manatdan az ola bilməz. 
            if (value * this._workingHour < 250)
            {
                throw new Exception("Salary can'not be less than 250 AZN per month");
            }
            else _salaryOfHour = value;
        }
     }

    //İşçinin günlük ortalama iş saatı 8 saatdan çox ola bilməz.
    private byte _workingHour; //Ayliq neçə saat, min 250
    public byte WorkingHour { 
        get
        {
            return _workingHour;
        } 
        set
        {   double a = Math.Ceiling(value/30.0);
            if ( a > 8)
            {
                throw new Exception("Working hours can'not exceed 8 hours a day");
            }
            else _workingHour = value;
        }
    }

    public decimal CalculateSalary()
    {
        decimal salary = this.SalaryOfHour * this.WorkingHour;
        Console.WriteLine($"{this.Name} {this.SurName} getting paid {salary} AZN per month");
        return salary;
    }
}

// Persondan miras alan Student classı verilir. Student classında
// - IQRank (IQ imtahanının nəticəsi (100 bal üzərindən))
// - LanguageRank (Dil imtahanının nəticəsi (100 bal üzərindən))
// - ExamResult() - Şagirdin iki imtahanının nəticəsi 120dən azdırsa, o zaman sinifdə qaldığı mənasını bildirən methoddur.
// Name, Surname, Age, IQRank, LanguageRank məlumatlarını daxil etmədən Student yaratmaq mümken olmasın.
// Şagirdin yaşı 6dan az, 20dən çoxdursa o zaman şagirdin məlumatları daxil edilə bilməsin
public class Student : Person
{   
    private int _iqRank;
    public int IQRank {
        get
        {
            return _iqRank;
        } 
        set
        {
            if (value > 100 || value < 0)
            {
                throw new Exception(" Intelectual Quotation Rank must be in range of 0 and 100");
            }
            else _iqRank = value;
        }
    }

    private int _languageRank;
    public int LanguageRank{
        get
        {
            return _languageRank;
        } 
        set
        {
            if (value > 100 || value < 0)
            {
                throw new Exception("Language Rank must be in range of 0 and 100");
            }
            else _languageRank = value;
        }
    }
    public Student(string name, string surname, byte age, int iqRank, int languageRank)
    {
        if (age is >= 6 and <= 20)
        {
            this.Name = name;
            this.SurName = surname;
            this.Age = age;
            this.IQRank = iqRank;
            this.LanguageRank = languageRank;
        }
        else throw new Exception("Students that aren't age between 6 and 20 cannot be registered");
    }   

    public void ExamResult(int firstResult, int secondResult){
        bool hasFailed = firstResult+secondResult < 120;
        Console.WriteLine($"{this.Name} {this.SurName} {(hasFailed ? " failed" : "passed")} the exam");
    }
}