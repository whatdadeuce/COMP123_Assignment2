using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TweetApp
{
    static class TweetManager
    {
        private static List<Tweet> tweets;
        private static string filename = @"C:\Users\Kenneth\Desktop\Programming2 Assigments\Assignment2\TweetApp\TweetFile.txt";

        static TweetManager()
        {
            tweets = new List<Tweet>();
            using (TextReader reader = new StreamReader(filename))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    tweets.Add(Tweet.Parse(line));
                    line = reader.ReadLine();
                }
            }
        }

        public static string Initialize()
        {
            return filename;
        }

        public static void ShowAll()
        {
            foreach (Tweet tweet in tweets)
            {
                Console.WriteLine("{0}\n\n", tweet);
            }
        }
        public static void ShowAll(string tag)
        {
            foreach (Tweet tweet in tweets)
            {
                if (tweet.Tag.ToLower() == tag.ToLower())
                {
                    Console.WriteLine("Tweet tag as {0}\n\n{1}", tag, tweet);
                }
            }
        }
    }
}
