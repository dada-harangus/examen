﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Lab2Expense.Models;
using Lab2Expense.Services;
using Lab2Expense.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2Expense.Controllers
{
    // https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api
    [Authorize(Roles = "Admin, UserManager")]
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginPostModel login)
        {
            var user = _userService.Authenticate(login.Username, login.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        //[HttpPost]
        public IActionResult Register([FromBody]RegisterPostModel registerModel)
        {
            var errors = _userService.Register(registerModel);//, out User user);
            if (errors != null)
            {
                return BadRequest(errors);
            }
            return Ok();//user);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // PUT: api/Users/5
        /// <summary>
        /// Update the User with the given id
        /// </summary>
        ///  /// <remarks>
        /// Sample request:
        /// PUT/users
        /// {
        ///   "first": "cheeseburger2",
        ///   "sum": 10,
        /// "location": "fastfood",
        ///"date": "2019-05-09T12:30:00",
        /// "currency": "EUR",
        /// "expenseType": 5
        /// }
        /// </remarks>
        /// <param name="id">The id of the expense we want to update</param>
        /// <param name="user">The User that contains the new data</param>
        /// <returns>An User object</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] User user)
        {

            var userCurrent = _userService.GetCurrentUser(HttpContext);
            var result = _userService.Upsert(id, user, userCurrent);
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Delete the User with the given id
        /// </summary>
        /// <param name="id">The id of the user we want to delete</param>
        /// <returns>an User object</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var existing = _userService.Delete(id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }
        /// <summary>
        /// Changes a user role 
        /// </summary>
        /// <param name="Role">which user and in what role you want to change the current role </param>
        /// <returns>the new user role </returns>
        [AllowAnonymous]
        [HttpPut]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeRole( [FromBody] Role Role)
        {
            //if (User.IsInRole("UserManager"))
            //{
            //    return NoContent();
            //}
            var userCurrent = _userService.GetCurrentUser(HttpContext);
            var existing = _userService.ChangeRole(Role.idUser, Role.RoleType, userCurrent);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);

        }
        /// <summary>
        /// Gets the history role for a user
        /// </summary>
        /// <param name="id">which user </param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetHistoryRoles")]
        public IActionResult GetHistoryRoles(int id)
        {
            var found = _userService.GetHistoryRoles(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

    }
}