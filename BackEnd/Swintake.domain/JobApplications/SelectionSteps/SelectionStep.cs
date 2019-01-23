using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public abstract class SelectionStep
    {
        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; }
        public static int CountofStepsInSelectionProcess = 6;

        [MaxLength(90)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }

        public abstract SelectionStep GoToNextState();
    }
}
