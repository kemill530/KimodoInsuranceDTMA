using System.Collections.Generic;

public class TeamRepository
{

    private readonly List<TeamInformation> _teamDirectory = new List<TeamInformation>();

    public TeamRepository()
    {
        TeamSeed();
    }

    //CREATE
    public bool AddNewTeam(TeamInformation team)
    {
        int startingCount = _teamDirectory.Count;

        _teamDirectory.Add(team);

        bool WasAdded = _teamDirectory.Count > startingCount;

        return WasAdded;
    }

    //READ

    public List<TeamInformation> GetAllTeams()
    {
        return _teamDirectory;
    }

    public TeamInformation GetTeamByTeamID(int teamID)
    {
        foreach (TeamInformation team in _teamDirectory)
        {
            if (team.TeamID == teamID)
            {
                return team;
            }
        }
        return null;
    }
    //UPDATE
    public bool UpdateExistingTeam(int OriginalTeamID, TeamInformation newInformation)
    {
        TeamInformation oldInformation = GetTeamByTeamID(OriginalTeamID);
        {
            if (oldInformation != null)
            {
                oldInformation.TeamName = newInformation.TeamName;
                oldInformation.TeamID = newInformation.TeamID;

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //DELETE
    public bool DeleteExistingTeam(int teamID)
    {
        TeamInformation teamIDToDelete = GetTeamByTeamID(teamID);
        if (teamIDToDelete != null)
        {
            bool deleteResult = _teamDirectory.Remove(teamIDToDelete);
            return deleteResult;
        }
        else
        {
            return false;
        }
    }

private void TeamSeed()
    {
        TeamInformation teamOne = new TeamInformation(
            "Team 1",
            101
        );

        TeamInformation teamTwo = new TeamInformation(
            "Team 2",
            202
        );

        TeamInformation teamThree = new TeamInformation(
            "Team 3",
            303
        );

        AddNewTeam(teamOne);
        AddNewTeam(teamTwo);
        AddNewTeam(teamThree);
    }
}