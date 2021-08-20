/* Solution 3:
Specifying an optional parameter in function definition,
passing in as its default value the new email address (line 19)

Advantage:
More friendly towards human-error if the developer forgets to pass in the email address in function invocation.
Disadvantage:
Optional parameters have to be passed in as the last parameter upon function definion.
This means that the ordering of the arguments passed into each function invocation will have to reflect
the newly ordered parameters in the definition.
For example, the arguments in the function invocation at lines 54-56 had to be rearranged correspondingly;
otherwise, the script will have thrown a compile-time error
*/

/*
This method is used to send email within the organization
*/

public static void SendEmail(string emailFrom, string subject, string msgBody, string emailTo = "pamanager@buncombecounty.org")
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
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], subject,
    "<p><strong>There are new comments from a https://www.buncombecounty.org/publicassistanceuser.</strong></p>"
    + msgBody);

    //email the user
    subject = "Buncombe County: Public Assistance Question";
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], subject,
    "<p>Your question/comment has been received and we will reply as soon as possible.</p>"
    + msgBody, txtEmail.Text);
}
