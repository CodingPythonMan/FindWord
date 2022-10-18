using FindWord.Service;
using System.Text;

args = new string[10];
args[0] = "D:\\GItSource\\FindWord";
args[1] = "drop";
args[2] = "main";
args[3] = "-except";
args[4] = "dropping";

if (args.Length > 1)
{
    FindWordService findWordService = new();
    ClassifyService classifyService = new();

    findWordService.FindWord(args);
}