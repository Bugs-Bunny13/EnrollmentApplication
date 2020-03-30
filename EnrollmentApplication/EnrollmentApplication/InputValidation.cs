using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

/// <summary>
/// After Parse, check inputted information to ensure all information was parsed successfully
/// </summary>
public class InputValidation : AValidator

{
    //A list of supported plan types
    private readonly List<string> ValidPlantypes = new List<string> { "HSA", "HRA", "FSA" };

    public override void Validation(List<Applicant> app)
    {
        bool valid = true;
        
        //dt is only used as an exit for TryParseExact
        DateTime dt;
        CultureInfo enUS = new CultureInfo("en-US");

        foreach (var applicant in app)
        {
            if (applicant == null)
            {
                valid = false;
            }
            if (!DateTime.TryParseExact(applicant.BirthDate, "MMddyyyy", enUS, DateTimeStyles.None, out dt))
            {
                valid = false;
            }
            if (!ValidPlantypes.Contains(applicant.PlanType))
            {
                valid = false;
            }
            if (!DateTime.TryParseExact(applicant.PlanDate, "MMddyyyy", enUS, DateTimeStyles.None, out dt))
            {
                valid = false;
            }

            //run status check of bool
            InvalidCheck(valid);


        }
    }

    private void InvalidCheck(bool valid)
    {
        //if valid = false, exit
        if (valid == false)
        {
            Console.WriteLine("A record in the file failed validation. Processing has stopped.");
            Console.WriteLine("The Program will now exit after keypress");
            Console.ReadKey();
            System.Environment.Exit(1);
        }
    }
}
