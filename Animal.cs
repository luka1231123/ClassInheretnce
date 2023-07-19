namespace NovaGrService;

public class Animal
{
    public string Name{get;set;}
    public AnimalOwner owner{get;set;} 
}
public class Dog : Animal
{
}

public class Cat : Animal
{
}

public class Mouse : Animal
{
}