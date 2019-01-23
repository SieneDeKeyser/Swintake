using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class PhoneScreening: SelectionStep
    {
        public PhoneScreening()
        {
            Description = "Register Phone Screening";
        }

        public override SelectionStep GoToNextState()
        {
            return new TestResult();
        }
    }
}
