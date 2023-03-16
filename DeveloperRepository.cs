using System.Collections.Generic;

public class DeveloperRepository
{
    private readonly List<DeveloperInformation> _devDirectory = new List<DeveloperInformation>();

    //CREATE
    public bool AddNewDeveloper(DeveloperInformation developer)
    {
        int startingCount = _devDirectory.Count;

        _devDirectory.Add(developer);

        bool WasAdded = _devDirectory.Count > startingCount;

        return WasAdded;
    }

    //READ
    public List<DeveloperInformation> GetAllDevelopers()
    {
        return _devDirectory;
    }

    public DeveloperInformation GetDeveloperByDevID(string devID)
    {
        foreach (DeveloperInformation developer in _devDirectory)
        {
            if (developer.DevID == devID)
            {
                return developer;
            }
        }
        return default;
    }

    //UPDATE
    public bool UpdateExistingDeveloper(string OriginalDevID, DeveloperInformation newInformation)
    {
        DeveloperInformation oldInformation = GetDeveloperByDevID(OriginalDevID);
        {
            if (oldInformation != default)
            {
                oldInformation.FirstName = newInformation.FirstName;
                oldInformation.LastName = newInformation.LastName;
                oldInformation.DevID = newInformation.DevID;
                oldInformation.PluralsightAcccess = newInformation.PluralsightAcccess;
                oldInformation.TeamMemberOf = newInformation.TeamMemberOf;

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //DELETE
    public bool DeleteExistingDeveloper(string devID)
    {
        DeveloperInformation devIDToDelete = GetDeveloperByDevID(devID);
        if (devIDToDelete != default)
        {
            bool deleteResult = _devDirectory.Remove(devIDToDelete);
            return deleteResult;
        } 
        else
        {
            return false;
        }
    }
}