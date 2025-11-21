using LMA25_V2.ViewModels;

namespace LMA25_V2.Pages;

public partial class NotesPage : ContentPage
{
    public NotesPage(NotesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}