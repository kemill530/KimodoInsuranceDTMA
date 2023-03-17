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
                "9. Update Team Name by ID\n" +
                "10. Add New Member to Team\n" +
                "11. Remove Member from Team\n" +
                "12. Delete Team by ID\n" +
                "0. Exit"
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
                case "10": // 10. Add New Member to Team\n"
                    AddNewMemberToTeam();
                    break;
                case "11": //11. Remove Member from Team\n"
                    RemoveMemberFromTeam();
                    break;
                case "12": // "12. Delete Team by ID\n"
                    DeleteExistingTeam();
                    break;
                case "0":
                    continueToRun = false;
                    System.Console.WriteLine("Goodbye!");
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
        newDeveloper.DevID = Console.ReadLine().ToUpper();

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

        string devID = Console.ReadLine().ToUpper();
        DeveloperInformation developer = _devRepo.GetDeveloperByDevID(devID);

        if (devID != default)
        {
            Console.Clear();
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

        string devID = Console.ReadLine().ToUpper();
        DeveloperInformation developer = _devRepo.GetDeveloperByDevID(devID);

        if (developer != null)
        {
            Console.Clear();
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

            // //Team
            // System.Console.WriteLine($"\nDo you want to update the developer's current team: {developer.TeamMemberOf}? (y/n)");
            // string updateTeamMemberOf = Console.ReadLine().ToLower();
            // if (updateTeamMemberOf == "y")
            // {
            //     System.Console.WriteLine("Enter updated Team:");
            //     developer.TeamMemberOf = Console.ReadLine();
            // }
            // else if (updateTeamMemberOf == "n")
            // { }
            // else
            // {
            //     System.Console.WriteLine("Please choose a valid option");
            // }
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

        foreach (TeamInformation team in allTeams)
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
        GetAllTeams();
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
    //10. Add new member to team
    private void AddNewMemberToTeam()
    {
        Console.Clear();
        GetAllTeams();
        System.Console.WriteLine("Enter the TeamID you like to add a new member to:");
        string teamIDAsString = Console.ReadLine();
        int teamID = int.Parse(teamIDAsString);

        TeamInformation team = _teamRepo.GetTeamByTeamID(teamID);
        if (team != null)
        {
            DisplayTeamInformation(team);
            //Choose team to add member to
            System.Console.WriteLine($"Do you want to add a member to {team.TeamName} ID# {team.TeamID}? (y/n)");
            string addNewMemberSelect = Console.ReadLine().ToLower();
            if (addNewMemberSelect == "y")
            {
                Console.Clear();
                GetAllDevelopers();
                System.Console.WriteLine($"Enter the ID of the Developer you want to add to {team.TeamName}:");
                string devID = Console.ReadLine().ToUpper();

                DeveloperInformation devToAdd = _devRepo.GetDeveloperByDevID(devID);
                team.AddNewMemberToTeam(devToAdd);

                bool WasAdded = team.AddNewMemberToTeam(devToAdd);
                // //provide confirmation
                if (WasAdded)
                {
                    System.Console.WriteLine("Developer added successfully!");
                }
                else
                {
                    System.Console.WriteLine("Sorry, developer was not added");
                }
            }
            else if (addNewMemberSelect == "n")
            { }
        }
        else
        {
            System.Console.WriteLine("Please choose a valid option");
        }
    }

    //11. Remove memeber from team
    private void RemoveMemberFromTeam()
    {
        Console.Clear();
        GetAllTeams();
        System.Console.WriteLine("Enter the TeamID you like to remove a member from:");
        string teamIDAsString = Console.ReadLine();
        int teamID = int.Parse(teamIDAsString);

        TeamInformation team = _teamRepo.GetTeamByTeamID(teamID);
        if (team != null)
        {
            DisplayTeamInformation(team);
            //Get teamID to remove member from
            System.Console.WriteLine($"Do you want to remove a member from {team.TeamName} ID# {team.TeamID}? (y/n)");
            string removeMemberSelect = Console.ReadLine().ToLower();
            if (removeMemberSelect == "y")
            {
                System.Console.WriteLine($"Enter the ID of the Developer you want to remove:");
                string devID = Console.ReadLine().ToUpper();

                DeveloperInformation devToRemove = _devRepo.GetDeveloperByDevID(devID);
                team.RemoveMemberFromTeam(devToRemove);

                bool WasRemoved = team.RemoveMemberFromTeam(devToRemove);
                //provide confirmation
                if (WasRemoved)
                {
                    System.Console.WriteLine("Developer removed successfully!");
                }
                else
                {
                    System.Console.WriteLine("Sorry, developer was not removed");
                }
            }
            else if (removeMemberSelect == "n")
            { }
            else
            {
                System.Console.WriteLine("Please choose a valid option");
            }
        }
    }

    // 12. Delete Team by ID
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
                $"Pluralsight Access: {developer.PluralsightAcccess}\n"
            );
    }

    private void DisplayTeamInformation(TeamInformation team)
    {
        Console.Clear();
        System.Console.WriteLine
        (
            $"Team Name: {team.TeamName}\n" +
            $"Team ID: {team.TeamID}\n"
        );
        foreach (DeveloperInformation dev in team.TeamMemberList)
        {
            System.Console.WriteLine($"{dev.FullName} ID: {dev.DevID} ");
        }
    }
}