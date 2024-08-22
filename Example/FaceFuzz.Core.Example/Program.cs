using FaceFuzz.Core;

string template = "Hello {{NAME}}.\r\n  Here is some more information: {{INFO}}\r\n";
var parser = new Fuzz();
var properties = new Dictionary<string, string>
        {
            { "NAME", "world" },
            { "INFO", "ipsum lorem ad valor sit" }
        };
var outputString = parser.Render(template, properties);
Console.Write(outputString);
