using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Api.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorsController : ControllerBase
{
    private readonly IPersistence _persistence;

    public DoctorsController(IPersistence persistence)
    {
        _persistence = persistence;
    }

    [HttpPost]
    [EndpointSummary("Insertar un nuevo Médico")]
    public async Task<IActionResult> CrearDoctor([FromBody] CrearDoctorRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("El nombre es requerido.");
        if (string.IsNullOrWhiteSpace(request.LicenseNumber))
            return BadRequest("El número de licencia es requerido.");

        var especialidad = await _persistence.ObtenerEspecialidadPorId(request.SpecialityId);
        if (especialidad == null)
            return BadRequest("La especialidad no existe.");

        var doctor = new Doctor
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LicenseNumber = request.LicenseNumber,
            IsActive = true,
            Speciality = especialidad
        };

        await _persistence.AgregarDoctor(doctor);
        return StatusCode(201);
    }

    public class CrearDoctorRequest
    {
        public required string Name { get; set; }
        public required string LicenseNumber { get; set; }
        public Guid SpecialityId { get; set; }
    }

    [HttpGet]
    [EndpointSummary("Obtener todos los médicos activos")]
    public async Task<IActionResult> ObtenerDoctores()
    {
        var doctores = await _persistence.ObtenerDoctores();
        return Ok(doctores);
    }

    [HttpGet("{id}")]
    [EndpointSummary("Obtener un médico activo a partir de su Id")]
    public async Task<IActionResult> ObtenerDoctor(Guid id)
    {
        var doctor = await _persistence.ObtenerDoctor(id);
        if (doctor == null)
            return NotFound("El médico no existe o no está activo.");

        return Ok(new
        {
            doctor.Name,
            doctor.LicenseNumber,
            SpecialityName = doctor.Speciality.Name
        });
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Establecer como inactivo al médico")]
    public async Task<IActionResult> EliminarDoctor(Guid id)
    {
        var doctor = await _persistence.ObtenerDoctor(id);
        if (doctor == null)
            return NotFound("El médico no existe o ya no está activo");

        doctor.DesactivarMedico();
        await _persistence.ActualizarDoctor(doctor);
        return NoContent();
    }
}