/* [0]
Here, a public function is defined with the label <SendEmail>.
And it's defined with four parameters: emailFrom, emailTo, subject, and msgBody.
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
    and values derived from the txtName, txtEmail, and txtQuestions objects.
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
    according to the email recipient,
    Then, you can see that the sendemail method is     the <SendEmail> method is invoked with the four arguments that are the specified parameters in comment block [0].
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

/*Introduction
Line-by-line code-analysis (where we can derive a hypothesis on how to solve the problem)
Presentation of solutions
Additional discussion

Introduction

- Getting familiar with the unknown:
    - Learning the fundamentals of C# and the .NET ecosystem
    - Relating newfound knowledge with existing understanding
        - C# is C-like in syntax, it is strongly-typed, and is a compiled language (vs. JavaScript)
        - C# is a multi-paradigm programming language, and often times you see C# code written in Object Oriented design through the naming conventions of namespaces, classes, methods, etc.

Line-by-line code-analysis

-

/*

Should a noreply email be used here?
Often times, noreply email is considered bad practice, and there are mainly two reasons:
1) UX is affected - users have a hard time reaching you (think of accessible design)
2) noreply can be caughted by email providers and flagged as spam

Suggestion:
If the Public Assistance Manager is happy with the idea, it might be best to actually just pass in the
"pamanager@buncombecounty.org" as the corresponding argument to the emailFrom parameter,

Then also specify at the end of the built email msgBody that email replies can be received
and will be directed to Public Assistance Manager.


Source:

https://www.codeproject.com/Questions/1117800/What-does-object-sender-eventargs-e-imply

*/

/*

Should you

*/



Go into more detail as to why the first two hacks are not a good idea (hardcoding email addresses) -
Talk less about the line-by-line analysis
How this code snippet exists within a class (e.g. component which allows you to send email),
what is the responsibility of the class,
Talking about the higher-level concepts (i.e. strongly typed)
Show how you think about code abstractly

Talking a bit about C#
Comparison to existing knowledge

Go into more detail into why you don't want to hardcode email (esp. if they're subject to change)

Conventions within the language (the object sender, EventArgs)

Maybe the admin of the app can directly update the app setting




//

What the bug could be

Can you validate your theory
As I was looking at the network tab,
I'd need to actually die into the code in the server to
If there is not an active error

How would you test this to solve it:
Now just diagnosing the problem (i.e. coming u pwith hypothesis)


Do you have any testing environment? Look up ASP.NET tests
