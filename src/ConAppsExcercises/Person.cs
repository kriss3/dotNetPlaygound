namespace ConAppsExercises;

//can be public, private, protected, internal protected
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name}, age = {Age}";
    }
}
