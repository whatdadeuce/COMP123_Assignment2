using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetApp
{
    class Tweet
    {
        //constant field
        private static int CURRENT_ID;
        
        //properties
        public string From {get; private set;}
        public string To {get; private set;}
        public string Body {get; private set;}
        public string Tag {get; private set;}
        public string Id {get; private set; }

        /*
            This public constructor takes four string parameters. This constructor does the following:
            a.	Assigns the arguments to the appropriate properties. 
            b.	Sets the Id property using the class variable CURRENT_ID. 
            c.	After the Id property is set, the CURRENT_ID is then incremented so that the next assignment will be
            unique. (see description of Id above)
         */

        public Tweet(string from, string to, string body, string tag)
        {
            From = from;
            To = to;
            Body = body;
            Tag = tag;
            Id = ""+ CURRENT_ID;
            CURRENT_ID++;
        }

        /*
        This method overrides the same method of the Object class. 
        It does not take any parameter but return a string representation of itself.
        You decide on the format for the output. You should also consider outputting only part of the Body. 
        Use the Substring() method of the string class to do this.
       */
        public  override string ToString()
        {
            return string.Format("ID: {0}\nFrom: {1}\nTo: {2}\nBody: {3}...\nTag: {4}",
                Id, From, To, Body.Substring(0, Body.Length), Tag);
        }

        /*
         * This is a public class method that takes a string argument and returns a Tweet object. 
         * It is used to create a Tweet object when loading the tweets from a file. 
         * The argument represents a single line of input read from the file. This method does the following:
            a.	Uses the Split() method of the string class is to chunk the input into four strings. 
                    The delimiter is this case is a tab.
            b.	Invokes the constructor with the four arguments
            c.	Return the result of the above invocation

        */
        public static Tweet Parse(string line)
        {
            string[] tweetParam =  line.Split('\t');
            Tweet tweetLine = new Tweet(tweetParam[1], tweetParam[2], tweetParam[3], tweetParam[0]);
            return tweetLine;
        }

}
}
