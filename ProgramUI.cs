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

            switch (selection)
            {
                case "1": //"1. List All Existing Developers\n" +
                    GetAllDevelopers();
                    break;
                case "2": // "2. Add New Developer\n" +
                    AddNewDeveloper();
                    break;
                case "3":  // "3. View Developer by ID\n" +
                    GetDeveloperByDevID();
                    break;
                case "4":
                    // "4. Update Developer by ID\n" +
                    UpdateExistingDeveloper();
                    break;
                case "5": // "5. Delete Developer by ID\n" +
                    DeleteExistingDeveloper();
                    break;
                case "6": // "6. List All Existing Teams\n" +
                    GetAllTeams();
                    break;
                case "7": // "7. View Team by ID\n" +
                    GetTeamByTeamID();
                    break;
                case "8": // "8. Add New Team \n" +
                    AddNewTeam();
                    break;
                case "9": // "9. Update Team by ID\n" +
                    UpdateExistingTeam();
                    break;
                case "10": // "10. Delete Team by ID\n"
                    DeleteExistingTeam();
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
        //Get new developer information
        DeveloperInformation newDeveloper = new DeveloperInformation();

        //First Name
        System.Console.WriteLine("Enter new developer's First Name:");
        newDeveloper.FirstName = Console.ReadLine();

        //Last Name
        System.Console.WriteLine("Enter new developer's Last Name:");
        newDeveloper.LastName = Console.ReadLine();
        //DevId
        System.Console.WriteLine("Enter new developer's ID (ie: AB12):");
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
        System.Console.WriteLine("Enter Team new developer is a part of (ie: team1)");
        string teamMemberOf = Console.ReadLine().ToLower();

        // Call the Add method
        bool WasAdded = _devRepo.AddNewDeveloper(newDeveloper);

        //If added display confirmation
        if (WasAdded)
        {
            System.Console.WriteLine("This developer has been added succesfully!");
        }
        else
        {
            System.Console.WriteLine("Sorry, this developer was not added");
        }
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

        System.Console.WriteLine("Enter the ID of the developer you want to update:");

        string devID = Console.ReadLine();
        DeveloperInformation developer = _devRepo.GetDeveloperByDevID(devID);

        if (developer != null)
        {
            DisplayDeveloperInformation(developer);
            //First Name
            System.Console.WriteLine($"Do you want to update the current first name: {developer.FirstName}? (y/n)");
            string updateFirstName = Console.ReadLine().ToLower();
            if (updateFirstName == "y")
            {
                System.Console.WriteLine("Enter updated First Name:");
                developer.FirstName = Console.ReadLine();
            }
            else if (updateFirstName == "n")
            { }
            else
            {
                System.Console.WriteLine("Please choose a valid option");
            }



            // Last Name
            System.Console.WriteLine($"\nDo you want to update the current last name: {developer.LastName}? (y/n)");
            string updateLastName = Console.ReadLine().ToLower();
            if (updateLastName == "y")
            {
                System.Console.WriteLine("Enter updated Last Name:");
                developer.LastName = Console.ReadLine();
            }
            else if (updateLastName == "n")
            { }
            else
            {
                System.Console.WriteLine("Please choose a valid option");
            }

            //Pluralsight Access
            System.Console.WriteLine($"\nDo you want to update developer's current Pluralsight Access: {developer.PluralsightAcccess}? (y/n)");
            string updatePluralsightAccess = Console.ReadLine().ToLower();
            if (updatePluralsightAccess == "y")
            {
                System.Console.WriteLine("Does developer have Pluralsight Access? (y/n)");
                string pluralSightAccessString = Console.ReadLine().ToLower();
                if (pluralSightAccessString == "y")
                {
                    developer.PluralsightAcccess = true;
                }
                else
                {
                    developer.PluralsightAcccess = false;
                }
            }
            else if (updatePluralsightAccess == "n")
            { }
            else
            {
                System.Console.WriteLine("Please choose a valid option");
            }

            //Team
            System.Console.WriteLine($"\nDo you want to update the developer's current team: {developer.TeamMemberOf}? (y/n)");
            string updateTeamMemberOf = Console.ReadLine().ToLower();
            if (updateTeamMemberOf == "y")
            {
                System.Console.WriteLine("Enter updated Team:");
                developer.TeamMemberOf = Console.ReadLine();
            }
            else if (updateTeamMemberOf == "n")
            { }
            else
            {
                System.Console.WriteLine("Please choose a valid option");
            }
        }
        else
        {
            System.Console.WriteLine("Sorry, that developer ID was not found");
        }
        //Send Updates to Repo
        _devRepo.UpdateExistingDeveloper(developer);
    }

    // 5. Delete Developer by ID\
    private void DeleteExistingDeveloper()
    {
        Console.Clear();
        GetAllDevelopers();

        //Get devID they want to delete
        System.Console.WriteLine("Enter the ID of the developer you would like to delete");
        string devID = Console.ReadLine();

        //Call delete method
        bool wasDeleted = _devRepo.DeleteExistingDeveloper(devID);

        //check if deleted or not and give response
        if (wasDeleted)
        {
            System.Console.WriteLine("This developer has been deleted successfully.");
        }
        else
        {
            System.Console.WriteLine("Sorry, this developer could not be deleted");
        }
    }

    // 6. List All Existing Teams
    private void GetAllTeams()
    {
        Console.Clear();
        List<TeamInformation> allTeams = _teamRepo.GetAllTeams();

        foreach(TeamInformation team in allTeams)
        {
            System.Console.WriteLine(
                $"Team Name: {team.TeamName}\n" +
                $"ID#: {team.TeamID}\n"
                );
        }
    }

    // 7. View Team by ID
    private void GetTeamByTeamID()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the ID of the Team you would like to view");
        string teamIDAsString = Console.ReadLine();
        int teamIDAsInt = int.Parse(teamIDAsString);
        TeamInformation team = _teamRepo.GetTeamByTeamID(teamIDAsInt);

        if (team != default)
        {
            DisplayTeamInformation(team);
        }
        else
        {
            System.Console.WriteLine("Sorry, that team ID was not found");
        }
    }

    // 8. Add New Team 
    private void AddNewTeam()
    {
        Console.Clear();
        //Get new team information
        TeamInformation newTeam = new TeamInformation();

        //Team Name
        System.Console.WriteLine("Enter new Team Name:");
        newTeam.TeamName = Console.ReadLine();

        //TeamID
        System.Console.WriteLine("Enter new Team ID:");
        string teamIDAsString = Console.ReadLine();
        int newTeamID = int.Parse(teamIDAsString);
        newTeam.TeamID = newTeamID;

        //Call the add method
        bool WasAdded = _teamRepo.AddNewTeam(newTeam);

        //If added display confirmation
        if (WasAdded)
        {
            System.Console.WriteLine("This team had been added successfully!");
        }
        else
        {
            System.Console.WriteLine("Sorry, this team was not added");
        }
    }

    // 9. Update Team by ID
    private void UpdateExistingTeam()
    {
        Console.Clear();
        //List All teams
        GetAllTeams();
        //Prompt for team ID to update
        System.Console.WriteLine("Enter the ID of the team you want to update:");
        string teamIDAsString = Console.ReadLine();
        int teamID = int.Parse(teamIDAsString);
        //Call on repo
        TeamInformation team = _teamRepo.GetTeamByTeamID(teamID);
        
        //If statment depending on if team != null
        if (team != null)
        {
            DisplayTeamInformation(team);
            //Team Name Update
            System.Console.WriteLine($"Do you want to update the current team name: {team.TeamName}? (y/n)");
            string updateTeamName = Console.ReadLine().ToLower();
            if (updateTeamName == "y")
            {
                System.Console.WriteLine("Enter updated Team Name:");
                team.TeamName = Console.ReadLine();
            }
            else if (updateTeamName == "n")
            { }
            else
            {
                System.Console.WriteLine("Please choose a valid option");
            }
        }
        else
        {
            System.Console.WriteLine("Sorry, that team ID was not found");
        }
        //Send Updates to Rep
        _teamRepo.UpdateExistingTeam(team);
    }

    // 10. Delete Team by ID
    private void DeleteExistingTeam()
    {
        Console.Clear();
        GetAllTeams();

        //Get TeamID to delete
        System.Console.WriteLine("Enter the ID of the team you would like to delete");
        string teamIDAsString = Console.ReadLine();
        int teamID = int.Parse(teamIDAsString);

        //call delete method
        bool wasDeleted = _teamRepo.DeleteExistingTeam(teamID);

        //check if deleted and give response
        if (wasDeleted)
        {
            System.Console.WriteLine("This Team has been deleted successfully.");
        }
        else
        {
            System.Console.WriteLine("Sorry, this team could not be deleted");
        }
    }

    //Helper Methods
    private void DisplayDeveloperInformation(DeveloperInformation developer)
    {
        System.Console.WriteLine
            (
                $"First Name: {developer.FirstName}\n" +
                $"Last Name: {developer.LastName}\n" +
                $"ID: {developer.DevID}\n" +
                $"Pluralsight Access: {developer.PluralsightAcccess}\n" +
                $"Team Member of: {developer.TeamMemberOf}\n"
            );
    }

    private void DisplayTeamInformation(TeamInformation team)
    {
        System.Console.WriteLine
        (
            $"Team Name: {team.TeamName}\n" +
            $"Team ID: {team.TeamID}\n" +
            $"Team Members: {team.TeamMemberList}\n"
        );
    }
}
