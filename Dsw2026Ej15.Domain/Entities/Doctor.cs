using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Doctor:BaseEntity
    {
        public String Name { get; set; }
        public String LicenseNumber { get; init; }
        public bool IsActive { get; set; }
        public Speciality Speciality { get; set; }


    }
}
