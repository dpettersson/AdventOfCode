import numpy

# --- Day 3: Binary Diagnostic ---
# The submarine has been making some odd creaking noises, so you ask it to produce a diagnostic report just in case.
#
# The diagnostic report (your puzzle input) consists of a list of binary numbers which, when decoded properly, can tell
# you many useful things about the conditions of the submarine. The first parameter to check is the power consumption.
#
# You need to use the binary numbers in the diagnostic report to generate two new binary numbers (called the gamma rate
# and the epsilon rate). The power consumption can then be found by multiplying the gamma rate by the epsilon rate.
#
# Each bit in the gamma rate can be determined by finding the most common bit in the corresponding position of all
# numbers in the diagnostic report. For example, given the following diagnostic report:
#
# 00100
# 11110
# 10110
# 10111
# 10101
# 01111
# 00111
# 11100
# 10000
# 11001
# 00010
# 01010
# Considering only the first bit of each number, there are five 0 bits and seven 1 bits. Since the most common bit is 1,
# the first bit of the gamma rate is 1.
#
# The most common second bit of the numbers in the diagnostic report is 0, so the second bit of the gamma rate is 0.
#
# The most common value of the third, fourth, and fifth bits are 1, 1, and 0, respectively, and so the final three bits
# of the gamma rate are 110.
#
# So, the gamma rate is the binary number 10110, or 22 in decimal.
#
# The epsilon rate is calculated in a similar way; rather than use the most common bit, the least common bit from each
# position is used. So, the epsilon rate is 01001, or 9 in decimal. Multiplying the gamma rate (22) by the epsilon rate
# (9) produces the power consumption, 198.
#
# Use the binary numbers in your diagnostic report to calculate the gamma rate and epsilon rate, then multiply them
# together. What is the power consumption of the submarine? (Be sure to represent your answer in decimal, not binary.)


def read_input():
    input_file = open("input.txt", "r")
    data = input_file.read().splitlines()
    return data


test_data = ["00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"]

read_input()
#
# def brute_force_analyzis(input):
#     input_line_length = len(inpot[0])
#     occurences = numpy.zeroes(input_line_length + 1)
#     occurences[-1] = len(input) # Save the number of lines in the input
#
#     for line in input:
#         current_index = 0
#
#         while current_index < input_line_length:
#             if int(line[index]) == 1:
#                 occurences[index] = occurences[index] + 1
#             current_index = current_index + 1
#
#     return occurences


def calculate_rates(data):
    gamma = 0
    epsilon = 0

    pivot_point = int(data[-1]) / 2

    current_index = 0

    while current_index <  (current_index - 1):
        if int(data[current_index]) >= pivot_point:




def day_three_part_one(data):

    occurences = brute_force_analyzis(data)

    [gamma, epsilon] = calculate_rates(occurences)





assert day_three_part_one(test_data) == 198

