using ApiAdaProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAdaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBuys : ControllerBase
    {
        private readonly BD_ADA_SAContext _dbContext;

        public UserBuys(BD_ADA_SAContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<Usuario>> ListUsersBuys()
        {
            var lstUserBuys = await _dbContext.Usuarios.Where(u => u.IdRol == 2).ToListAsync();

            return lstUserBuys;
        }
    }
}
