using BasePlugin.Records;
using System.Collections.Generic;

namespace checkBrackets
{
    public class CheckBrackets
    {

        public static string _Id = "check-string";
        public string Id => _Id;


        public PluginOutput Execute(PluginInput input)
        {
            if (input.Message == "")
            {
                input.Callbacks.StartSession();
                return new PluginOutput("enter a sentence to check if this sentence is correct and exit to finish");
            }
            else if (input.Message.ToLower() == "exit")
            {
                input.Callbacks.EndSession();
                return new PluginOutput("check string stopped.");
            }
            else
            {
                var s = input.Message;

                return new PluginOutput(Brackets(s) + "");
            }
        }
        public bool Brackets(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> d = new Dictionary<char, char>()
            {
                { '}','{'},{ ']','['},{ ')','('}
            };
            Dictionary<char, int> d2 = new Dictionary<char, int>()
            {
                { '{',0},{ '[',0},{ '(',0}
            };
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == ')' || s[i] == '{' ||
                    s[i] == '}' || s[i] == '[' || s[i] == ']')
                {

                    stack.Push(s[i]);
                }

            }
            bool b = true;
            int[] arr = new int[3];
            while (stack.Count > 0)
            {
                char t = stack.Pop();
                if (d.ContainsKey(t))
                {
                    d2[d[t]]++;
                }
                else
                {
                    d2[t]--;
                    if (d2[t] < 0) return false;
                }
            }
            foreach (var item in d2)
            {
                if (item.Value != 0)
                {
                    b = false;
                }
            }
            return b;
        }
    }
}
