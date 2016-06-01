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
        /*
         * Private fields to stop List of Tweets and filename 
         */
        private static List<Tweet> tweets;
        private static string filename = @"C:\Users\Kenneth\Desktop\Programming2 Assigments\Assignment2\TweetApp\TweetFile.txt";

        /*
         * This is the static constructor. It does not require any parameter. 
         * This constructor does the following:
         * a.   Initialize the tweets field to a new list of tweets
         * b.	Opens the file specified by the filename field for reading
         * c.	Using a looping structure it does the following:
         *  i.	Reads one line from the file
         *  ii.	Passes this line to the static Parse() method of the Tweet class to create a tweet object
         *  iii.The resulting object is added to the tweet collection
         *  iv.	This is repeated until the input from the file is empty (null).
         */
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

        /*
         * This class method it used to facilitate the development of this project.
         * It will not be used in the production code. This method does the following:
         * a.	Creates about 5 tweets objects and add them to the tweet collection.
         */
        public static void Initialize(string line)
        {
            tweets.Add(Tweet.Parse("Ford	Trudeau	Bieber	Go Raptors! Go!"));
            tweets.Add(Tweet.Parse("WeTheNorth	Drake	Obama	Go Raptors! Go!"));
            tweets.Add(Tweet.Parse("Raptors	Tory	Drake	Yes Toronto will get them!"));
            tweets.Add(Tweet.Parse("Ford	Trudeau	Obama	Toronto joins cities around the world to celebrate International Day Against Homophobia & Transphobia"));
            tweets.Add(Tweet.Parse("Ford	Drake	Bieber	Go Raptors! Go!"));
        }

        /*
         * This is a public class method that does not take any argument that 
         * does not return a value. It display all the tweets matching this tag.
         */
        public static void ShowAll()
        {
            foreach (Tweet tweet in tweets)
            {
                Console.WriteLine("{0}\n\n", tweet);
            }
        }

        /*
         * This is a public class method that takes a string argument
         * that does not return a value. It display all the tweets matching this tag.
         */
        public static void ShowAll(string tag)
        {
            Console.WriteLine("Tweet with {0} tag", tag);
            Console.WriteLine("---------------------");
            foreach (Tweet tweet in tweets)
            {
                if (tweet.Tag.ToLower() == tag.ToLower())
                {
                    Console.WriteLine ("{0}\n",tweet);
                }
            }
        }
    }
}
