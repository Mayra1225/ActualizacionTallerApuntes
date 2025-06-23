using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActualizacionTallerApuntes.Models;

namespace ActualizacionTallerApuntes.Services
{
    public class NoteService
    {
        private string notesPath => FileSystem.AppDataDirectory;

        public async Task<List<Note>> LoadNotesAsync()
        {
            var notes = new List<Note>();
            var files = Directory.GetFiles(notesPath, "*.notes.txt");
            foreach (var file in files)
            {
                var text = await File.ReadAllTextAsync(file);
                notes.Add(new Note
                {
                    Filename = file,
                    Text = text,
                    Date = File.GetLastWriteTime(file)
                });
            }
            return notes.OrderByDescending(n => n.Date).ToList();
        }

        public async Task SaveNoteAsync(Note note)
        {
            if (string.IsNullOrWhiteSpace(note.Filename))
                note.Filename = Path.Combine(notesPath, $"{Path.GetRandomFileName()}.notes.txt");

            await File.WriteAllTextAsync(note.Filename, note.Text);
        }

        public Task DeleteNoteAsync(Note note)
        {
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);

            return Task.CompletedTask;
        }
    }
}
