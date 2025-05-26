using System.Media;

namespace CyberChatbot
{
    internal class Program
    {
        static void Main(string[] args)
        {



            // Display ASCII logo
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine
                (@"
                   ____            _                   _                   _           
                  / ___|___  _ __ | |_ _   _ _ __ ___ (_)_ __   __ _    __| | ___ _ __ 
                 | |   / _ \| '_ \| __| | | | '_ ` _ \| | '_ \ / _` |  / _` |/ _ \ '__|
                 | |__| (_) | | | | |_| |_| | | | | | | | | | | (_| | | (_| |  __/ |   
                  \____\___/|_| |_|\__|\__,_|_| |_| |_|_|_| |_|\__, |  \__,_|\___|_|   
                                                               |___/                  
                ");
            Console.ResetColor();

            PlayGreetingAudio();

            // Start the bot
            CyberBot bot = new CyberBot();
            bot.StartChat();

        }//end of Main()

        static void PlayGreetingAudio()
        {
            try
            {
#pragma warning disable CA1416
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cassidy", "greeting.wav");
                using (SoundPlayer player = new SoundPlayer(audioPath))
                {
                    player.Load();
                    player.PlaySync(); // Wait for audio to finish before continuing
                }
#pragma warning restore CA1416
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);

            }//end of try-catch

        }//end of PlayGreetingAudio()

    }//end of class Program

}//end of namespace


/* REFERENCES
 * Logic & Chaos (2023) Animate Text in C# Console Applications: A Step-by-Step Tutorial. Available at: https://logicandchaos.itch.io/endless-prose/devlog/488908/animate-text-in-c-console-applications-a-step-by-step-tutorial (Accessed: 19 May 2025).
 * Stack Overflow (2018) C# Write to console slowly. Available at: https://stackoverflow.com/questions/51370620/c-sharp-write-to-console-slowly (Accessed: 20 May 2025).
 * Stack Overflow (2021) Can it be possible to add delay in Console.WriteLine or in Console.ReadKey for hiding text for a few seconds?. Available at: https://stackoverflow.com/questions/66805849/can-it-be-possible-to-add-delay-in-console-writeline-or-in-console-readkey-for-h (Accessed: 14 May 2025).
 * Stack Overflow (2013) Text animation, creating typewriting-like effect in c#. Available at: https://stackoverflow.com/questions/18469061/text-animation-creating-typewriting-like-effect-in-c-sharp (Accessed: 15 May 2025).
 * Stack Overflow (2011) How Do You Simulate Typing in c#?. Available at: https://stackoverflow.com/questions/4959126/how-do-you-simulate-typing-in-c (Accessed: 16 May 2025).
 * 
 */