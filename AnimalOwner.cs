namespace NovaGrService;

public class AnimalOwner
{
    public string Name{get;set;}
    public bool IsVip {get;set;}


    public List<Dog> dogs{get;set;}
    public List<Cat> cats{get;set;}
    public List<Mouse> mice{get;set;}

}
