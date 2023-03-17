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

    public bool AddNewMemberToTeam(DeveloperInformation newMember)
    {
        int startingCount = TeamMemberList.Count;

        this.TeamMemberList.Add(newMember);

        bool WasAdded = TeamMemberList.Count > startingCount;

        return WasAdded;
    }

    public bool RemoveMemberFromTeam(DeveloperInformation removeMember)
    {
        int startingCount = TeamMemberList.Count;

        this.TeamMemberList.Remove(removeMember);

        bool WasRemoved = TeamMemberList.Count < startingCount;

        return WasRemoved;
    }
}
