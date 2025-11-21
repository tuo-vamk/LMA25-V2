using LMA25_V2.Interfaces;
using LMA25_V2.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LMA25_V2.ViewModels;

public class NotesViewModel : BindableObject
{
    public ObservableCollection<Note> Notes { get; } = new();

    private string _text;
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddNoteCommand { get; }

    private readonly INoteService _noteService;

    public NotesViewModel(INoteService noteService)
    {
        AddNoteCommand = new Command(AddNote);
        _noteService = noteService;
    }

    private void AddNote()
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            Notes.Add(new Note { Text = Text, Date = DateTime.Now });
            Text = string.Empty;
        }
    }
}
