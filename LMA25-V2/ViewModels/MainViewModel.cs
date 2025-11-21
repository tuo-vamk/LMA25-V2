using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LMA25_V2.Interfaces;
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
        var joke = await _jokeService.GetJokeAsync();
        List<IPrintable> jokes = await _jokeService.GetJokesAsync(3);
        foreach (var j in jokes)
        {
            System.Diagnostics.Debug.WriteLine(j.ToString());
        }
        JokeText = joke.ToString() ?? "";
        return JokeText;
    }
}