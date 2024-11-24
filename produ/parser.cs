using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace produ
{
    // Классы для хранения данных
    public class Fact
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Rule
    {
        public List<string> Conditions { get; set; } = new List<string>();
        public string Result { get; set; }
    }

    public class FinalRule
    {
        public List<string> Conditions { get; set; } = new List<string>();
        public string Result { get; set; }
    }

    public class Parser
    {
        public List<string> facts = new List<string>();
        public List<Rule> rules = new List<Rule>();
        public List<FinalRule> finalRules = new List<FinalRule>();
        public int firstFacts = 0;
        public List<string> finalFacts = new List<string>();

        public  void Parse(string filePath)
        {

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
                    continue;

                if (trimmedLine.StartsWith("fa-"))
                {
                    var fact = ParseFact(trimmedLine);
                    if (fact != null)
                        facts.Add(fact);
                    firstFacts++;
                }
                else if (trimmedLine.StartsWith("fr-"))
                {
                    var rule = ParseRule(trimmedLine);
                    if (rule != null)
                        rules.Add(rule);
                    facts.Add(rule.Result);
                }
                else if (trimmedLine.StartsWith("fn-"))
                {
                    var finalRule = ParseFinalRule(trimmedLine);
                    if (finalRule != null)
                        finalRules.Add(finalRule);
                    facts.Add(finalRule.Result);
                    if (!finalFacts.Contains(finalRule.Result))
                    {
                        finalFacts.Add(finalRule.Result);
                    }
                }
            }
            /*
            // Создаём словарь для сопоставления идентификаторов фактов и их описаний
            var factDescriptions = new Dictionary<string, string>();
            foreach (var fact in facts)
            {
                factDescriptions[fact.Code] = fact.Description;
            }
            */
        }

        private static string ParseFact(string line)
        {
            var parts = line.Split(new []{ ": "}, System.StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return null;
            /*
            return new Fact
            {
                Code = parts[0].Trim(),
                Description = parts[1].Trim()
            };*/
            return parts[1].Trim();
        }

        private static Rule ParseRule(string line)
        {
            var parts = line.Split(new[] { ": " }, System.StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return null;

            line = parts[1].Trim();

            parts = line.Split(new[] { " => " }, System.StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return null;

            var conditions = parts[0].Split(new[] { ", " }, System.StringSplitOptions.RemoveEmptyEntries);
            var result = parts[1].Trim();

            return new Rule
            {
                Conditions = new List<string>(conditions),
                Result = result
            };
        }

        private static FinalRule ParseFinalRule(string line)
        {
            var parts = line.Split(new[] { ": " }, System.StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return null;

            line = parts[1].Trim();

            parts = line.Split(new[] { " => " }, System.StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return null;

            var conditions = parts[0].Split(new[] { ", " }, System.StringSplitOptions.RemoveEmptyEntries);
            var result = parts[1].Trim();

            

            return new FinalRule
            {
                Conditions = new List<string>(conditions),
                Result = result
            };
        }

        private static List<string> TranslateConditions(List<string> conditions, Dictionary<string, string> factDescriptions)
        {
            var descriptions = new List<string>();
            foreach (var condition in conditions)
            {
                descriptions.Add(TranslateFact(condition, factDescriptions));
            }
            return descriptions;
        }

        private static string TranslateFact(string code, Dictionary<string, string> factDescriptions)
        {
            return factDescriptions.TryGetValue(code, out var description) ? description : code;
        }
    }

}
