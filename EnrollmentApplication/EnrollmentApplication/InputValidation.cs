using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// After Parse, check inputted information to ensure all information was parsed successfully
/// </summary>
public class InputValidation : AValidator

{
    public override void Validation(List<Applicant> app)
    {
        DateTime dt;
        CultureInfo enUS = new CultureInfo("en-US");
        foreach (var applicant in app)
        {
            if (applicant !=null)
            { //&& applicant.FirstName != null && applicant.LastName != null && applicant.BirthDate != null && applicant.PlanType != null && applicant.PlanDate != null

                if (DateTime.TryParseExact(applicant.BirthDate, "MMddyyyy", enUS, DateTimeStyles.None, out dt))
                {

                    if (applicant.PlanType == "HSA" || applicant.PlanType == "HRA" || applicant.PlanType == "FSA")
                    {
                        if (DateTime.TryParseExact(applicant.PlanDate, "MMddyyyy", enUS, DateTimeStyles.None, out dt))
                        {

                            //END - IF good do nothing
                        }
                        else
                        {
                            InvalidMessage();
                            break;
                        }
                    }
                    else
                    {
                        InvalidMessage();
                        break;
                    }
                }
                else
                {
                    InvalidMessage();
                    break;
                }

            }
            else
            {
                InvalidMessage();
                break;
            }
        }
    }

    private void InvalidMessage()
    {
        Console.WriteLine("A record in the file failed validation. Processing has stopped");
        Console.WriteLine("The Program will now exit after keypress");
        Console.ReadKey();
        System.Environment.Exit(1);
    }
}
