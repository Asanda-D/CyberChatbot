# Cybersecurity Awareness Chatbot (CYBERLOCK)

## Project Overview

The Cybersecurity Awareness Chatbot, codenamed CYBERLOCK, is a C# console application developed to promote cybersecurity awareness among South African citizens. It helps users learn about online safety topics such as phishing, scams, malware, firewalls, and password protection through an interactive conversation.

The chatbot simulates real-time dialogue using keyword recognition, sentiment detection, and a simple memory system that remembers the user’s questions and topics. It also includes ASCII art and typing delays for a more engaging user experience.

## Features

Keyword Recognition: Detects common cybersecurity-related questions and responds with appropriate answers.
Sentiment Detection: Identifies emotional keywords (e.g., "angry", "confused") and adjusts its tone to offer support or clarification.
Memory Tracking: Remembers the user’s name and summarizes previous topics and questions when requested.
Typing Simulation: Displays messages with delays to simulate real-time typing.
ASCII Art: Displays stylized welcome text at the start of the application.
Modular Design: The project is broken into reusable and extendable classes (e.g., CyberBot, KeywordResponder, SentimentDetector, MemoryManager).

## Technologies Used

Language: C#
IDE: Visual Studio 2022
Framework: .NET 8
Optional: System.Speech for voice greeting on Windows systems

## Project Structure

CyberChatbot/
- Program.cs                // Entry point of the application
- CyberBot.cs               // Main logic of the chatbot
- KeywordResponder.cs       // Handles keyword-based responses
- SentimentDetector.cs      // Detects and responds to user emotions
- MemoryManager.cs          // Tracks previous topics and questions
- README.md                 // Project overview and instructions

## How to Run the Application

Open the project in Visual Studio 2022.
Restore any missing packages if needed.
Press Ctrl + F5 to run the application without debugging.
Interact with Cyberlock by typing in questions or cybersecurity-related topics.

## Sample Conversation

```plaintext
You: What is phishing?
Cyberlock: Phishing is a cyberattack where criminals pretend to be trustworthy sources to steal your personal info...

You: Scammers make me very angry
Cyberlock: I sense some frustration – I'm here to help! Always verify unknown requests before responding.
```

## Future Improvements

Add persistent memory using a local database
Integrate speech-to-text for voice input
Expand emotional intelligence with deeper sentiment analysis

## License

This project is for academic use as part of a Portfolio of Evidence for ST10366285. 
