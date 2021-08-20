/* Solution 4 (optimal):
Modifying the AppSettings.json file in the build directory
to include the following key-value pair:
{
    "emailPAM" : "pamanager@buncombecounty.org"
}.
Then, referencing it as ConfigurationManager.AppSettings["emailPAM"] witin function invocation (line 53).

Advantage:
Storing the email addresss in relatively the most intuitive place in the codebase (since noreply is also stored there)
Additionally, the email address can be kept private from users since it will be stored on the server.
Lastly, if the Web Admin needs to update the email address, they will not have to rummage through codebase
and instead simply make the modification on the AppSettings.json file.

Disadvantage:
It might not be ideal to add a bunch of new environment variables if there is a system in place,
which has been designed to only keep certain variables in AppSettings.json.
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
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], ConfigurationManager.AppSetings["emailPAM"],
    subject,"<p><strong>There are new comments from a https://www.buncombecounty.org/publicassistanceuser.</strong></p>"
    + msgBody);

    //email the user
    subject = "Buncombe County: Public Assistance Question";
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], txtEmail.Text, subject,
    "<p>Your question/comment has been received and we will reply as soon as possible.</p>"
    + msgBody);
}
