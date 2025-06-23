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
    public class RecordatorioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Recordatorio> Recordatorios { get; set; } = new();
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        private string nuevoTexto;
        public string NuevoTexto
        {
            get => nuevoTexto;
            set
            {
                if (nuevoTexto != value)
                {
                    nuevoTexto = value;
                    OnPropertyChanged(nameof(NuevoTexto));
                }
            }
        }

        private TimeSpan nuevaHora = TimeSpan.FromHours(12);
        public TimeSpan NuevaHora
        {
            get => nuevaHora;
            set
            {
                if (nuevaHora != value)
                {
                    nuevaHora = value;
                    OnPropertyChanged(nameof(NuevaHora));
                }
            }
        }

        public RecordatorioViewModel()
        {
            AddCommand = new Command(AddRecordatorio);
            DeleteCommand = new Command<Recordatorio>(DeleteRecordatorio);
            LoadRecordatorios();
        }

        private async void LoadRecordatorios()
        {
            var lista = await RecordatorioService.LoadAsync();
            foreach (var r in lista)
                Recordatorios.Add(r);
        }

        private async void SaveRecordatorios() =>
            await RecordatorioService.SaveAsync(Recordatorios.ToList());

        private void AddRecordatorio()
        {
            if (!string.IsNullOrWhiteSpace(NuevoTexto))
            {
                var nuevo = new Recordatorio
                {
                    Texto = NuevoTexto,
                    FechaHora = NuevaHora,
                    Activo = true
                };

                Recordatorios.Add(nuevo);
                SaveRecordatorios();

                // Limpiar campos después de agregar
                NuevoTexto = string.Empty;
                NuevaHora = TimeSpan.FromHours(12);
            }
        }

        private void DeleteRecordatorio(Recordatorio r)
        {
            if (Recordatorios.Contains(r))
            {
                Recordatorios.Remove(r);
                SaveRecordatorios();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
