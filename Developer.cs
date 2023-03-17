

public class DeveloperInformation
{
    //NAME
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    //ID#
    public string DevID;

    //Pluralsight Bool
    public bool PluralsightAcccess { get; set; }

    public DeveloperInformation() { }
    public DeveloperInformation(string firstName, string lastName, string devID, bool pluralsightAcccess)
    {
        FirstName = firstName;
        LastName = lastName;
        DevID = devID;
        PluralsightAcccess = pluralsightAcccess;
    }
}



