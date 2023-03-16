public class ProgramUI
{
    private readonly DeveloperRepository _devRepo = new DeveloperRepository();

    private readonly TeamRepository _teamRepo = new TeamRepository();

    public void Run()
    {

        // Menu
        RunMenu();
    }


    public void RunMenu()
    {
        bool continueToRun = true;
        while (continueToRun)
        {
            Console.Clear();
            System.Console.WriteLine
            (
                "Menu: \n" +
                "1. List All Existing Developers\n" +
                "2. Add New Developer\n" +
                "3. View Developer by ID\n" +
                "4. Update Developer Info by ID\n" +
                "5. Delete Developer by ID\n" +
                "6. List All Existing Teams\n" +
                "7. View Team by ID\n" +
                "8. Add New Team \n" +
                "9. Update Team by ID\n" +
                "10. Delete Team by ID\n" +
                "11. Exit"
            );

            string selection = Console.ReadLine();

            System.Console.WriteLine(selection);

            switch (selection)
            {
                case "1":
                    //"1. List All Existing Developers\n" +
                    GetAllDevelopers();
                    break;
                case "2":
                    // "2. Add New Developer\n" +
                    AddNewDeveloper();
                    break;
                case "3":
                    // "3. View Developer by ID\n" +
                    GetDeveloperByDevID();
                    break;
                case "4":
                    // "4. Update Developer by ID\n" +
                    break;
                case "5":
                    // "5. Delete Developer by ID\n" +
                    break;
                case "6":
                    // "6. List All Existing Teams\n" +
                    break;
                case "7":
                    // "7. View Team by ID\n" +
                    break;
                case "8":
                    // "8. Add New Team \n" +
                    break;
                case "9":
                    // "9. Update Team by ID\n" +
                    break;
                case "10":
                    // "10. Delete Team by ID\n"
                    break;
                case "11":
                    continueToRun = false;
                    break;
                default:
                    System.Console.WriteLine("Please choose a vaild selection.");
                    break;
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }

    // 1. List All Existing Developers
    private void GetAllDevelopers()
    {
        Console.Clear();
        List<DeveloperInformation> allDevelopers = _devRepo.GetAllDevelopers();


        foreach (DeveloperInformation developer in allDevelopers)
        {
            System.Console.WriteLine(
                $"{developer.LastName}, {developer.FirstName}\n" +
                $"ID#: {developer.DevID}\n"
                );
        }

    }

    // 2. Add New Developer
    private void AddNewDeveloper()
    {
        Console.Clear();
        DeveloperInformation newDeveloper = new DeveloperInformation();


        //First Name
        System.Console.WriteLine("Enter new developer's First Name:");
        newDeveloper.FirstName = Console.ReadLine();

        //Last Name
        System.Console.WriteLine("Enter new developer's Last Name:");
        newDeveloper.LastName = Console.ReadLine();
        //DevId
        System.Console.WriteLine("Enter new developer's ID (ex: AB12):");
        newDeveloper.DevID = Console.ReadLine();

        //Pluralsight Access
        System.Console.WriteLine("Does new developer have Pluralsight Access? (y/n)");
        string pluralSightAccessString = Console.ReadLine().ToLower();
        if (pluralSightAccessString == "y")
        {
            newDeveloper.PluralsightAcccess = true;
        }
        else
        {
            newDeveloper.PluralsightAcccess = false;
        }
        //Teams
        System.Console.WriteLine("Enter Team ID(s) of the new Developers team(s)");
        string teamAsString = Console.ReadLine();
        newDeveloper.TeamMemberOf = int.Parse(teamAsString);

        _devRepo.AddNewDeveloper(newDeveloper);
    }


    // 3. View Developer by ID
    private void GetDeveloperByDevID()
    {
        Console.Clear();
        GetAllDevelopers();

        System.Console.WriteLine("Enter the ID of the developer you would like to view");

        string devID = Console.ReadLine();
        DeveloperInformation developer = _devRepo.GetDeveloperByDevID(devID);

        if (devID != default)
        {
            DisplayDeveloperInformation(developer);
        }
        else
        {
            System.Console.WriteLine("Sorry, that developer ID was not found");
        }
    }


    // 4. Update Developer Information by ID
    private void UpdateExistingDeveloper()
    {
        Console.Clear();
        GetAllDevelopers();

        System.Console.WriteLine("Enter the ID of the developer you would like to update");

        string devID = Console.ReadLine();
        DeveloperInformation developer = _devRepo.GetDeveloperByDevID(devID);

        if (devID != null)
        {

        }
        else
        {
            System.Console.WriteLine("Sorry, that developer ID was not found");
        }


    }

    // 5. Delete Developer by ID\

    // 6. List All Existing Teams

    // 7. View Team by ID

    // 8. Add New Team 

    // 9. Update Team by ID

    // 10. Delete Team by ID

    //Helper Methods
    private void DisplayDeveloperInformation(DeveloperInformation developer)
    {
        System.Console.WriteLine
            (
                $"First Name: {developer.FirtName}\n" +
                $"Last Name: {developer.LastName}\n" +
                $"ID: {developer.DevID}\n" +
                $"Pluralsight Access: {developer.PluralsightAcccess}\n" +
                $"Team Member of: {developer.TeamMemberOf}\n"
            );
    }
}
