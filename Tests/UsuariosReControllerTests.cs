using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiRestPrueba.Controllers;
using Services.Interfaces;
using Services;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UsuariosReControllerTests
    {
        private GestionarUsuarios gestionarUsuariosService;
        public UsuariosReControllerTests()
        {
            gestionarUsuariosService = new GestionarUsuarios();
        }
        //Unit Test - User List
        [TestMethod]
        public void GetAllUsuariosRe_ShouldReturnAllUsuariosRe()
        {
            var testUsuario = GetTestUsuariosReData();
            
            var controller = new UsuariosReController(gestionarUsuariosService);
            GestionarUsuarios gestionarUsuariosService = new GestionarUsuarios(testUsuario);
            var result = controller.Get() as List<UsuariosRe>;
            Assert.AreEqual(testUsuario.Count, result.Count);
        }

        //Unit test - user by Code
        [TestMethod]
        public void GET_GestionarUsuarios_GETID()
        {
            var controller = new UsuariosReController(gestionarUsuariosService);
            //var controller = new UsuariosReController(GetTestUsuario());
            var result = controller.GetID("user1");
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        //data upload
        private List<UsuariosRe> GetTestUsuariosReData()
        {
            var testUsuariosRe = new List<UsuariosRe>();
            
            testUsuariosRe.Add(new UsuariosRe { Codigo="user1",Clave="user1clave",TipoProf="F",Nombre="Prueba111",Apellidos="Pruebaapellidos11" });
            testUsuariosRe.Add(new UsuariosRe { Codigo="user2",Clave="user2clave",TipoProf="F",Nombre="Prueba222",Apellidos="Pruebaapellidos" });
            testUsuariosRe.Add(new UsuariosRe { Codigo="user3",Clave="user3clave",TipoProf="F",Nombre="Prueba33",Apellidos="Pruebaapellidos" });
            testUsuariosRe.Add(new UsuariosRe { Codigo="user4",Clave="user4clave",TipoProf="F",Nombre="Prueba",Apellidos="Pruebaapellidos" });
            testUsuariosRe.Add(new UsuariosRe { Codigo="user5",Clave="user5clave",TipoProf="F",Nombre="Prueba",Apellidos="Pruebaapellidos" });

            return testUsuariosRe;
        }

    }
}