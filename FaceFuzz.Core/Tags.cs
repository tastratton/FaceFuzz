namespace FaceFuzz.Core;
public class Tags
{
    public string StartTag { get; private set; }
    public string EndTag { get; private set; }
    public Tags()
    {
        // default tags
        StartTag = "{{";
        EndTag = "}}";
    }

    public Tags(string startTag, string endTag)
    {
       throw new NotImplementedException();
        // todo: needs validation for rules such as: start and end tags cant be same thing, can't be empty, tags are n characters, and other rules
       //StartTag = startTag;
       //EndTag = endTag;

    }
}
