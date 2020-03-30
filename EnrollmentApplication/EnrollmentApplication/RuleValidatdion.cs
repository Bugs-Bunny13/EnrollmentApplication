using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Valdiate according to date rules
/// </summary>
public class RuleValidation : AValidator
{
    public override void Validation(List<Applicant> app)
    {
        int today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        foreach (var applicant in app)
        {
           
            
            int dob= int.Parse(applicant.BirthDate);

            if ((today-dob) / 10000 >= 18)
            {
                try
                {
                    if ((DateTime.ParseExact(applicant.PlanDate, "MMddyyyy", CultureInfo.InvariantCulture) - DateTime.Now).TotalDays < 30)
                    {
                        applicant.Status = "Approved";
                    }
                    else
                    {
                        applicant.Status = "Rejected";
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("failed to parse datetime in rule validator");
                }

            }
            else
            {
                applicant.Status = "Rejected";
            }


        }
    }
}
