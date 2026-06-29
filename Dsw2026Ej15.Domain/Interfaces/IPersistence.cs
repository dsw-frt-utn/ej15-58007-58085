using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public  interface IPersistence
    {
        Task AgregarDoctor(Doctor doctor);
        Task<IEnumerable<Doctor?>> ObtenerDoctores();
        Task<Doctor?> ObtenerDoctor(Guid id);
        Task ActualizarDoctor(Doctor doctor);
        Task<Speciality?> ObtenerEspecialidadPorId(Guid id);

        /*void AgregarDoctor(Doctor doctor);
        IEnumerable<Doctor> ObtenerDoctores();
        Doctor? ObtenerDoctor(Guid id);
        void ActualizarDoctor(Doctor doctor);
        Speciality? ObtenerEspecialidadPorId(Guid id);*/
    }
}
