using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Generate the console report requested
/// varianbles used to shorten the writeline
/// </summary>
public class ReportGeneration
{
	public void Report(List<Applicant> app)
    { 
        foreach (var applicant in app)
        {
            DateTime dob = DateTime.ParseExact(applicant.BirthDate, "MMddyyyy", CultureInfo.InvariantCulture);
            DateTime pd = DateTime.ParseExact(applicant.PlanDate, "MMddyyyy", CultureInfo.InvariantCulture);
            string fn = applicant.FirstName;
            string ln = applicant.LastName;
            string plan = applicant.PlanType;
            string status = applicant.Status;

            Console.WriteLine(status + ", " + fn + ", " + ln + ", " + dob.ToShortDateString() + ", " + plan + ", " + pd.ToShortDateString());


        }
    }
}
