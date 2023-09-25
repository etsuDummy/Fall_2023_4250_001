//E00631771 - Christian Crawford
//E00568827 - Nicholas Sells

using System;
using System.IO;

class Main {

	static void AnalyzeString(string asciiString) {

		const int asciiTableSize = 256;
		int frequencyTable[asciiTableSize];

		for(int i = 0; i < asciiTableSize; i++) {
			frequencyTable[asciiString[i]]++;
		}

		//ran out of time right here, but here's how this should have gone
		
		//wait my idea actually wouldn't have worked
		//i was going to say we can sort the array to easily get the top three characters and all the characters with zero occurences,
		//but sorting this array loses the information about which character is where because each array position is implicitly,
		//associated with the character

		//i will find a better way after class
	}

	static string GetString(void) {
		return Console.ReadLine();
	}

	static void Main(string[] args) {

		string asciiString = "";

		if(args.Length == 1) {			
			try {
				asciiString = File.ReadAllText(args[0], System.Text.ASCIIEncoding);
			} catch(Exception e) {
				Console.WriteLine("Exception: " + e.Message);
				Console.WriteLine("Exception encountered, falling back to stdin mode");
				asciiString = GetString();	
			}
		}
		else if(args.Length() == 0) {
			Console.WriteLine("No arguments supplied, falling back to stdin mode");
			asciiString = GetString();
		}
		else {
			Console.WriteLine("Too many arguments supplied, falling back to stdin mode");
			asciiString = GetString();
		}

		AnalyzeString(asciiString);
	}
}
