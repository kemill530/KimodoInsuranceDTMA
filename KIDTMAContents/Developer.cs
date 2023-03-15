
public enum TeamType
{
    FrontEnd = 1,
    BackEnd,
    Mobile,
}

public class Developer
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
    public TeamType TeamMemberOf { get; set; }

    public Developer(string firstName, string lastName, string fullName, string devID, bool pluralsightAcccess, TeamType teamMemberOf)
    {
        FirstName = firstName;
        LastName = lastName;
        FullName = fullName;
        DevID = devID;
        PluralsightAcccess = pluralsightAcccess;
        TeamMemberOf = teamMemberOf;
    }
}


