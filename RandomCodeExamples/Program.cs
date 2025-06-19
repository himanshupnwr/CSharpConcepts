using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RandomCodeExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //validating json schema
            JSchema schema = JSchema.Parse(@"{
            'type':'object,
            'properties': {
                'name':{'type':'string'},
                'roles':{'type':'array'}
                }
            }");

            JObject user = JObject.Parse(@"{'name':'James Bond', 'roles': ['security', 'Administrator']}");
            bool valid = user.IsValid(schema);

            #region JSON Schema Generator
            JSchemaGenerator generator = new JSchemaGenerator();
            schema = generator.Generate(typeof(BankAccount));
            #endregion

            #region USing JSchemaValidatingReader
            schema = JSchema.Parse(@"{'type':'array','item':{'type':'string'}}");
            JsonTextReader reader = new JsonTextReader(new StringReader(@"['Developer','Administrator']"));

            JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader);
            validatingReader.Schema = schema;

            JsonSerializer serializer = new JsonSerializer();
            List<string> roles = serializer.Deserialize<List<string>>(validatingReader);
            #endregion
        }
        static void ValidateRegex()
        {
            string pattern = "(Mr\\.? |Ms\\.? |Mrs\\.? |Miss\\.?";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };

            foreach (string name in names)
            {
                Console.WriteLine(Regex.Replace(name, pattern, string.Empty));
            }

            string pattern2 = @"\b(\w+?)\s\1\b";
            string input = "This this is a nice day. What about this? This tastes good. I saw a a dog";
            foreach (Match match in Regex.Matches(input, pattern2, RegexOptions.IgnoreCase)) { 
                Console.WriteLine("{0} {duplicates '{1}' at position {2}}", match.Value.Length, 
                    match.Groups[1].Value, match.Index);
            }

            string inputString = "My favorite web sites include: </P> + " +
                "<a href=\"http://msdn2.microsoft.com\">" + 
                "msdn home page</a></p>";

            DumpHrefs(inputString);
        }

        private static void DumpHrefs(string inputString)
        {
            Match m;
            string hrefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

            try
            {
                m = Regex.Match(inputString, hrefPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled, 
                    TimeSpan.FromSeconds(1));

                while(m.Success)
                {
                    Console.WriteLine("Found href" + m.Groups[1] + " at " + m.Groups[1].Index);
                    m = m.NextMatch();
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    public class BankAccount
    {
        [EmailAddress]
        [JsonProperty("email", Required = Required.Always)]
        public string UserEmailId { get; set; }
    }
}
