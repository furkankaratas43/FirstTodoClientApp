using FirstTodoClientApp.DataServices;
using FirstTodoClientApp.Models;
using FirstTodoClientApp.Pages;
using System.Diagnostics;

namespace FirstTodoClientApp;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public MainPage(IRestDataService dataService)
    {
        InitializeComponent();

        _dataService = dataService;
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();

        collectionView.ItemsSource = await _dataService.GetAllTodosAsync();
    }


    async void OnAddTodoClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("--> Add button clicked!");

        var navigationParamater = new Dictionary<string, object>
        {
            { nameof(ToDo), new ToDo() }
        };

        await Shell.Current.GoToAsync(nameof(ManageTodoPage), navigationParamater);
    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("--> Item changed clicked!");

        var navigationParamater = new Dictionary<string, object>
        {
            { nameof(ToDo), e.CurrentSelection.FirstOrDefault() as ToDo }
        };

        await Shell.Current.GoToAsync(nameof(ManageTodoPage), navigationParamater);
    }
}

