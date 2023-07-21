using System.Text;

namespace OOPAdventure
{
    public partial class Language
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public virtual string JoinedWordList(string[] words, string conjuction)
        {
            // Clear so that there are no strings before making the list
            _sb.Clear();

            for (var i = 0; i < words.Length; i++)
            {
                // Should a comma be added or not
                if (i > 0)
                    // Append a comma and a space or just a space depending on what position the word exists in the array
                    _sb.Append(words.Length > 2 ? Comma + Space : Space);

                // Check to see if we are at the end of the list and there is more than one word
                if (i == words.Length - 1 && words.Length > 1)
                {
                    // Aadd a conjuction
                    _sb.Append(conjuction + Space);
                }

                _sb.Append(words[i]);

            }

            return _sb.ToString();

        }
    }
}
