using System;

namespace Swintake.api.Helpers.JobApplications.Selection
{
    public class SelectionStepDto
    {
        public Guid JobApplicationId { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
    }
}
