public class TeamInformation
{
    //Team Name
    public string TeamName { get; set; }

    //Team ID
    public int TeamID { get; set; }

    public List<DeveloperInformation> TeamMemberList = new List<DeveloperInformation>();


    public TeamInformation() {}
    public TeamInformation(string teamName, int teamID)
    {
        TeamName = teamName;
        TeamID = teamID;
    }

}
