using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManteHos.Entities
{
    public enum Priority : int
    {
        High,
        Medium,
        Low,
    }
}