using BasePlugin.Interfaces;
using BasePlugin.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AddAndSubUpTo20
{

    public class AddAndSub : IPlugin
    {
        public static string _Id = "add-and-sub";
        public string Id => _Id;

        public PluginOutput Execute(PluginInput input)
        {

            string str= input.Message;
            if(str=="")
            {
                if (input.Message == "")
                {
                    input.Callbacks.StartSession();
                    return new PluginOutput("Enter a addition and subtraction exercise to see if the result is greater than 0 and less than 20");
                }
            }
            else
            if (str != null)
            {
                int sum = 0,  number;
                var index=str.LastIndexOfAny(new[] { '+', '-' });
                while (index > 0 && index!=null)
                {
                    switch (str[index])
                    {
                        case '+':
                            if (int.TryParse(str.Substring(index + 1), out number))
                                sum += number;
                            else
                                return new PluginOutput("The string contains characters that are not operand numbers"); break;
                        case '-':
                            if (int.TryParse(str.Substring(index + 1), out number))
                                sum -= number;
                            else return new PluginOutput("The string contains characters that are not operand numbers"); break;



                    }
                    str=str.Substring(0,index);
                     index = str.LastIndexOfAny(new[] { '+', '-' });


                }
                if(int.TryParse(str, out number))
                {
                    sum += number;                }
                else
                {
                    return new PluginOutput("The string contains characters that are not operand numbers");
                }
                if ((sum > 0) && (sum < 20))
                    return new PluginOutput("Well done The result is:" + sum);
                else
                    return new PluginOutput("The result is invalid");


            }
           
          
            return new PluginOutput(str);
        }
    }
}
