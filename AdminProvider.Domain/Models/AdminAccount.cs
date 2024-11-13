namespace AdminProvider.Domain.Models;

public class AdminAccount : Account
{ //Ärver Account men modifierad Account klass här, för just Admin account skall ha ISAdmin true/false så att kontot särskiljs från kundkonto.
    public bool IsAdmin { get; set; }
}
