using System;

/// <summary>
/// Lays the foundation for the Applicant object
/// 
/// </summary>
public class Applicant
{
    private const string P = "Pending";


    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string BirthDate { get; set; } = null;
    public string PlanType { get; set; } = null;
    public string PlanDate { get; set; } = null;
    public string Status{ get; set; } = P;
    
}
