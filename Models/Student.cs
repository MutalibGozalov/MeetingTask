namespace Models;

// Persondan miras alan Student classı verilir. Student classında
// - IQRank (IQ imtahanının nəticəsi (100 bal üzərindən))
// - LanguageRank (Dil imtahanının nəticəsi (100 bal üzərindən))
// - ExamResult() - Şagirdin iki imtahanının nəticəsi 120dən azdırsa, o zaman sinifdə qaldığı mənasını bildirən methoddur.
// Name, Surname, Age, IQRank, LanguageRank məlumatlarını daxil etmədən Student yaratmaq mümken olmasın.
// Şagirdin yaşı 6dan az, 20dən çoxdursa o zaman şagirdin məlumatları daxil edilə bilməsin
public class Student : Person
{   
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

    public void ExamResult(int firstResult, int secondResult){
        bool hasFailed = firstResult+secondResult < 120;
        Console.WriteLine($"{this.Name} {this.SurName} {(hasFailed ? " failed" : "passed")} the exam");
    }
}