public class Person
{
    public string Name { get; set; }
    public int Turns { get; set; } // 0 or less = infinite turns

    // Constructor required by the tests
    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}
