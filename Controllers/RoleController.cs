using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MairieTaxeAPI.Models;
using MairieTaxeAPI.Repository;
using MairieTaxeAPI.ContextDbTables;
namespace MairieTaxeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleRepository repository = new RoleRepository();
        [HttpPost]
        public ActionResult AjouterRole(ClsRole role)
        {
            try
            {
                return Ok(repository.AjouterRole(role));
            }
            catch (Exception ex)
            {
                return Ok(new GeneriqueResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "une erreure est produite"
                });
            }
        }
        [HttpGet]
        public ActionResult getAllRole()
        {
            try
            {
                return Ok(repository.getAllRole());

            }
            catch (Exception ex)
            {
                return Ok(new GeneriqueResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Une erreure se produite"
                });
            }

        }
        [HttpPut("{idrole}")]
        public ActionResult ModifierRole(ClsRole request, string idrole)
        {
            try
            {
                using (DataContextDbAndTablesMairie context = new DataContextDbAndTablesMairie())
                {
                    var role = context.Role.Find(idrole);
                      if (role == null)
                        return Ok(new GeneriqueResponse { Message = "Selectionnez le role svp!!", StatusCode = System.Net.HttpStatusCode.Conflict });

                         role.role = request.role;

                         context.SaveChanges();
                }
                return Ok(new GeneriqueResponse { ResponseData = request, Message = "Mise à jour faite avec succès", StatusCode = System.Net.HttpStatusCode.OK }); ; ;
            }
            catch (Exception ex)
            {
                return Ok(new GeneriqueResponse { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "An Error Occurred", Error = ex.Message + ":::" + ex.StackTrace });
            }
        }

    }
}
