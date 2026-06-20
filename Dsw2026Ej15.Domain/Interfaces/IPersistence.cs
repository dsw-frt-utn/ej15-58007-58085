using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public  interface IPersistence
    {
        void AgregarDoctor(Doctor doctor);
        IEnumerable<Doctor> ObtenerDoctores();
        Doctor? ObtenerDoctor(Guid id);
        void ActualizarDoctor(Doctor doctor);
        Speciality? ObtenerEspecialidadPorId(Guid id);
    }
}
