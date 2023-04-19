using System.Text;

namespace WordCounterInText
{
    internal class ReadFile
    {
        private const string FILE_PATH = @"C:\test\Text1.txt";
        
        public static void CountWord()
        {
            string text = File.ReadAllText(FILE_PATH);
            StringBuilder sb = new StringBuilder();
            var listOfWords = new Dictionary<string, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                        if (listOfWords.ContainsKey(sb.ToString().ToUpper()))
                        {
                            listOfWords[sb.ToString().ToUpper()]++;
                        }
                        else
                        {
                            listOfWords.Add(sb.ToString().ToUpper(), 1);
                        }
                        
                    sb.Clear();
                }
                sb.Append(text[i]);
            }

            var sortedListOfWords = (from w in listOfWords
                       orderby w.Value descending
                       select w).ToDictionary(w => w.Key, w => w.Value);

            // Количество слов, которое нужно вывести
            int wordCounter = 10;

            foreach (var item in sortedListOfWords)
            {
                if (wordCounter == 0)
                {
                    break;
                }
                Console.WriteLine($"{item.Key} : {item.Value}");
                wordCounter--;
            }
        }
    }
}
