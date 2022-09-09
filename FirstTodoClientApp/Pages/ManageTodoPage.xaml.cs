using FirstTodoClientApp.DataServices;
using FirstTodoClientApp.Models;
using System.Diagnostics;
using System.Xml.Serialization;

namespace FirstTodoClientApp.Pages;

[QueryProperty(nameof(ToDo), "ToDo")]
public partial class ManageTodoPage : ContentPage
{
    private readonly IRestDataService _dataService;
    ToDo _todo;
    bool _isNew;

    public ToDo toDo { 
        get => _todo; 
        set
        {
            _isNew = IsNew(value);
            _todo = value;
            OnPropertyChanged();
        }
    }
    public ManageTodoPage(IRestDataService dataService)
    {
        InitializeComponent();

        _dataService = dataService;
        BindingContext = this;

    }


    bool IsNew(ToDo toDo)
    {
        if (toDo.Id == 0)
            return true;
        return false;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            Debug.WriteLine("--> Add new item!");

            await _dataService.AddTodoAsync(toDo);

        }
        else
        {
            Debug.WriteLine("--> Updated item!");

            await _dataService.UpdateTodoAsync(toDo);
        }
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataService.DeleteTodoAsync(toDo.Id);
        await Shell.Current.GoToAsync("..");

    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}