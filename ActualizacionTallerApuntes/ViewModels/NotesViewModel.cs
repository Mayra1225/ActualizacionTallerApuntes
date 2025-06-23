using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ActualizacionTallerApuntes.Models;
using ActualizacionTallerApuntes.Services;

namespace ActualizacionTallerApuntes.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Note> Notes { get; } = new();
        private readonly NoteService _noteService = new();

        public ICommand LoadCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        private Note _selectedNote = new();
        public Note SelectedNote
        {
            get => _selectedNote;
            set { _selectedNote = value; OnPropertyChanged(nameof(SelectedNote)); }
        }

        public NotesViewModel()
        {
            LoadCommand = new Command(async () => await LoadNotesAsync());
            SaveCommand = new Command(async () => await SaveNoteAsync());
            DeleteCommand = new Command(async () => await DeleteNoteAsync());

            LoadCommand.Execute(null);
        }

        private async Task LoadNotesAsync()
        {
            Notes.Clear();
            var list = await _noteService.LoadNotesAsync();
            foreach (var note in list)
                Notes.Add(note);
        }

        private async Task SaveNoteAsync()
        {
            await _noteService.SaveNoteAsync(SelectedNote);
            await LoadNotesAsync();
            SelectedNote = new Note();
        }

        private async Task DeleteNoteAsync()
        {
            await _noteService.DeleteNoteAsync(SelectedNote);
            await LoadNotesAsync();
            SelectedNote = new Note();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}


