
def generate_grid(side, serial):
    side = side
    grid = [[0 for x in range(side)] for y in range(side)]
    grid_serial = serial

    x = 0
    y = 0

    while x < side:
        y = 0
        while y < side:
            rack_id = x + 10
            power_level = rack_id * y
            power_level = power_level + grid_serial
            rack_id_and_power_level = rack_id * power_level
            # hundred_digit = rack_id_and_power_level // 10**3 % 10

            if rack_id_and_power_level < 100:
                hundred_digit = 0
            else:
                digits_as_str = str(rack_id_and_power_level)
                hundred_digit = int(digits_as_str[len(digits_as_str) - 3])

            grid[x][y] = hundred_digit - 5
            y = y + 1
        x = x + 1

    return grid


def calculate_power_in_grid_squares(grid):

    size_of_grid = len(grid)
    grid_values = [[0 for x in range(size_of_grid - 2)] for y in range(size_of_grid - 2)]

    x = 0

    while x < size_of_grid - 2:
        y = 0

        while y < size_of_grid  - 2:
            grid_values[x][y] = grid[x][y] + grid[x + 1][y] + grid[x + 2][y] + grid[x][y + 1] + grid[x + 1][y + 1] + grid[x + 1][y + 2] + grid[x + 2][y] + grid[x + 2][y + 1] + grid[x + 2][y + 2]

            y = y + 1
        x = x + 1

    return grid_values


def find_highest_value(grid):
    highest_value = max(max(grid))

    for x, row in enumerate(grid):

        if highest_value in row:

            return [highest_value, x, row.index(highest_value)]




# --- Day 11: Chronal Charge ---
# You watch the Elves and their sleigh fade into the distance as they head toward the North Pole.
#
# Actually, you're the one fading. The falling sensation returns.
#
# The low fuel warning light is illuminated on your wrist-mounted device.
# Tapping it once causes it to project a hologram of the situation: a 300x300 grid of fuel cells and their current
# power levels, some negative. You're not sure what negative power means in the context of time travel,
# but it can't be good.
#
# Each fuel cell has a coordinate ranging from 1 to 300 in both the X (horizontal) and Y (vertical) direction.
# In X,Y notation, the top-left cell is 1,1, and the top-right cell is 300,1.
#
# The interface lets you select any 3x3 square of fuel cells. To increase your chances of getting to your destination,
# you decide to choose the 3x3 square with the largest total power.
#
# The power level in a given fuel cell can be found through the following process:
#
# Find the fuel cell's rack ID, which is its X coordinate plus 10.
# Begin with a power level of the rack ID times the Y coordinate.
# Increase the power level by the value of the grid serial number (your puzzle input).
# Set the power level to itself multiplied by the rack ID.
# Keep only the hundreds digit of the power level (so 12345 becomes 3; numbers with no hundreds digit become 0).
# Subtract 5 from the power level.
# For example, to find the power level of the fuel cell at 3,5 in a grid with serial number 8:
#
# The rack ID is 3 + 10 = 13.
# The power level starts at 13 * 5 = 65.
# Adding the serial number produces 65 + 8 = 73.
# Multiplying by the rack ID produces 73 * 13 = 949.
# The hundreds digit of 949 is 9.
# Subtracting 5 produces 9 - 5 = 4.
# So, the power level of this fuel cell is 4.
#
# Here are some more example power levels:
#
# Fuel cell at  122,79, grid serial number 57: power level -5.
# Fuel cell at 217,196, grid serial number 39: power level  0.
# Fuel cell at 101,153, grid serial number 71: power level  4.
# Your goal is to find the 3x3 square which has the largest total power.
# The square must be entirely within the 300x300 grid.
# Identify this square using the X,Y coordinate of its top-left fuel cell. For example:
#
# For grid serial number 18, the largest total 3x3 square has a top-left corner of 33,45
# (with a total power of 29); these fuel cells appear in the middle of this 5x5 region:
#
# -2  -4   4   4   4
# -4   4   4   4  -5
#  4   3   3   4  -4
#  1   1   2   4  -3
# -1   0   2  -5  -2
# For grid serial number 42, the largest 3x3 square's top-left is 21,61 (with a total
# power of 30); they are in the middle of this region:
#
# -3   4   2   2   2
# -4   4   3   3   4
# -5   3   3   4  -4
#  4   3   3   4  -3
#  3   3   3  -5  -1
# What is the X,Y coordinate of the top-left fuel cell of the 3x3 square with the largest total power?


def part_one():

   grid = generate_grid(300, 8199)
   grid_with_values = calculate_power_in_grid_squares(grid)

   [maxvalue, x, y] = find_highest_value(grid_with_values)

   print("The highest value is ", maxvalue, "and it can be found at x:", x + 1, "and y:", y + 1)












#part_one()


def part_one_test():

    grid = generate_grid(200, 18)

    grid_with_values = calculate_power_in_grid_squares(grid)

    for row in grid_with_values:
        print(row)

    [maxvalue, x, y] = find_highest_value(grid_with_values)

    # print("Power_values", grid_with_values)
    if x != 33 or y != 45:
        print("Error")

    print("The highest value is ", maxvalue, "and it can be found at x:", x +1, "and y:", y + 1)

    print("The cell at pos 3,5 has power:", grid[3][5])

    grid = generate_grid(200, 42)

    grid_with_values = calculate_power_in_grid_squares(grid)

    for row in grid_with_values:
        print(row)

    [maxvalue, x, y] = find_highest_value(grid_with_values)

    # print("Power_values", grid_with_values)
    if x != 21 or y != 61:
        print("Error")

    print("The highest value is ", maxvalue, "and it can be found at x:", x +1, "and y:", y + 1)

part_one_test()
