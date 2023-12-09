using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnologicoApp.Models;
using TecnologicoApp.Services.Interfaces;

namespace TecnologicoApp.Services
{
    public class SignupSignninService : ISignupSignninService
    {
        public Task<bool> SingUpAsync(UsuarioRegistro usuario);

        var result = false;
        await Task.Delay(1000);

     if (UsuarioRegistro == null|| string.IsNullOrwhiteSpace(usuario.Email)) || string.IsNullOrwhiteSpace(usuario.Password))
        
        {
          return false;
        }


            Settings.RegitroEmail= usuarioRegistro.Email;
            Settings.RegitroPassword= usuario.Email;
            Settings.IsRegistered= true;
         
      return true;

    }
       
    
}

//string ejemplo = null;
//var ejemplo2 = string.Empty;
//var ejemplo3 = "";
