using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class CvScreening: SelectionStep
    {
        public CvScreening()
        {
            Description = "Register CV Screening";
        }

        public override SelectionStep GoToNextState()
        {
            return new PhoneScreening();         
        }
    }
}
