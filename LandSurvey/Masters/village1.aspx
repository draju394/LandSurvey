<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="village1.aspx.cs" Inherits="LandSurvey.Masters.village1" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script type="text/javascript">
        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });
 
        function onLoad() {
            var options = {
                sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                [google.elements.transliteration.LanguageCode.MARATHI],
                shortcutKey: 'ctrl+e',
                transliterationEnabled: true
            };
 
            // Create an instance on TransliterationControl with the required
            // options.
            var control =
            new google.elements.transliteration.TransliterationControl(options);
 
            // Enable transliteration in the textbox with id
            // 'transliterateTextarea'.
            control.makeTransliteratable(['transliterateTextarea']);
 
 
        }
        google.setOnLoadCallback(onLoad);
    </script>
</head>
<body>
    <span>English to Marathi</span><br>
    <form runat="server">
    <div>
        <asp:TextBox ID="transliterateTextarea" runat="server" TextMode="MultiLine" Rows="5"
            Columns="50" />
    </div>
    </form>
</body>
</html>
