using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Services.Entities;
using Services.Interfaces;

namespace Services
{
    public class GestionarUsuarios : IGestionUsuarios
    {
        static List<UsuariosRe> _usuariosRe;
        public string conexionBD = "../Services/DataBase/usuarioRe.json";
        
        public GestionarUsuarios(List<UsuariosRe> usuariosRe)
        {
            _usuariosRe = usuariosRe;
        }
        public GestionarUsuarios()
        {
            using (StreamReader rd = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), conexionBD)))
            {
                _usuariosRe = JsonConvert.DeserializeObject<List<UsuariosRe>>(rd.ReadToEnd());
            }
        }

        // Method - returns list of users
        public List<UsuariosRe> GetAll() => _usuariosRe;

        
        // Method - returns a specific user based on the code queried
        public UsuariosRe GetById(string Codigo)
        {
            var row = _usuariosRe.Find(x => x.Codigo == Codigo);
            if (row != null)
            {
                return row;
            }
            else
            {
                return null;
            }
        }

        // Method - save user records
        public UsuariosRe Save(UsuariosRe usuariosRe)
        {
            string jsonString = System.IO.File.ReadAllText(conexionBD);
            var row = _usuariosRe.Find(x => x.Codigo == usuariosRe.Codigo);
            if (row != null)
            {
                _usuariosRe.Remove(row);
                _usuariosRe.Add(usuariosRe);
                jsonString = JsonConvert.SerializeObject(_usuariosRe);
                System.IO.File.WriteAllText(conexionBD, jsonString);
                return usuariosRe;
            }
            else
            {
                _usuariosRe.Add(usuariosRe);
                jsonString = JsonConvert.SerializeObject(_usuariosRe);
                System.IO.File.WriteAllText(conexionBD, jsonString);
                return usuariosRe;
            }
        }
        
        // Method - delete user record
        public void Delete(string Codigo)
        {
            string jsonString = System.IO.File.ReadAllText(conexionBD);
            var row = _usuariosRe.Find(x => x.Codigo == Codigo);
            if (row != null)
            {
                _usuariosRe.Remove(row);
                jsonString = JsonConvert.SerializeObject(_usuariosRe);
                System.IO.File.WriteAllText(conexionBD, jsonString);
                
            }
            else
            {

            }
        }

     
    }
}
