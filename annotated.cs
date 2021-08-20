/* [0]
Here, in line 7, a method is defined with the label <SendEmail>.
And it's defined with four parameters: emailFrom, emailTo, subject, and msgBody.
All of the parameters are of the string data type.
*/

public static void SendEmail(string emailFrom, string emailTo, string subject, string msgBody) {
    //... some_code_here ...
}

/* [1]
Here, in line 17, the <btnSubmit_Click> method is defined and is to be only accessible within its parent scope.
With the specified (object sender, EventArgs e) parameters, this method is an event handler.
As its semantic label suggests, this method will fire upon the click of the form submit button.
N.B. The parent scope is likely a class that holds methods and data that is related to <btnSubmit_Click>)
*/

protected void btnSubmit_Click(object sender, EventArgs e) {
    //in lines 16-17 initialising msgBody and subject as empty string variables (to be populated below)
    string msgBody = string.Empty;
    string subject = string.Empty;

    /* [2]
    the msgBody variable is populated through a series of string concatenation, with manually typed HTML elements
    and values derived with referenced key of Text for each of the txtName, txtEmail, and txtQuestions objects.
    N.B. email templates are typically written in HTML.
    */

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

    /* [3]
    With the email <msgBody> built above, the below code conditionally assigns the subject variable
    according to the email recipient.
    For each recipient, the SendEmail method defined in [0] is invoked with specified parameters.
    */

    //email Public Assistance Manager
    subject = "Web Contact: Public Assistance Question";

    /* [4]
    In this case, the email being sent is directed to the Public Assistance Manager.
    Matching up the passed-in arguments to the defined parameters, though:

    emailFrom = ConfigurationManager.AppSettings["emailNoReply"] (i.e. a noreply address)
    emailTo =
    subject = "Web Contact: Public Assistance Question"
    msgBody = (built in [2])

    It becomes evident that the argument that corresponds to the emailTo parameter is missing.
    This is the site of the problem; the function, as it is currently written, will not run successfully.
    */

    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], subject,
    "<p><strong>There are new comments from a https://www.buncombecounty.org/publicassistanceuser.</strong></p>"
    + msgBody);

    //email the user
    subject = "Buncombe County: Public Assistance Question";

    /* [5]
    In this case, the email is sent to the user submitting the form.
    Matching up the passed-in arguments to the defined parameters:

    emailFrom = ConfigurationManager.AppSettings["emailNoReply"]
    emailTo = txtEmail.Text
    subject = "Buncombe County: Public Assistance Question
    msgBody = (built in [2])

    In this execution context, this method will run successfully and send out a system-generated email
    from the defined noreply address to the user (in their inputted email address),
    containing within the email the content of their inquiry submitted in the form.
    */
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], txtEmail.Text, subject,
    "<p>Your question/comment has been received and we will reply as soon as possible.</p>"
    + msgBody);
}
