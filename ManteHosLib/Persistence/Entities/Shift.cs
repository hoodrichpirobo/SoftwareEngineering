using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManteHos.Entities
{
    public enum Shift : int
    {
        Morning,
        Afternoon,
        Night,
    }
}