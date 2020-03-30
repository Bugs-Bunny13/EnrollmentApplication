using System;
using TinyCsvParser;
using TinyCsvParser.Mapping;

/// <summary>
/// Mapper 
/// </summary>
public class CsvApplicantMapping : CsvMapping<Applicant>
{
    public CsvApplicantMapping() : base()
	{
		MapProperty(0, x => x.FirstName);
        MapProperty(1, x => x.LastName);
        MapProperty(2, x => x.BirthDate);
        MapProperty(3, x => x.PlanType);
        MapProperty(4, x => x.PlanDate);

    }


}
