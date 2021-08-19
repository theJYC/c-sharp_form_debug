/* [0]
Here, a public function with the label <SendEmail> is defined, with no expected return value.
The function is defined with four parameters: emailFrom, emailTo, subject, and msgBody.
All of the parameters are of the string data type.
*/

public static void SendEmail(string emailFrom, string emailTo, string subject, string msgBody) {
    //... some_code_here ...
}

/* [1]
Here, <btnSubmit_Click> method is defined and is to be only accessible within its parent scope.
With the specified (object sender, EventArgs e) parameters, this method is an event handler.
As its semantic label suggests, this method will fire upon the click of the form submit button.

Important to note here are the two parameters:

1) <sender> is the object that has been raised(i.e. the HTML element that the user interacted with), and
2) <e> contains the the data associated with the user's form submission.
*/

protected void btnSubmit_Click(object sender, EventArgs e) {
    //initialising msgBody and subject as empty string variables (to be populated below)
    string msgBody = string.Empty;
    string subject = string.Empty;

    /* [2]
    the msgBody variable is populated through a series of string concatenation, with manually typed HTML elements
    and with the values derived from the txtName, txtEmail, and txtQuestions objects.
    Specifically, each of the three objects has a <Text> attribute which is referenced for the building of the email.
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
    With the email <msgBody> built above, the below code conditionally assigns the subject variable according to the recipient,
    Then, the <SendEmail> method is invoked with the four arguments that are the specified parameters in comment block [0].
    */

    //email Public Assistance Manager
    subject = "Web Contact: Public Assistance Question";

    /* [4]
    In this case, the email being sent is directed to the Public Assistance Manager.
    Matching up the passed-in arguments to the defined parameters though:

    emailFrom = ConfigurationManager.AppSettings["emailNoReply"]
    emailTo =
    subject = "Web Contact: Public Assistance Question"
    msgBody = (built in [2])

    It becomes evident that the argument that corresponds to the emailTo parameter is missing.
    */
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], subject,
    "<p><strong>There are new comments from a https://www.buncombecounty.org/publicassistanceuser.</strong></p>"
    + msgBody);

    //email the user
    subject = "Buncombe County: Public Assistance Question";

    /* [5]
    In this case, the email is sent to the user submitting the form.
    Matching up the passed-in arguments to the defined parameters:

    emailFrom = ConfigurationManager.AppSettings["emailNoReply"] (i.e. a noreply address (see *1))
    emailTo = txtEmail.Text
    subject = "Buncombe County: Public Assistance Question
    msgBody = (built in [2])
    */
    SendEmail(ConfigurationManager.AppSettings["emailNoReply"], txtEmail.Text, subject,
    "<p>Your question/comment has been received and we will reply as soon as possible.</p>"
    + msgBody);
}



/*

Should a noreply email be used here?
More and more companies are saying that noreply emails are bad practice--
If the Public Assistance Manager is happy with the idea, it might be best to actually just pass in the
"pamanager@buncombecounty.org" as the corresponding argument to the emailFrom parameter,
and also specify at the end of the built email msgBody that email replies can be received
and will be directed to Public Assistance Manager.


Source:

https://www.codeproject.com/Questions/1117800/What-does-object-sender-eventargs-e-imply

*/

/*

Should you

*/
