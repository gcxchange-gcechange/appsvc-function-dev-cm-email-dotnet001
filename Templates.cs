using CareerMarketplace;

namespace appsvc_function_dev_cm_email_dotnet001
{
    internal class Templates
    {
        public static SubjectAndBody CreateOpportunity (JobOpportunity jobOpportunity)
        {
            return new SubjectAndBody(
                "Job Opportunity Created",
                @$"
                Hello {jobOpportunity.ContactName},<br><br>
                Your job opportunity has been successfully created!<br>
                {jobOpportunity.ToHTML()}
                All the best,<br>
                The GCX Team
                "
            );
        }

        public static SubjectAndBody DeleteOpportunity (JobOpportunity jobOpportunity)
        {
            return new SubjectAndBody(
                "Job Opportunity Deleted",
                @$"
                Hello {jobOpportunity.ContactName},<br><br>
                Your job opportunity has been deleted...<br>
                {jobOpportunity.ToHTML()}
                Wishing you the best,<br>
                The GCX Team
                "
            );
        }
    }

    public class SubjectAndBody
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public SubjectAndBody(string subject, string body) 
        {
            Subject = subject;
            Body = body;
        }
    }
}
