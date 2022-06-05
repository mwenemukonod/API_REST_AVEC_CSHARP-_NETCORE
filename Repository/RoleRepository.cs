using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MairieTaxeAPI.Models;
using MairieTaxeAPI.ContextDbTables;
namespace MairieTaxeAPI.Repository
{
    public class RoleRepository
    {
        public GeneriqueResponse AjouterRole(ClsRole role)
        {
            Random ran = new Random();
            long a = ran.Next(1000000000);
            try
            {
               
                using (DataContextDbAndTablesMairie context = new DataContextDbAndTablesMairie())
                { //appel de la table rolepour l'utiliser donc enregistrer de dans
                    if (context.Role.Where(c => c.role == role.role).FirstOrDefault() != null)

                        return new GeneriqueResponse { Message = "Role Existe déjà!", StatusCode = System.Net.HttpStatusCode.Conflict };
                    if ( (string.IsNullOrEmpty(role.role.Trim())))
                        return new GeneriqueResponse { StatusCode = System.Net.HttpStatusCode.Forbidden, Message = "L'un de vos champs est vide" };
      //methode pour la sauvegarde de donner
                    context.Role.Add(role);
                    context.SaveChanges();
                    return new GeneriqueResponse { ResponseData = role, Message = "Role ajouter avec succèss", StatusCode = System.Net.HttpStatusCode.OK };
                }

            }
            catch (Exception ex)
            {
                return new GeneriqueResponse { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Une erreur s'est produite" };
            }
        }

        public GeneriqueResponse getAllRole()
        {
            try
            {
                using (DataContextDbAndTablesMairie context = new DataContextDbAndTablesMairie())
                { //appe; de la table personne pour l'utiliser donc enregistrer de dans

                    var roleliste = context.Role.ToList(); // pour retourner une liset des personne


                    return new GeneriqueResponse { ResponseData = roleliste, Message = "Liste de(s)nMairie(s)", StatusCode = System.Net.HttpStatusCode.OK };
                }

            }
            catch (Exception ex)
            {
                return new GeneriqueResponse { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Une erreur s'est produite" };
            }
        }
    }
}
