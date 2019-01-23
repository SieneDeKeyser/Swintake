using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class GroupInterview: SelectionStep
    {
        public GroupInterview()
        {
            Description = "Register Group interview";
        }

        public override SelectionStep GoToNextState()
        {
            return new FinalDecision();
        }
    }
}
