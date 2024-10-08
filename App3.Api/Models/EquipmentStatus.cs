﻿namespace App3.Api.Models;

public class EquipmentStatus {
    public long Id { get; set; } // Primary Key
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime? Closed { get; set; } = null;
    public long EquipmentId { get; set; } // Foreign Key
    public long UserId { get; set; } // Foreign Key
}

public enum StatusEnum {
    Returned,
    Out,
    Available,
    Unavailable
}
