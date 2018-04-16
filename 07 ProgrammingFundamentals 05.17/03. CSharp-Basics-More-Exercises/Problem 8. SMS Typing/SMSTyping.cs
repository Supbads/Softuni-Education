using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8.SMS_Typing
{
    class SMSTyping
    {
        
        static void Main(string[] args)
        {
            Dictionary<char, char[]> keyboard = new Dictionary<char, char[]>();

            FillDictionary(keyboard);

            int numberOfLinesToRead = int.Parse(Console.ReadLine());

            List<char> message = new List<char>();

            for (int i = 0; i < numberOfLinesToRead; i++)
            {
                string input = Console.ReadLine();

                char symbolPress = input.FirstOrDefault();
                int timesPressed = input.Length;

                char letterSent = keyboard[symbolPress][timesPressed - 1];

                message.Add(letterSent);
            }

            foreach (char letter in message)
            {
                Console.Write(letter);
            }

        }

        private static void FillDictionary(Dictionary<char, char[]> keyboard)
        {
            keyboard.Add('2', new char[] { 'a', 'b', 'c' });
            keyboard.Add('3', new char[] { 'd', 'e', 'f' });
            keyboard.Add('4', new char[] { 'g', 'h', 'i' });
            keyboard.Add('5', new char[] { 'j', 'k', 'l' });
            keyboard.Add('6', new char[] { 'm', 'n', 'o' });
            keyboard.Add('7', new char[] { 'p', 'q', 'r', 's' });
            keyboard.Add('8', new char[] { 't', 'u', 'v' });
            keyboard.Add('9', new char[] { 'w', 'x', 'y', 'z' });
            keyboard.Add('0', new char[] { ' ' });
        }
    }
}