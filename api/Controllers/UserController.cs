using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NetCore3WebAPI.Models;
using Dapper;

namespace NetCore3WebAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ConnectionStrings con;
        public UserController(ConnectionStrings c)
        {
            con = c;
        }

        /// <summary>
        /// List users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] User vm)
        {
            return await Task.Run(() =>
            {
                using (var c = new MySqlConnection(con.MySQL))
                {
                    var sql = @"SELECT * FROM user 
                                WHERE (@id = 0 OR id = @id) 
                                AND (@name IS NULL OR UPPER(name) = UPPER(@name))";
                    var query = c.Query<User>(sql, vm, commandTimeout: 30);
                    return Ok(query);
                }
            });
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User vm)
        {
            return await Task.Run(() =>
            {
                using (var c = new MySqlConnection(con.MySQL))
                {
                    var sql = @"INSERT INTO user (name) VALUES (@name)";
                    c.Execute(sql, vm, commandTimeout: 30);
                    return Ok();
                }
            });
        }
    }
}