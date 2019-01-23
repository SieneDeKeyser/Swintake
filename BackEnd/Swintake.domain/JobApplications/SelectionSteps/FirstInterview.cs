using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class FirstInterview: SelectionStep
    {
        public FirstInterview()
        {
            Description = "Register First interview";
        }

        public override SelectionStep GoToNextState()
        {
            return new GroupInterview();
        }
    }
}
