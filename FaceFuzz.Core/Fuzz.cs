using System.Text.RegularExpressions;

namespace FaceFuzz.Core;
public class Fuzz
{

    private Regex _tokenRegex = new Regex(
        @"\{\{(?<tokenName>[^\}]*?)\}\}",
        RegexOptions.Singleline);

    /** <summary>
     * Render the transformed output using the template and data map
     * </summary>
     * <param name="template">The template</param>
     * *<param name="datamap">The data</param>
    */
    public string Render(string template, IDictionary<string, string> datamap)
    {
        var result = template;
        //Regular Expression Replacements
        MatchCollection matches =
            _tokenRegex.Matches(template);
        //Iterate through all the matches
        for (int i = matches.Count - 1; i >= 0; i--)
        {
            //Pull token name from the group
            string tokenName = matches[i].Groups["tokenName"].Value;
            string replacementValue = string.Empty;
            foreach (KeyValuePair<string, string> entry in datamap)
            {
                if (tokenName == entry.Key)
                {
                    replacementValue = entry.Value;
                }
            }
            result = result.Remove(matches[i].Index, matches[i].Length);
            result = result.Insert(matches[i].Index, replacementValue);
        }

        // todo: replace any remaining tokens that were not matched with string.empty
        return result;
    }
}
