//E00568827 - Nicholas Sells
//E00631771 - Christian Crawford

namespace DigitalRoot {

	internal class Program {

		/// <summary>
		/// recursively sums all digits of n, using the given radix 
		/// </summary>
		/// <param name="n">the number whose digits are to be summed</param>
		/// <param name="radix">the base of our number system. usually 1
		/// </param>
		/// <returns>the sum of all digits of n, and the sum of all digits of
		/// that, until we have a single digit</returns>
		static uint DigitalRoot(uint n, uint radix = 10) {
			if (n == 0) {
				Console.WriteLine("digital root is defined only for natural" +
				"numbers (integers greater than zero)");
				return 0;
			}
			uint mostSigFigs = n / radix;
			uint leastSigFig = n % radix;
			uint sum = mostSigFigs + leastSigFig;
			if (sum >= radix)
				return DigitalRoot(sum, radix);
			else
				return sum;
		}


		/// <summary>
		/// prompts the user to enter a natural number (integer greater than
		/// zero)
		/// </summary>
		/// <param name="number">a reference to the integer we are storing the
		/// result in. defaults to zero if we fail to validate</param>
		/// <param name="attempts">the number of attempts to make to validate
		/// the input. -1 means infinite attempts</param>
		/// <returns>true if input was successfully captured, false if all
		/// validation attempts failed</returns>
		static bool GetNaturalNumber(out uint number, int attempts = -1) {
			do {
				if (UInt32.TryParse(Console.ReadLine() ?? "", out number)) {
					Console.WriteLine($"Successfully captured input: {number}");
					return true;
				}
				else {
					Console.Error.Write($"Failed to parse natural number from" +
					$"user input");
					if (attempts != -1) {
						Console.Error.Write($"{attempts} attempts remaining");
						attempts--;
					}
					Console.Error.WriteLine();
				}
			} while ((attempts > 0) || (attempts != 1));
			return false;
		}


		static void Main(string[] args) {

			uint number1, number2;
			Console.WriteLine("Digital Root Calculator");
			Console.WriteLine("You will be prompted to enter two natural" +
			"numbers (integers greater than zero)");
			Console.WriteLine("Please enter the first number");
			GetNaturalNumber(out number1);
			Console.WriteLine("Please enter the second number");
			GetNaturalNumber(out number2);

			uint sum = number1 + number2;
			Console.WriteLine($"Sum of {number1} and {number2} is {sum}");

			uint digitalRoot = DigitalRoot(sum);
			Console.WriteLine($"Digital root of {sum} is {digitalRoot}");
		}
	}
}