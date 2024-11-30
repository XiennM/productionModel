using System;
using System.Collections.Generic;
using System.Linq;

namespace produ
{
    public class ProductionModel
    {
        public Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> reverseGraph = new Dictionary<string, List<string>>();
        private HashSet<string> knownFacts = new HashSet<string>();
        private List<Rule> rules;
        private List<FinalRule> finalRules;

        public ProductionModel(Parser parser)
        {
            this.rules = parser.rules;
            this.finalRules = parser.finalRules;

            // Инициализация графов
            BuildGraph(parser.rules, parser.finalRules);

            // Добавляем начальные факты в известные
            foreach (var fact in parser.initialFacts)
            {
                knownFacts.Add(fact);
            }
        }

        private void BuildGraph(List<Rule> rules, List<FinalRule> finalRules)
        {
            foreach (var rule in rules)
            {
                foreach (var condition in rule.Conditions)
                {
                    if (!graph.ContainsKey(condition))
                        graph[condition] = new List<string>();
                    graph[condition].Add(rule.Result);

                    if (!reverseGraph.ContainsKey(rule.Result))
                        reverseGraph[rule.Result] = new List<string>();
                    reverseGraph[rule.Result].Add(condition);
                }
            }

            foreach (var finalRule in finalRules)
            {
                foreach (var condition in finalRule.Conditions)
                {
                    if (!graph.ContainsKey(condition))
                        graph[condition] = new List<string>();
                    graph[condition].Add(finalRule.Result);

                    if (!reverseGraph.ContainsKey(finalRule.Result))
                        reverseGraph[finalRule.Result] = new List<string>();
                    reverseGraph[finalRule.Result].Add(condition);
                }
            }
        }

        public List<string> ComputeFinalFacts(List<string> initialFacts)
        {
            // Инициализация начальных фактов
            knownFacts = new HashSet<string>(initialFacts);

            var queue = new Queue<string>(knownFacts);
            var finalResults = new HashSet<string>();

            while (queue.Count > 0)
            {
                var currentFact = queue.Dequeue();

                if (!graph.ContainsKey(currentFact))
                    continue;

                foreach (var result in graph[currentFact])
                {
                    // Проверяем, выполняются ли все условия для вывода результата
                    if (reverseGraph[result].All(condition => knownFacts.Contains(condition)))
                    {
                        if (!knownFacts.Contains(result))
                        {
                            knownFacts.Add(result);
                            queue.Enqueue(result);

                            // Если это финальный факт, добавляем его в список финальных
                            if (finalRules.Any(fr => fr.Result == result))
                            {
                                finalResults.Add(result);
                            }
                        }
                    }
                }
            }

            return finalResults.ToList();
        }

        public List<string> ComputeRequiredFacts(string finalFact)
        {
            var requiredFacts = new HashSet<string>();
            var queue = new Queue<string>();
            queue.Enqueue(finalFact);

            while (queue.Count > 0)
            {
                var currentFact = queue.Dequeue();

                if (!reverseGraph.ContainsKey(currentFact))
                    continue;

                foreach (var condition in reverseGraph[currentFact])
                {
                    if (!requiredFacts.Contains(condition))
                    {
                        requiredFacts.Add(condition);
                        queue.Enqueue(condition);
                    }
                }
            }

            return requiredFacts.ToList();
        }
    }
}