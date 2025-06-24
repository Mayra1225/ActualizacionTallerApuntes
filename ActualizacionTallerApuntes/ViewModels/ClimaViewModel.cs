using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActualizacionTallerApuntes.Models;
using ActualizacionTallerApuntes.Services;

namespace ActualizacionTallerApuntes.ViewModels
{
    public class ClimaViewModel: INotifyPropertyChanged
    {
        private readonly ClimaService _servicio = new();

        private Clima _info;
        public Clima Info
        {
            get => _info;
            set { _info = value; OnPropertyChanged(nameof(Info)); }
        }

        public Command ObtenerCommand { get; }

        public ClimaViewModel()
        {
            ObtenerCommand = new Command(async () => await ObtenerClimaAsync());
        }

        private async Task ObtenerClimaAsync()
        {
            var location = await Geolocation.GetLastKnownLocationAsync() ??
                           await Geolocation.GetLocationAsync(new GeolocationRequest());

            if (location != null)
            {
                Info = await _servicio.ObtenerClimaAsync(location.Latitude, location.Longitude);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
