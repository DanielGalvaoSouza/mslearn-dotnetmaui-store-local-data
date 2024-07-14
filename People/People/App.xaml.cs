namespace People;

public partial class App : Application
{
    // TODO: Add a public static PersonRepository property
    public static Models.PersonRepository PersonRepo { get; private set; }

    public App(Models.PersonRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        // TODO: Initialize the PersonRepository property with the PersonRespository singleton object
        PersonRepo = repo;

    }
}
