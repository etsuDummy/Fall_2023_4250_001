# Anthony Vandergriff, Carson Crysdale, Benjamin Merritt
# Using Recursion; take two numbers in from the user
# and add them together then separate the least significant 
# digit and add it the remaining digits and so on 
# until you have a single digit answer. 
def reduce_to_single_digit(number):
        #if the number has one digit then return
        if number < 10: 
            return number
        
        #Identify the least significant digit
        last_digit = number % 10

        #remove and store the least significant digit
        number = int(str(number)[:-1])

        #add lease significant digit to the number that it was just removed from
        new_total = number + last_digit

        #Recursively call the functuion with the new total 
        return reduce_to_single_digit(new_total)

#function to check input for integer
def check_user_input(data):
      while True:
            try:
                user_input = int(input(data))
                return user_input
            except ValueError:
                print ("Invalid Input: Enter a number.")

try:
    #Promt user for numbers  
    user_prompt1 = check_user_input("Enter a number:")
    user_prompt2 = check_user_input("Enter a second number:")

    #adds both numbers from user
    user_input_total = user_prompt1 + user_prompt2 

    #stores the single digit
    output = reduce_to_single_digit(user_input_total)

    print(output)
except KeyboardInterrupt:
     print ("\nProgram was stopped by the user.")
except Exception as e:
     print(f"An error has occurred: {e}")