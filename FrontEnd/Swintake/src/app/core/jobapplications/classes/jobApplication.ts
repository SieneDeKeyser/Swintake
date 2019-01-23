import { SelectionStep } from "./selectionStep";
import { Candidate } from "../../candidates/classes/candidate";
import { Campaign } from "../../campaigns/classes/campaign";

export class JobApplication{
    id?: string;
    candidateId: string;
    campaignId: string;
    status?: string;
    currentSelectionStep?: SelectionStep;
    selectionSteps?: SelectionStep[];
    candidate: Candidate;
    campaign: Campaign;
}