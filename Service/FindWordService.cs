using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWord.Service
{
    public class FindWordService
    {
        public void FindWord(string[] args)
        {
            FileInfo[] files = GetFiles(args[0]);

            int[] result = new int[files.Length];
            List<string> GoalWords = new();
            List<string> ExceptWords = new();

            ClassifyWords(GoalWords, ExceptWords, args);

            for (int i = 0; i < files.Length; i++)
            {
                int lineCount = 0;

                foreach (string line in File.ReadLines(files[i].ToString()))
                {
                    string Line = line.ToUpper();

                    int wordPos = Line.IndexOf("DROP", 0);
                    int droppingPos = Line.IndexOf("DROPPING", 0);

                    lineCount++;

                    while (wordPos != -1)
                    {
                        if (wordPos != droppingPos)
                        {
                            Console.WriteLine("{0} : {1}줄 {2}번째 문자에 drop이 있습니다.", files[i].Name, lineCount, wordPos + 1);
                            result[i]++;
                        }

                        int nextWordPos = wordPos + 1;

                        wordPos = Line.IndexOf("DROP", nextWordPos);
                        droppingPos = Line.IndexOf("DROPPING", nextWordPos);
                    }
                }

                Console.WriteLine("{0} 에는 drop 이 {1}개 있습니다.", files[i].Name, result[i]);
            }

        }

        public FileInfo[] GetFiles(string target)
        {
            string Dir = target;
            DirectoryInfo directory = new DirectoryInfo(Dir);

            return directory.GetFiles();
        }

        public void ClassifyWords(List<string> GoalWords, List<string> ExceptWords, string[] args)
        {
            int exceptPos = 0;
            // Except 위치 j
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].Equals("-except"))
                {
                    exceptPos = i;
                    break;
                }
                GoalWords.Add(args[i]);
            }
        }
    }
}
