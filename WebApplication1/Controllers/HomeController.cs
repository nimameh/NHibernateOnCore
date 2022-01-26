using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Linq;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapperSession _session;

        public HomeController(IMapperSession session)
        {
            _session = session;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _session.Books.ToListAsync();
            return Ok(books);
        }
    }
}
