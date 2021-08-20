/* Bonus Suggestion:
With solution 4 implemented (i.e. emailPAM stored into AppSettings.json),
remove the noreply email.

noreply emails are bad practice for a couple of reasons:
1) they make it harder for the end-user to follow-up with the webmaster,
since they are not otherwise given a direct channel to submit their concerns to.
i.e. this can hinder the UX and accessibility of website to its target demographic.

2) noreply emails are sometimes filtered by email providers and flagged as spammail.
i.e. this system-generated email may not therefore even reach the desired users.

With that said,
my suggestion is to replace the noreply email with a designated Point of Contact (e.g. pamanager@buncombecounty.org).
modifying the emailFrom argument in function invocation on line 60.
Then, concatenate in msgBody an additional text
indicating that users can explicitly reply to this email address for further inquiries (line 50)
*/

/*
This method is used to send email within the organization
*/

public static void SendEmail(string emailFrom, string emailTo, string subject, string msgBody)
{
    //... some_code_here ...
}

/*
Modify the below method to send the County Public Assistant Manager a copy to her new email address (pamanager@buncombecounty.org)
*/

protected void btnSubmit_Click(object sender, EventArgs e)
{
    string msgBody = string.Empty;
    string subject = string.Empty;

    //build the email
    msgBody = "<h1>Contact Public Assistance</h1><p>This email was received from a user of the Buncombe County Website.</p>"
    + "<d1>"
        + "<dt>Name:</dt>"
        + "<dd>" + txtName.Text + "</dd>"

        + "<dt>Email:</dt>"
        + "<dd>" + txtEmail.Text + "</dd>"

        + "<dt>Questions  / Comments:</dt>"
        + "<dd>" + txtQuestions.Text.Replace(Environment.NewLine, "<br />") + "</dd>"
    + "</d1>"
    + "<p>Please reply to this email directly should you have further inquiries</p>";

    //email Public Assistance Manager
    subject = "Web Contact: Public Assistance Question";
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], ConfigurationManager.AppSettings["emailPAM"], subject,
    "<p><strong>There are new comments from a https://www.buncombecounty.org/publicassistanceuser.</strong></p>"
    + msgBody);

    //email the user
    subject = "Buncombe County: Public Assistance Question";
    SendEmail(ConfigurationManager.AppSettings["emailPAM"], ConfigurationManager.AppSettings["emailPAM"], subject,
    "<p>Your question/comment has been received and we will reply as soon as possible.</p>"
    + msgBody);
}
