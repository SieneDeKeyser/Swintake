using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class FinalDecision: SelectionStep
    {
        public FinalDecision()
        {
            Description = "Register Final decision";
        }

        public override SelectionStep GoToNextState()
        {
            return this;
        }
    }
}
