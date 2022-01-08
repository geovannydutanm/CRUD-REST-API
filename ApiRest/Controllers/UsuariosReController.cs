using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Diagnostics;
using ApiRestPrueba.DTOs;
using Services.Interfaces;
using Services.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestPrueba.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosReController : ControllerBase
    {
        //the user manager service is declared
        private readonly IGestionUsuarios _gestionarUsuarios;
        
        public UsuariosReController(IGestionUsuarios gestionarUsuarios)
        {
            _gestionarUsuarios = gestionarUsuarios;
        }

        //GET - returns all the database users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_gestionarUsuarios.GetAll());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error get record");
            }
        }

        // GETID - Allows you to consult the User Code
        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetID(string codigo)
        {
            try
            {
                //Returns the query that is made to the service layer
                var row = _gestionarUsuarios.GetById(codigo);
                if (row != null)
                {
                    //I return a successful response with your information
                    return Ok(_gestionarUsuarios.GetById(codigo));

                }
                else
                {
                    //return a response of status code 404, when there is no information
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error get record");
            }
        }

        //Post - Create new records
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] UsuariosRe usuarioResDto)
        {
            try
            {
                //Returns the query that is made to the service layer
                var row = _gestionarUsuarios.GetById(usuarioResDto.Codigo);
                if (row != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict);
                }
                else
                {
                    //I return a successful response with your information
                    return Ok(_gestionarUsuarios.Save(usuarioResDto));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new record");
            }
        }

        //PUT - Allows to modify registry
        [HttpPut("{codigo}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(string codigo, [FromBody] UsuariosRe usuarioResDto)
        {
            try
            {
                //Returns the query that is made to the service layer
                var row = _gestionarUsuarios.GetById(codigo);
                if (row != null)
                {
                    
                    //I return a successful response with your information
                    return Ok(_gestionarUsuarios.Save(usuarioResDto));
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified, "DO NOT MODIFY...");
                }
            }
            catch (Exception)
            {
                //returns 500 status code - Error Internal Server
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new record");
            }
        }

        //// Delete - delete records
        [HttpDelete("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(string codigo)
        {
            try
            {
                //Returns the query that is made to the service layer
                var row = _gestionarUsuarios.GetById(codigo);
                if (row != null)
                {
                    //delete the record
                    _gestionarUsuarios.Delete(codigo);
                    return Ok();
                    
                }
                else
                {
                    //returns 404 status code when not finding the result
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception)
            {
                //returns 500 status code - Error Internal Server
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Internal Server");
            }
        }

    }
}
