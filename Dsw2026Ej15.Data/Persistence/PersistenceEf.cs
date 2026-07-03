using Dsw2026Ej15.Data.Context;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Dsw2026Ej15.Data.Persistence;

public class PersistenceEf : IPersistence
{
    private readonly AppDbContext _context;

    public PersistenceEf(AppDbContext context)
    {
        _context = context;
    }

    public void AgregarDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
    }

    public IEnumerable<Doctor> ObtenerDoctores()
    {
        return _context.Doctors
            .Where(x => x.IsActive)
            .Include(x => x.Speciality)
            .ToList();
    }

    public Doctor? ObtenerDoctor(Guid id)
    {
        return _context.Doctors
            .Include(x => x.Speciality)
            .FirstOrDefault(x => x.Id == id && x.IsActive);
    }

    public void ActualizarDoctor(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        _context.SaveChanges();
    }

    public Speciality? ObtenerEspecialidadPorId(Guid id)
    {
        return _context.Specialities.FirstOrDefault(x => x.Id == id);
    }
}