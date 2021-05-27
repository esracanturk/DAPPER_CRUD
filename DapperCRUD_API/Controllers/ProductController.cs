using DapperCRUD_API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD_API.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        
        [HttpGet("GetAll")]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }

        [HttpGet("GetById")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        
        [HttpPost]

        public void Post([FromBody]Product prod)
        {
            //prod.ProductId = id;
            
            if (ModelState.IsValid)
                productRepository.Add(prod);
        }

        [HttpPut]
        public void Put(int id, [FromBody] Product prod)
        {
            prod.ProductId = id;
            if (ModelState.IsValid)
                productRepository.Update(prod);
        }

        [HttpDelete]
        public void Delete([FromBody] Product prod)
        {
            productRepository.Delete(prod.ProductId);
        }
    }
}
