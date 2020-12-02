
input_file = open("input.txt", "r")
data = input_file.read().splitlines()

# --- Day 2: Password Philosophy ---
# Your flight departs in a few days from the coastal airport; the easiest way down to the coast from here is via toboggan.
#
# The shopkeeper at the North Pole Toboggan Rental Shop is having a bad day.
# "Something's wrong with our computers; we can't log in!"
# You ask if you can take a look.
#
# Their password database seems to be a little corrupted: some of the passwords wouldn't have been allowed by the
# Official Toboggan Corporate Policy that was in effect when they were chosen.
#
# To try to debug the problem, they have created a list (your puzzle input) of passwords (according to the
# corrupted database) and the corporate policy when that password was set.
#
# For example, suppose you have the following list:
#
# 1-3 a: abcde
# 1-3 b: cdefg
# 2-9 c: ccccccccc
# Each line gives the password policy and then the password. The password policy indicates the lowest and highest
# number of times a given letter must appear for the password to be valid.
# For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.
#
# In the above example, 2 passwords are valid.
# The middle password, cdefg, is not; it contains no instances of b, but needs at least 1.
# The first and third passwords are valid: they contain one a or nine c, both within the limits of their
# respective policies.
#
# How many passwords are valid according to their policies?


def daytwo_part_one(data):

    no_of_correct_passwords = 0

    for line in data:
        if check_occurences_in_line(line):
            no_of_correct_passwords = no_of_correct_passwords + 1

    print("Found: " + str(no_of_correct_passwords) + " correct password")


def check_occurences_in_line(line, debug=False):
    line_ok = False
    components = line.split()
    limits = components[0].split('-')
    char_to_find = components[1][0]
    password = components[2]

    if debug:
        print("Received line: " + line)
        print("Limits: " + limits[0] + limits[1])
        print("char to find: " + char_to_find)
        print("Password: " + password)

    char_count = password.count(char_to_find)

    if char_count >= int(limits[0]) and char_count <= int(limits[1]):
        if debug:
            print("Password Ok")
        line_ok = True

    return line_ok


test_data = ["1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc"]
#
#
#assert check_occurences_in_line(test_data[0]) == True
#assert check_occurences_in_line(test_data[1]) == False
#assert check_occurences_in_line(test_data[2]) == True

#daytwo_part_one(data)



# --- Part Two ---
# While it appears you validated the passwords correctly, they don't seem to be what the Official
# Toboggan Corporate Authentication System is expecting.
#
# The shopkeeper suddenly realizes that he just accidentally explained the password policy rules from his old
# job at the sled rental place down the street! The Official Toboggan Corporate Policy actually works a little
# differently.
#
# Each policy actually describes two positions in the password, where 1 means the first character, 2 means the
# second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly
# one of these positions must contain the given letter. Other occurrences of the letter are irrelevant for the
# purposes of policy enforcement.
#
# Given the same example list from above:
#
# 1-3 a: abcde is valid: position 1 contains a and position 3 does not.
# 1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
# 2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.
# How many passwords are valid according to the new interpretation of the policies?

def check_line_positions(line, debug=False):
    occurrences = 0
    components = line.split()
    locations = components[0].split('-')
    char_to_find = components[1][0]
    password = components[2]

    if debug:
        print("Received line: " + line)
        print("Limits: " + locations[0] + locations[1])
        print("char to find: " + char_to_find)
        print("Password: " + password)

    for location in locations:
        if password[int(location) - 1] == char_to_find:
            occurrences = occurrences + 1
            if debug:
                print("Found char at location: " + str(location))

    return occurrences == 1


#assert check_line_positions(test_data[0], True) == True
#assert check_line_positions(test_data[1], True) == False
#assert check_line_positions(test_data[2], True) == False

def day_two_part_two(data):
    no_of_correct_passwords = 0

    for line in data:
        if check_line_positions(line):
            no_of_correct_passwords = no_of_correct_passwords + 1

    print("Found: " + str(no_of_correct_passwords) + " correct password")

day_two_part_two(data)