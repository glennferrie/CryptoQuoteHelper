using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var enc = "Unset";
            var dec = "";
            var orig = "";
            Console.WriteLine("Welcome to CryptoHelper");
            Console.Write("Enter a command: ");
            var cmd = Console.ReadLine();
            while (cmd != "quit")
            {
                switch (cmd)
                {
                    case "show":
                        Console.WriteLine();
                        Console.WriteLine("enc: {0}", enc);
                        Console.WriteLine("dec: {0}", dec);
                        Console.WriteLine();
                        break;
                    case "start":
                        Console.Write("Enter message: ");
                        enc = Console.ReadLine().ToUpper();
                        orig = enc;
                        dec = Mask(enc);
                        break;
                    case "clear":
                        enc = "";
                        orig = "";
                        dec = "";
                        break;
                    
                    default:
                        // core feature, set letter.
                        cmd = cmd.ToUpper();
                        if (cmd.Contains("="))
                        {
                            var parts = cmd.Split(new[] { '=',' ' }, StringSplitOptions.RemoveEmptyEntries);
                            var source = parts[0];
                            var target = parts[1];
                            if (source.Length == 1 && target.Length == 1)
                            {
                                char s = source[0];
                                char t = target[0];

                                for(var y = 0; y < enc.Length; y++)
                                {
                                    var letter = enc[y];
                                    if (letter == s)
                                    {
                                        var decarr = dec.ToCharArray();
                                        decarr[y] = t;
                                        dec = new string(decarr);
                                    }
                                }
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("enc: {0}", enc);
                        Console.WriteLine("dec: {0}", dec);
                        Console.WriteLine();
                        break;
                }

                Console.Write("Enter a command: ");
                cmd = Console.ReadLine();
            }
        }

        private static string Mask(string enc)
        {
            var mask = new List<char>();
            foreach(char ch in enc)
            {
                if (ch >= 'A' && ch <= 'Z')
                {
                    mask.Add('?');
                    continue;
                }
                mask.Add(ch);
            }
            return new string(mask.ToArray());
        }
    }
}
