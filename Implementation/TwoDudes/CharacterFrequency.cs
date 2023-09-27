//E00631771 - Christian Crawford
//E00568827 - Nicholas Sells

namespace CharacterFrequency {

	internal class Program {

		/// <summary>
		/// takes in a string and reports the most frequent ASCII characters
		/// within it, as well as any characters with zero occurences
		/// </summary>
		/// <param name="asciiString">the string we are analyzing</param>
		/// <param name="top">the number of top most frequent characters to
		/// report</param>
		static void AnalyzeString(string asciiString, int top = 3) {

			var frequencyDict = new Dictionary<char, int>();

			//build up a histogram of each character's frequency
			foreach (char ch in asciiString)
				if (frequencyDict.ContainsKey(ch))
					frequencyDict[ch]++;
				else
					frequencyDict.TryAdd(ch, 1);

			//sort that information by frequency from greatest to least
			var frequencyList = frequencyDict.ToList();
			frequencyList.Sort((a,b) => b.Value.CompareTo(a.Value));

			Console.WriteLine($"Top {top} most frequent characters in string:");
			if (frequencyList.Count > 0) {
				for (int i = 0; (i < top) && (i < frequencyList.Count); i++)
					Console.WriteLine($"{frequencyList[i].Key}" +
					$"({frequencyList[i].Value} occurences)");
			}
			else
				Console.WriteLine("Not enough data to display");

			Console.WriteLine("Character codes of characters with zero" +
			"occurences:");
			if (Byte.MaxValue - frequencyList.Count > 0) {
				for (int i = 0; i <= Byte.MaxValue; i++) {
					if (!frequencyDict.ContainsKey((char)i)) {
						Console.Write(i);
						if (i != Byte.MaxValue)
							Console.Write(", ");
					}
				}
			}
			else
				Console.WriteLine("Note enough data to display");

			return;
		}


		/// <summary>
		/// gets a line of user input from stdin
		/// </summary>
		/// <returns>the next available line from stdin, or if none are
		/// available, an empty string</returns>
		static string GetString() {
			return Console.ReadLine() ?? "";
		}


		static void Main(string[] args) {

			string asciiString;
			if (args.Length == 1) {
				try {
					asciiString = File.ReadAllText(args[0],
					System.Text.Encoding.ASCII);
				}
				catch (Exception e) {
					Console.WriteLine("Exception: " + e.Message);
					Console.WriteLine("Exception encountered, falling back to" +
					"stdin mode");
					asciiString = GetString();
				}
			}
			else if (args.Length > 1) {
				Console.WriteLine("Too many arguments supplied, falling back" +
				"to stdin mode");
				Console.WriteLine("Enter any string at all!");
				asciiString = GetString();
			}
			else {
				Console.WriteLine("Enter any string at all!");
				asciiString = GetString();
			}

			
			AnalyzeString(asciiString);
		}
	}
}
