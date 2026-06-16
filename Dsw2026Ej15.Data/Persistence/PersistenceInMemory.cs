using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain.Entities;
namespace Dsw2026Ej15.Data.Persistence
{
    internal class PersistenceInMemory
    {
        public List<Doctor> _listadoDoctores;
        public List<Speciality> _listadoEspecialidades;

        public PersistenceInMemory()
        {
            _listadoDoctores = new List<Doctor>();
            _listadoEspecialidades = new List<Speciality>();
        }

        private void LoadSpecialities()
        {

        }

        public void AgregarDoctor(Doctor doctor)
        {
            _listadoDoctores.Add(doctor);
        }

        public IEnumerable<Doctor> ObtenerDoctores()
        {
            return _listadoDoctores.Where(x => x.IsActive).ToList();
        }

        public Speciality? ObtenerEspecialidadPorId(Guid id)
        {
            return _listadoEspecialidades.FirstOrDefault(x => x.Id == id);
        }

        public void ActualizarDoctor(Doctor doctor)
        {
            var index = _listadoDoctores.FindIndex(x => x.Id == doctor.Id);
            if (index >= 0)
                _listadoDoctores[index] = doctor;
        }

        public Doctor? ObtenerDoctor(Guid id)
        {
            return _listadoDoctores.FirstOrDefault(x => x.Id == id && x.IsActive);
        }


    }
}
