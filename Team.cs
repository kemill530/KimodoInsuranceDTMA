public class TeamInformation 
{
    //Team Name
    public string TeamName {get; set;}

    //Team ID
    public int TeamID {get; set;}

    // public List<string> TeamMembers {
        

//     }
    
    public TeamInformation(string teamName, int teamID)
    { 
        TeamName = teamName;
        TeamID = teamID;
    }

    
}
