

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

    //Team
    public string TeamMemberOf { get; set; }

    public DeveloperInformation(string firstName, string lastName, string devID, bool pluralsightAcccess, string teamMemberOf)
    {
        FirstName = firstName;
        LastName = lastName;
        DevID = devID;
        PluralsightAcccess = pluralsightAcccess;
        TeamMemberOf = teamMemberOf;
    }
}



