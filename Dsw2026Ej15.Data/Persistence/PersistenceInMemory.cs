using System;
using System.Collections.Generic;
using System.Text.Json;
using Dsw2026Ej15.Domain.Entities;
namespace Dsw2026Ej15.Data.Persistence;
using Dsw2026Ej15.Domain.Interfaces;

internal class PersistenceInMemory: IPersistence
{
    public readonly List<Doctor> _listadoDoctores= new();
    public readonly List<Speciality> _listadoEspecialidades=new();

    public PersistenceInMemory()
    {
        LoadSpecialities();
    }

    private void LoadSpecialities()
    {
        string jsonPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "specialities.json");

        if (!File.Exists(jsonPath)) return;

        string json = File.ReadAllText(jsonPath);
        var especialidades = JsonSerializer.Deserialize<List<Speciality>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (especialidades != null)
            _listadoEspecialidades.AddRange(especialidades);
    }

    public void AgregarDoctor(Doctor doctor)=> _listadoDoctores.Add(doctor);
    public IEnumerable<Doctor> ObtenerDoctores() => _listadoDoctores.Where(x => x.IsActive).ToList();
    public Doctor? ObtenerDoctor(Guid id) => _listadoDoctores.FirstOrDefault(x => x.Id == id && x.IsActive);
    public Speciality? ObtenerEspecialidadPorId(Guid id) => _listadoEspecialidades.FirstOrDefault(x => x.Id == id);
    

    public void ActualizarDoctor(Doctor doctor)
    {
        var index = _listadoDoctores.FindIndex(x => x.Id == doctor.Id);
        if (index >= 0)
            _listadoDoctores[index] = doctor;
    }

   


}
