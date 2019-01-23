using Swintake.domain.JobApplications.SelectionSteps;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Swintake.domain.tests.SelectionSteps
{
   public class SelectionStepTests
    {
        [Fact]
        public void GivenCVScreening_whenGoToNextState_ThenReturnNewPhoneScreening()
        {
            //Given
            var selectionstep = new CvScreening();

            //When
            var nextSelectionStep = selectionstep.GoToNextState();

            //Then
            Assert.IsType<PhoneScreening>(nextSelectionStep);
        }

        [Fact]
        public void GivenPhoneScreening_whenGoToNextState_ThenReturnNewTestResults()
        {
            //Given
            var selectionstep = new PhoneScreening();

            //When
            var nextSelectionStep = selectionstep.GoToNextState();

            //Then
            Assert.IsType<TestResult>(nextSelectionStep);
        }

        [Fact]
        public void GivenTestResult_whenGoToNextState_ThenReturnNewFirstInterview()
        {
            //Given
            var selectionstep = new TestResult();

            //When
            var nextSelectionStep = selectionstep.GoToNextState();

            //Then
            Assert.IsType<FirstInterview>(nextSelectionStep);
        }

        [Fact]
        public void GivenFirstInterview_whenGoToNextState_ThenReturnNewGroupInterview()
        {
            //Given
            var selectionstep = new FirstInterview();

            //When
            var nextSelectionStep = selectionstep.GoToNextState();

            //Then
            Assert.IsType<GroupInterview>(nextSelectionStep);
        }

        [Fact]
        public void GivenGroupInterview_whenGoToNextState_ThenReturnNewFinalDecision()
        {
            //Given
            var selectionstep = new GroupInterview();

            //When
            var nextSelectionStep = selectionstep.GoToNextState();

            //Then
            Assert.IsType<FinalDecision>(nextSelectionStep);
        }

        [Fact]
        public void GivenFinalDecision_whenGoToNextState_ThenReturnSameProcess()
        {
            //Given
            var selectionstep = new FinalDecision();

            //When
            var nextSelectionStep = selectionstep.GoToNextState();

            //Then
            Assert.IsType<FinalDecision>(nextSelectionStep);
        }

    }
}
