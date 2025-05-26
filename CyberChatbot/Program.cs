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