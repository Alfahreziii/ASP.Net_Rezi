using Microsoft.AspNetCore.Mvc;
using FakultasApi.Models;
using FakultasApi.DTOs;
using FakultasApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace FakultasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class FakultasController : ControllerBase
    {
        private readonly FakultasService _service;

        public FakultasController(FakultasService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var mahasiswa = _service.GetById(id);
            if (mahasiswa == null)
                return NotFound();
            return Ok(mahasiswa);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFakultasDto dto)
        {
            var mahasiswa = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = mahasiswa.Id }, mahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound(new { message = "Mahasiswa not found." });
            return Ok(new { message = "Mahasiswa deleted successfully." });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFakultasDto dto)
        {
            var updated = _service.Update(id, dto);
            if (updated == null)
                return NotFound(new { message = "Mahasiswa not found." });
            return Ok(updated);
        }
    }
}