# in class exercise by Jacob Manis and Isaac Simmons

def parse_to_string(number):
    """
    simple function to take integer and return string of that int
    :param: number
    :return: str(number)
    """
    return str(number)


def break_number(number):
    """
    input integer
    parse this to string so we can add LSD to the rest of the numbers digits as per the requirements
    recursively call the same function until the input corresponds to single digit integer and end this run of the program
    :param: number
    :return: break_number(str(whole_number)) or nothing
    """
    number_str = parse_to_string(number)
    if len(number_str) > 1:

        least_sig_str = number_str[len(number_str) - 1]
        remaining_digits_str = number_str[:-1]

        print("Most significant digits: " + remaining_digits_str + " least significant digit: " + least_sig_str)

        whole_number = int(remaining_digits_str) + int(least_sig_str)

        print("Added Number: " + str(whole_number) + "\n")

        return break_number(str(whole_number))
    elif len(number_str) == 1:
        print("final number:" + number_str)
    else:
        print("Error. String needs to be of length 1 or greater")
    return


# main starting point of program
if __name__ == '__main__':
    # need to validate inputs to ensure inputs are positive integers
    restart_program: bool = True
    while restart_program:
        while True: 
            try:      
                user_number_1: int = int(input('Please enter the first positive integer: '))
                if(user_number_1 < 0):
                    print("Invalid input. Please enter a positive integer\n")
                    continue
                break
            # exception thrown if parse failed, this continues the loop
            except ValueError:
                print('Invalid input. Please enter a positive integer\n')
                continue

        while True:
            try:
                user_number_2: int = int(input('Please enter the second positive integer: '))
                if(user_number_2 < 0):
                    print("Invalid input. Please enter a positive integer\n")
                    continue
                break
            except ValueError:
                print('Invalid input. Please enter a positive integer\n')
                continue

        whole_number = user_number_1 + user_number_2
        print("Number to break and add: " + str(whole_number) + "\n")
        break_number(whole_number)

        play_again: str = input('Would you like to restart the program? Enter y if yes or enter anything else to end the program.\n')
        if play_again.lower() != 'y':
            restart_program = False
