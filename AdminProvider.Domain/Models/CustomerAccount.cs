namespace AdminProvider.Domain.Models;

public class CustomerAccount : Account
{ //Ärver Account men modifierar Account klassen här.
    //Customer account skall även ha Adress.

    public string Address { get; set; } = null!;
}