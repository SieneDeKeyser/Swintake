using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class TestResult: SelectionStep
    {
        public TestResult()
        {
            Description = "Register TestResults";
        }
        public override SelectionStep GoToNextState()
        {
            return new FirstInterview();
        }
    }
}
