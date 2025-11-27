using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LMA25_V2.Interfaces;
using LMA25_V2.Models;
using LMA25_V2.Pages;

namespace LMA25_V2.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IJokeService _jokeService;
    public MainViewModel(IJokeService jokeService)
    {
        _jokeService = jokeService;
    }

    [ObservableProperty]
    private string jokeText;

    [RelayCommand]
    private async Task GoToNotes()
    {
        await Shell.Current.GoToAsync(nameof(NotesPage));
    }

    [RelayCommand]
    private async Task<string> GetJokeAsync()
    {
        var result = await _jokeService.GetJokeAsync();

        if(result.IsSuccess == false)
        {
            JokeText = result.ErrorMessage ?? "Unknown Error!";
        }

        JokeText = result.Data?.Print() ?? "Unknown Error!";
        return JokeText;
    }
}