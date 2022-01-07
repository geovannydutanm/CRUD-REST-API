using System;
using System.Collections.Generic;
using Services.Entities;

namespace Services.Interfaces
{
    public interface IGestionUsuarios
    {
        //interface for the functions to operate the CRUD
        List<UsuariosRe> GetAll();
        UsuariosRe GetById(string Codigo);
        UsuariosRe Save(UsuariosRe usuariosRe);
        void Delete(string Codigo);

    }
}
