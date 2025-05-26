using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberChatbot.Modules;

namespace CyberChatbot
{
    public class CyberBot
    {
        private string userName;
        private readonly KeywordResponder keywordResponder = new KeywordResponder();
        private readonly TopicManager topicManager = new TopicManager();
        private string currentTopic = "";
        private UserMemory memory = new UserMemory();
        private SentimentDetector sentimentDetector = new SentimentDetector();

        public void StartChat()
        {
            Console.WriteLine("\n==============================================================================================");
            Console.WriteLine("                              Cybersecurity Awareness Chatbot");
            Console.WriteLine("==============================================================================================\n");

            Console.WriteLine("Hello there! Hope you are doing amazing today :)");
            Console.Write("Please enter your full name: ");
            userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            TypeResponse($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Assistant\nCall me the... !!CYBERLOCK GUARD!! <^>");
            Console.WriteLine("**********************************************************************************************" +
                "\nFeel free to ask me anything about staying safe online :)");
            Console.ResetColor();

            Console.WriteLine("\nYou can ask me questions like:");
            Console.WriteLine("- How are you?\n- What's your purpose?\n- What can I ask you about?\n- Tell me about password safety\n- What is phishing?\n- How do I browse safely?");
            Console.WriteLine("- What is malware?\n- What should I do if I'm hacked?\n- What is a firewall?\n- Why are software updates important?\n- How do I create a strong password?");
            Console.WriteLine("\nTo end chat enter 'exit' or 'quit'.");

            bool keepChatting = true;

            while (keepChatting)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cyberlock: Please enter something for me to respond to!!!");
                    Console.ResetColor();
                    continue;
                }

                userInput = userInput.Trim().ToLower();
                memory.AddPastQuestion(userInput);
                string detectedSentiment = sentimentDetector.DetectSentiment(userInput);
                AdjustTone(detectedSentiment);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Cyberlock is typing...");
                Thread.Sleep(400);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                switch (userInput)
                {
                    case "how are you?":
                        TypeResponse("I'm fully patched and running smoothly! Thanks for asking. ;) I’m always on guard to keep you safe!");
                        break;

                    case "what's your purpose?":
                        TypeResponse("I'm here to empower you with cybersecurity knowledge and help you protect your digital world from threats.");
                        break;

                    case "what can i ask you about?":
                        TypeResponse("You can ask me: \n- How are you?\n- Tell me about password safety\n- What is phishing?\n- How do I browse safely?\n" +
                            "- What is malware?\n- What should I do if I'm hacked?\n- What is a firewall?\n- Why are software updates important?\n- How do I create a strong password?");
                        break;

                    case "tell me about password safety":
                        TypeResponse("Passwords should be long and complex — at least 12 characters. Use numbers, symbols, and upper/lowercase letters. Avoid personal info like birthdays.");
                        ShowRandomCyberTip();
                        break;

                    case "what is phishing?":
                        TypeResponse("Phishing is a cyberattack where criminals pretend to be trustworthy sources to steal your personal info. Always double-check links and emails before clicking.");
                        ShowRandomCyberTip();
                        break;

                    case "how do i browse safely?":
                        TypeResponse("Use trusted websites, look for 'https' in the URL, and avoid downloading files or clicking popups from unknown sources. Also, use privacy-focused browsers when possible.");
                        ShowRandomCyberTip();
                        break;

                    case "what is malware?":
                        TypeResponse("Malware is any software designed to harm your computer or steal your data. It includes viruses, spyware, trojans, and more. Keep your antivirus up to date!");
                        ShowRandomCyberTip();
                        break;

                    case "what should i do if i'm hacked?":
                        TypeResponse("Change your passwords immediately, enable two-factor authentication, and scan your devices with security software. Alert your bank or contacts if needed.");
                        ShowRandomCyberTip();
                        break;

                    case "what is a firewall?":
                        TypeResponse("A firewall acts like a digital security guard — it monitors incoming and outgoing network traffic and blocks threats before they reach you.");
                        ShowRandomCyberTip();
                        break;

                    case "why are software updates important?":
                        TypeResponse("Updates often include patches for new security holes. If you delay them, hackers can exploit those weaknesses to gain access to your data.");
                        ShowRandomCyberTip();
                        break;

                    case "how do i create a strong password?":
                        TypeResponse("Use a mix of letters, numbers, and symbols. Avoid dictionary words. For example: 'B3@chW4lker!2025'. Also, use a password manager to keep track.");
                        ShowRandomCyberTip();
                        break;

                    case "Thanks":
                    case "Thank you":
                        TypeResponse($"You’re absolutely welcome, {userName}! Happy to help you anytime :)");
                        break;

                    case "show memory":
                    case "show summary":
                    case "what have we talked about?":
                        memory.ShowMemorySummary(userName);
                        break;

                    default:
                        if (keywordResponder.TryGetResponse(userInput, out string keywordResponse, out string matchedKeyword))
                        {
                            if (memory.HasDiscussed(matchedKeyword))
                            {
                                TypeResponse($"Hey {userName}, we've already touched on '{matchedKeyword}' — but here's something else on it:");
                            }
                            else
                            {
                                TypeResponse($"Let's explore something new: '{matchedKeyword}'.");
                                memory.RememberTopic(matchedKeyword);
                            }//end of if-else statement

                            currentTopic = matchedKeyword; // Save what topic user asked about
                            TypeResponse(keywordResponse);
                            ShowRandomCyberTip();
                            continue;
                        }
                        // Check for follow-up question like "why?" or "tell me more"
                        else if (IsFollowUp(userInput) && !string.IsNullOrEmpty(currentTopic))
                        {
                            string followUpResponse = keywordResponder.GetFollowUpResponse(currentTopic);
                            TypeResponse(followUpResponse);
                            ShowRandomCyberTip();
                            continue;
                        }
                        else
                        {
                            TypeResponse("I'm sorry I didn’t quite understand that. Could you rephrase or try a different question?");
                        }
                        break;

                    case "exit":
                    case "quit":
                        TypeResponse($"Stay safe out there, {userName}! <^> Goodbye.");
                        keepChatting = false;
                        break;

                }//end of switch case

                Console.ResetColor();

            }//end of while loop

        }//end of StartChat()

