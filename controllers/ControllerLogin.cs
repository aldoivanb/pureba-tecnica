using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using testdevbackjr.Data;
using testdevbackjr.Models;

namespace testdevbackjr.Controllers
{
    [ApiController]
    [Route("api/logins")]
    public class LoginsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.Logins
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login login)
        {
            if (login == null)
                return BadRequest("Datos inválidos");

            var userExists = await _context.Users
                .AnyAsync(u => u.User_id == login.User_id);

            if (!userExists)
                return BadRequest("El usuario no existe");

            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return Ok(login);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Login login)
        {
            var existing = await _context.Logins.FindAsync(id);

            if (existing == null)   
                return NotFound();

            existing.User_id = login.User_id;
            existing.Extension = login.Extension;
            existing.TipoMov = login.TipoMov;
            existing.Fecha = login.Fecha;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _context.Logins.FindAsync(id);

            if (existing == null)
                return NotFound();

            _context.Logins.Remove(existing);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Eliminado correctamente"
            }); 
        }

        
        [HttpGet("report/csv")]
        public async Task<IActionResult> GenerateCsvReport()
        {
            var users = await _context.Users
                .Include(u => u.Area)
                .ToListAsync();

            var logs = await _context.Logins
                .OrderBy(l => l.User_id)
                .ThenBy(l => l.Fecha)
                .ToListAsync();

            var csv = new StringBuilder();
            csv.AppendLine("Login,NombreCompleto,Area,TotalHoras");

            foreach (var user in users)
            {
                var userLogs = logs.Where(l => l.User_id == user.User_id);

                DateTime? loginTime = null;
                double totalHours = 0;

                foreach (var log in userLogs)
                {
                    if (log.TipoMov == 0)
                        loginTime = log.Fecha;
                    else if (log.TipoMov == 1 && loginTime != null)
                    {
                        totalHours += (log.Fecha - loginTime.Value).TotalHours;
                        loginTime = null;
                    }
                }

                var fullName = $"{user.Nombres} {user.ApellidoPaterno} {user.ApellidoMaterno}";

                csv.AppendLine($"{user.Login},{fullName},{user.Area?.AreaName ?? "Sin área"},{Math.Round(totalHours, 2)}");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "reporte_usuarios.csv");
        }
    }
}