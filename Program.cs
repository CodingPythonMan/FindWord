using System.Text;

string Dir = Environment.GetCommandLineArgs()[1];
DirectoryInfo directory = new DirectoryInfo(Dir);

FileInfo[] files = directory.GetFiles();
int[] result = new int[files.Length];

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