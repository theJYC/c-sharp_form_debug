/* solution 2:
initialising constant variable to store the hardcoded email address (line 23)
then passing in the reference to the variable into function invocation (line 40)
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
    string PUBLIC_ASSISTANT_MANAGER_EMAIL = "pamanager@buncombecounty.org"

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
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], PUBLIC_ASSISTANT_MANAGER_EMAIL, subject,
    "<p><strong>There are new comments from a https://www.buncombecounty.org/publicassistanceuser.</strong></p>"
    + msgBody);

    //email the user
    subject = "Buncombe County: Public Assistance Question";
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], txtEmail.Text, subject,
    "<p>Your question/comment has been received and we will reply as soon as possible.</p>"
    + msgBody);
}
