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
    public class Products : ControllerBase
    {
        private readonly BD_ADA_SAContext _dbContext;

        public Products(BD_ADA_SAContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<Producto>> ListProductsavailables()
        {
            var lstProducts = await _dbContext.Productos.Where(p => p.CantidadDisponible > 0).ToListAsync();

            return lstProducts;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Producto updatedProduct)
        {
            if (id <= 0)
                return BadRequest("Id no válido");

            var findProduct = await _dbContext.Productos.Where(p => p.IdProducto == id).FirstOrDefaultAsync();

            if (findProduct == null)
                return BadRequest("Producto no encontraso con el id");

            try
            {
                _dbContext.Productos.Attach(findProduct);

                findProduct.IdProducto = updatedProduct.IdProducto;
                findProduct.Nombre = updatedProduct.Nombre;
                findProduct.Caracteristica = updatedProduct.Caracteristica;
                findProduct.CantidadDisponible = updatedProduct.CantidadDisponible;
                findProduct.Precio = updatedProduct.Precio;
                findProduct.Descripcion = updatedProduct.Descripcion;
                findProduct.RutaImagen = updatedProduct.RutaImagen;

                await _dbContext.SaveChangesAsync();

                return Ok("Producto actualizado con exito");
            }
            catch (Exception ex)
            {
                return BadRequest("No se pudo actualizar el producto");
            }


        }


    }
}
