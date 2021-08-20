/* Solution 1:
Passing in hardcoded email address as the second argument passed into function invocation (line 44)

Advantage:
Quick and easy "hack"
Disadvantage:
Hardcoding an email address is generally bad practice, since the email is subject to modification,
and, when it does need to be modified, will have to be manually changed in each place of the codebase where it is referenced.
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
    + "</d1>";

    //email Public Assistance Manager
    subject = "Web Contact: Public Assistance Question";
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], "pamanager@buncombecounty.org", subject,
    "<p><strong>There are new comments from a https://www.buncombecounty.org/publicassistanceuser.</strong></p>"
    + msgBody);

    //email the user
    subject = "Buncombe County: Public Assistance Question";
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], txtEmail.Text, subject,
    "<p>Your question/comment has been received and we will reply as soon as possible.</p>"
    + msgBody);
}
