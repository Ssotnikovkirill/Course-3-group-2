public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    
    public override string ToString()
    {
        return $"{Id}: {Name} - {PhoneNumber}";
    }
}