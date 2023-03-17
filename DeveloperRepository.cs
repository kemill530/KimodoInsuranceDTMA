using System.Collections.Generic;

public class DeveloperRepository
{
    private readonly List<DeveloperInformation> _devDirectory = new List<DeveloperInformation>();

    public DeveloperRepository()
    {
        DevSeed();
    }

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
    public bool UpdateExistingDeveloper(DeveloperInformation newInformation)
    {
        DeveloperInformation oldInformation = GetDeveloperByDevID(newInformation.DevID);
        {
            if (oldInformation != default)
            {
                oldInformation.FirstName = newInformation.FirstName;
                oldInformation.LastName = newInformation.LastName;
                oldInformation.PluralsightAcccess = newInformation.PluralsightAcccess;
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

    private void DevSeed()
    {
        DeveloperInformation developerOne = new DeveloperInformation(
            "Kali",
            "Miller",
            "KM12",
            true
        );

        DeveloperInformation developerTwo = new DeveloperInformation(
            "John",
            "James",
            "JJ34",
            true
        );

        DeveloperInformation developerThree = new DeveloperInformation(
            "Amelia",
            "Martin",
            "AM56",
            false
        );

        DeveloperInformation developerFour = new DeveloperInformation(
            "Phillip",
            "Grant",
            "PG78",
            true
        );

        DeveloperInformation developerFive = new DeveloperInformation(
            "Sarah",
            "Vicks",
            "SV90",
            false
        );

        DeveloperInformation developerSix = new DeveloperInformation(
            "Eric",
            "Erickson",
            "EE23",
            true
        );

        AddNewDeveloper(developerOne);
        AddNewDeveloper(developerTwo);
        AddNewDeveloper(developerThree);
        AddNewDeveloper(developerFour);
        AddNewDeveloper(developerFive);
        AddNewDeveloper(developerSix);
    }
}


