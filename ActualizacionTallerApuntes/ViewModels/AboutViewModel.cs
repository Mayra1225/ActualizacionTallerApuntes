using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActualizacionTallerApuntes.Models;
using System.Collections.ObjectModel;

namespace ActualizacionTallerApuntes.ViewModels
{
    public class AboutViewModel
    {
        public ObservableCollection<Miembro> Integrantes { get; } = new()
        {
            new Miembro { Nombre = "Eduardo Andrade", Edad = 18, DeporteFavorito = "Fútbol", Foto = "eduardoandrade.jpg" },
            new Miembro { Nombre = "Ashlee Soledispa", Edad = 19, DeporteFavorito = "Gym", Foto = "ashleesoledispa.jpg" },
            new Miembro { Nombre = "Mayra Vargas", Edad = 35, DeporteFavorito = "Gym", Foto = "mayravargas.jpg" }
        };
    }
}
