public class ProgramUI
{
    private readonly DeveloperRepository _devRepo = new DeveloperRepository();

    private readonly TeamRepository _teamRepo = new TeamRepository();

    public void Run()
    {

        //Seed content to test with DEVS)
        DevSeed();
        //Seed conent to test with TEAMS
        TeamSeed();
        // Menu
        RunMenu();
    }

    public void DevSeed()
    {
        DeveloperInformation developerOne = new DeveloperInformation(
            "Kali",
            "Miller",
            "KM12",
            true,
            TeamType.FrontEnd
        );

        DeveloperInformation developerTwo = new DeveloperInformation(
            "John",
            "James",
            "JJ34",
            true,
            TeamType.BackEnd
        );

        DeveloperInformation developerThree = new DeveloperInformation(
            "Anne",
            "Martin",
            "AM56",
            false,
            TeamType.Mobile
        );

        DeveloperInformation developerFour = new DeveloperInformation(
            "Phillip",
            "Grant",
            "PG78",
            true,
            TeamType.Mobile
        );

        DeveloperInformation developerFive = new DeveloperInformation(
            "Sarah",
            "Vicks",
            "SV90",
            false,
            TeamType.BackEnd
        );

        DeveloperInformation developerSix = new DeveloperInformation(
            "Eric",
            "Erickson",
            "EE23",
            true,
            TeamType.FrontEnd
        );

        _devRepo.AddNewDeveloper(developerOne);
        _devRepo.AddNewDeveloper(developerTwo);
        _devRepo.AddNewDeveloper(developerThree);
        _devRepo.AddNewDeveloper(developerFour);
        _devRepo.AddNewDeveloper(developerFive);
        _devRepo.AddNewDeveloper(developerSix);
    }

    public void TeamSeed()
    {
        TeamInformation teamOne = new TeamInformation(
            "FrontEnd",
            101
        );

        TeamInformation teamTwo = new TeamInformation(
            "BackEnd",
            202
        );

        TeamInformation teamThree = new TeamInformation(
            "Mobile",
            303
        );

        _teamRepo.AddNewTeam(teamOne);
        _teamRepo.AddNewTeam(teamTwo);
        _teamRepo.AddNewTeam(teamThree);
    }

    // public void RunMenu()
    // {
        System.Console.WriteLine(
            "Menu: \n" +
            "1. List All Existing Developers\n" +
            "3. View Developer by ID\n" +
            "4. Update Developer by ID\n" +
            "5. List All Existing Teams\n" +
            "6. View Team by ID\n" +
            "7. Add New Team \n"
            "7. Update Team by ID\n" +
            "8. Delete Team by ID\n" + 
        );

    //     string selection = Console.ReadLine() ?? "";

    //     System.Console.WriteLine(selection);

    //     switch (selection) {
    //         case "1":
    //             CreateNewDeveloper
    //     }
}
