using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace EnrollmentApplication
{
    class Enrollment
    {
        static void Main(string[] args)
        {
            //start validators
            InputValidation IV = new InputValidation();
            RuleValidation RV = new RuleValidation();
            ReportGeneration RG = new ReportGeneration();

            CsvParserOptions csvParserOptions = new CsvParserOptions(false, ',');
            CsvApplicantMapping csvMapper = new CsvApplicantMapping();
            CsvParser<Applicant> csvParser = new CsvParser<Applicant>(csvParserOptions, csvMapper);

            //\EnrollmentApplication\EnrollmentApplication\bin\Debug\netcoreapp2.0\TestFile.csv

            var parseList = csvParser
                .ReadFromFile("TestFile.csv", Encoding.UTF8)
                .ToList();

            List<Applicant> transform = parseList.Select(i => i.Result).ToList();

            IV.Validation(transform);
            RV.Validation(transform);
            RG.Report(transform);

            Console.WriteLine("The program has finished - Press any key to exit");
            Console.ReadKey();
        }
    }
}
