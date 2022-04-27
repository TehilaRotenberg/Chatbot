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
                return new PluginOutput(input.Message.Reverse().ToString(),input.PersistentData);
        }
    }
}
