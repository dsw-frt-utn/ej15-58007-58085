using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Doctor:BaseEntity
    {
        public String Name { get; set; }
        public String LicenseNumber { get; init; }
        public bool IsActive { get; set; }
        public Guid? SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }

        public void DesactivarMedico()
        {
            IsActive = false;
        }

    }
}
