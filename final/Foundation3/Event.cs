public class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string StandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string FullDetails()
    {
        return StandardDetails();
    }

    public virtual string ShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {date}";
    }
}