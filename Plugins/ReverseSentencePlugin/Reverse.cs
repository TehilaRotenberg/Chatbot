using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePlugin;
using BasePlugin.Interfaces;
using BasePlugin.Records;

namespace ReverseSentencePlugin
{
    public class Reverse: IPlugin
    {

        public static string _Id = "reversed";
        public string Id => _Id;
        public PluginOutput Execute(PluginInput input)
        {
              var reverseS = input.Message.Reverse();
            string st = "";
            foreach (var c in reverseS) { st += c;}
                return new PluginOutput(st,input.PersistentData);
        }
    }
}
