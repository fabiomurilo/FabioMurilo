using FabioMurilo.Contexts;
using FabioMurilo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FabioMurilo.Controllers.Api
{
    public class CategoriesController : ApiController
    {

        #region [ Properties ]

        private EFContext context = new EFContext();

        #endregion

        // GET: api/Categoties
        public IEnumerable<Category> Get()
        {
            return context.Categories.OrderBy(category => category.name);
        }

        private IEnumerable<Category> View(IOrderedQueryable<Category> orderedQueryable)
        {
            throw new NotImplementedException();
        }

        // GET: api/Categoties/5
        public Category Get(int id)
        {
            return context.Categories.Find(id);
        }

        // POST: api/Categoties
        public void Post([FromBody]Category value)
        {
        }

        // PUT: api/Categoties/5
        public void Put(int id, [FromBody]Category value)
        {
        }

        // DELETE: api/Categoties/5
        public void Delete(int id)
        {
        }
    }
}
