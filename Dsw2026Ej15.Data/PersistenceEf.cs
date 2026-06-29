using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class PersistenceEf : IPersistence
    {
        private readonly Dsw2026Ej15DbContext _context;
        public PersistenceEf(Dsw2026Ej15DbContext context)
        {
            _context = context;
        }

        public async Task ActualizarDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<Doctor?> ObtenerDoctor(Guid id)
        {
            return await _context.Doctors.SingleOrDefaultAsync(x=>x.Id == id&&x.IsActive);
        }

        public async Task<IEnumerable<Doctor?>> ObtenerDoctores()
        {
            return await _context.Doctors.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Speciality?> ObtenerEspecialidadPorId(Guid id)
        {
            return await _context.Specialities.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
