 using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManteHos.Entities
{
    public enum Status : int
    {
        Created,
        Accepted,
        Rejected,
        InProgress,
        Pending,
        Completed,
    }
}