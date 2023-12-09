using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnologicoApp.Models;

namespace TecnologicoApp.Services.Interfaces
{
    public class ISignupSignninService
    {
        public Task <bool> SingUpAsync(UsuarioRegistro usuario);


    }

}
