using System;
using Domain.Primitives;

namespace Domain.Entities;

public sealed class Webinar : Entity
{
    public Webinar(Guid id, string name, DateTime scheduleOn)
        : base(id)
    {
        Name = name;
        ScheduleOn = scheduleOn;
    }

    private Webinar()
    {
    }

    public string Name { get; private set; }
    public DateTime ScheduleOn { get; private set; } 
}