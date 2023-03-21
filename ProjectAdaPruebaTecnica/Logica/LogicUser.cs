using ProjectAdaPruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectAdaPruebaTecnica.Logica
{
    public class LogicUser
    {

        public async Task<Usuario> AutenticationUser(Usuario model)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    var User = await bd.Usuario.Where(u => u.UsuarioAcceso == model.UsuarioAcceso &&
                                                u.Clave == model.Clave).FirstOrDefaultAsync();
                    if (User == null)
                        return null;

                    return User;


                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<bool> RegisterUser(Usuario model)
        {
            model.IdRol = 2;

            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    bd.Usuario.Add(model);
                    await bd.SaveChangesAsync();

                    return true;

                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<Usuario> ValidateExistUser(Usuario model)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                   var uservalidateExist = await bd.Usuario.Where(u => u.Identificacion == model.Identificacion ||
                                     u.UsuarioAcceso == model.UsuarioAcceso).FirstOrDefaultAsync();

                    return uservalidateExist;

                }catch(Exception ex)
                {
                    return null;
                }
            }



        }
    }
}