        private void TypeResponse(string message, int delay = 15)
        {
            Console.Write("Cyberlock: ");
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            Console.WriteLine();

        }//end of TypeResponse()

        private void ShowRandomCyberTip()
        {
            string[] tips = {
                "General Tip: Always use 2-factor authentication on your accounts.",
                "General Tip: Never reuse the same password across sites.",
                "General Tip: Watch out for fake giveaways on social media.",
                "General Tip: Use antivirus software and keep it up to date.",
                "General Tip: Don’t plug in unknown USB devices — they can carry malware!",
                "General Tip: Regularly back up your data in case of ransomware attacks.",
                "General Tip: Think before you click — even on social media links.",
            };

            Random rnd = new Random();
            int index = rnd.Next(tips.Length);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            TypeResponse(tips[index], 15);
            Console.ResetColor();

        }//end of ShowRandomCyberTip()

        private bool IsFollowUp(string input)
        {
            string[] followUps = new string[]
            {
                "tell me more",
                "what else",
                "how",
                "more info",
                "next",
                "continue",
                "why",
                "details",
                "more",
                "you sure",
                "can you explain"
            };

            foreach (var phrase in followUps)
            {
                if (input.Contains(phrase, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;

        }//end of IsFollowUp()

        private void AdjustTone(string sentiment)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (sentiment)
            {
                case "frustrated":
                    TypeResponse("I sense some frustration — I’m here to help! Let’s break it down simply.");
                    break;

                case "confused":
                    TypeResponse("It’s okay to feel confused. Let me explain it as clearly as possible.");
                    break;

                case "grateful":
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypeResponse("You’re most welcome! Happy to help anytime :)");
                    break;

                case "help":
                    TypeResponse("I’m right here with you. Tell me what you need and I’ll do my best to guide you.");
                    break;

                case "neutral":
                default:
                    // No tone adjustment needed
                    break;

            }//end of switch case

            Console.ResetColor();

        }//end of AdjustTone()

    }//end of class Cyberbot

}//end of namespace


/* REFERENCES
 * CISA (Cybersecurity and Infrastructure Security Agency) (n.d.) Cybersecurity Best Practices. Available at: https://www.cisa.gov/topics/cybersecurity-best-practices (Accessed: 14 May 2025).
 * Norton (2025) Phishing protection: 11 tips to protect yourself from phishing. Available at: https://us.norton.com/blog/how-to/how-to-protect-against-phishing (Accessed: 15 May 2025).
 * Ofcom (2025) Guide for services: complying with the Online Safety Act. Available at: https://www.ofcom.org.uk/online-safety/illegal-and-harmful-content/guide-for-services (Accessed: 16 May 2025).
 * SHI (2023) 10 best practices for building an effective security awareness program. Available at: https://blog.shi.com/cybersecurity/security-awareness-training-best-practices/ (Accessed: 17 May 2025).
 * Kaspersky (n.d.) Phishing Scams & Attacks - How to Protect Yourself. Available at: https://www.kaspersky.com/resource-center/preemptive-safety/phishing-prevention-tips (Accessed: 18 May 2025).
 * 
 */