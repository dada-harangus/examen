using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2Expense.Services;
using Lab2Expense.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2Expense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private IPackageService packageService;
        private IUsersService usersService;

        public PackagesController(IPackageService packageService, IUsersService usersService)
        {
            this.packageService = packageService;
            this.usersService = usersService;
        }
        // GET: api/packages
        /// <summary>
        /// Get all the packages
        /// </summary>

        /// <returns>A list of package objects</returns>

        [HttpGet]
        public IEnumerable<PackageGetModel> Get()
        {

            return packageService.GetAll();

        }

        //GET: api/Package/5
        /// <summary>
        /// Get the package that has the id requested
        /// </summary>
        /// <param name = "id" > The id of the package</param>
        /// <returns>The package with the given Id</returns>


        [HttpGet("GetByExpeditor")]
        public IEnumerable<PackageGetModel> GetByExpeditor([FromQuery]string expeditor)
        {

            return packageService.GetByExpeditor(expeditor);

        }


        [HttpGet("Filter")]
        public IEnumerable<DestinatarViewModel> Filter()
        {

            return packageService.Filter();

        }

        [HttpGet("{id}", Name = "GetPackage")]
        public IActionResult Get(int id)
        {
            var found = packageService.GetById(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        // POST: api/Package

        /// <summary>
        /// Add an Package
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST/userRole
        /// { "Name":admin
        ///   "description": "cheeseburger2",
        ///   
        /// }
        /// </remarks>
        /// <param name="PackagePostModel">The Package that we want to add</param>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public void Post([FromBody] PackagePostModel packagePostModel)
        {
            //   User addedBy = usersService.GetCurrentUser(HttpContext);
            packageService.Create(packagePostModel);
        }

        // PUT: api/Package/5
        /// <summary>
        /// Update the Package with the given id
        /// </summary>
        ///  /// <remarks>
        /// Sample request:
        /// PUT/expenses
        /// {
        /// "Name": "admin"  
        /// "description": "cheeseburger2",
        ///   
        /// }
        /// </remarks>
        /// <param name="id">The id of the Package we want to update</param>
        /// <param name="expense">The Package that contains the new data</param>
        /// <returns>An Package object</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] PackagePostModel packagePostModel)
        {
            var result = packageService.Upsert(id, packagePostModel);
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Delete the userRole with the given id
        /// </summary>
        /// <param name="id">The id of the userRole we want to delete</param>
        /// <returns>an userRole object</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var existing = packageService.Delete(id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }
    }
}
