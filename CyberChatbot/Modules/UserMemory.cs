using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberChatbot.Modules
{
    public class UserMemory
    {
        private HashSet<string> discussedTopics = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private List<string> pastQuestions = new List<string>();

        public void RememberTopic(string topic)
        {
            discussedTopics.Add(topic);
        }

        public bool HasDiscussed(string topic)
        {
            return discussedTopics.Contains(topic);
        }

        public void AddPastQuestion(string question)
        {
            pastQuestions.Add(question);
        }

        public IEnumerable<string> GetPastQuestions()
        {
            return pastQuestions;
        }

        public void ShowMemorySummary(string userName)
        {
            Console.WriteLine($"\nCyberlock: Here's a quick summary of what we've discussed so far, {userName}:");

            if (discussedTopics.Count == 0)
            {
                Console.WriteLine("- We haven’t really talked about any topics yet.");
            }
            else
            {
                Console.WriteLine("- Topics we've covered:");
                foreach (var topic in discussedTopics)
                {
                    Console.WriteLine($"  • {topic}");
                }

            }//end of if-else statement

            if (pastQuestions.Count == 0)
            {
                Console.WriteLine("- No specific questions from you have been saved.");
            }
            else
            {
                Console.WriteLine("- Questions you've asked:");
                foreach (var question in pastQuestions)
                {
                    Console.WriteLine($"  • {question}");
                }

            }//end of if-else statement

        }//end of ShowMemorySummary()

    }//end of class UserMemory

}//end of namespace