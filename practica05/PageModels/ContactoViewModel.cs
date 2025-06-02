using practica05.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica05.PageModels
{
    internal class ContactoViewModel
    {
        public ObservableCollection<Contacto> Contactos { get; set; }
        public ContactoViewModel()
        {
            Contactos = new ObservableCollection<Contacto>
            {
                new Contacto {Nombre = "Juan Perez", Telefono = "1234567890", Correo = "juan@mail.com", Direccion = "Calle 1" },
                new Contacto { Nombre = "Ana García", Telefono = "0987654321", Correo = "ana@mail.com", Direccion = "Calle 2" }

            };
        }
    }
}
