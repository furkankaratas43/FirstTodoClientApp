using FirstTodoClientApp.Pages;

namespace FirstTodoClientApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ManageTodoPage), typeof(ManageTodoPage));
	}
}
