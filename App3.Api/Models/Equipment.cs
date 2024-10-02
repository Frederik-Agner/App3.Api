namespace App3.Api.Models;

public class Equipment {
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime RetireDate { get; set; } = DateTime.Today.AddYears(4);
}
