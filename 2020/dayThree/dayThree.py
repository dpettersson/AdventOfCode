input_file = open("input.txt", "r")
data = input_file.read().splitlines()

test_data = ["..##.......",
             "#...#...#..",
             ".#....#..#.",
             "..#.#...#.#",
             ".#...##..#.",
             "..#.##.....",
             ".#.#.#....#",
             ".#........#",
             "#.##...#...",
             "#...##....#",
             ".#..#...#.#"]

# --- Day 3: Toboggan Trajectory ---
# With the toboggan login problems resolved, you set off toward the airport.
# While travel by toboggan might be easy, it's certainly not safe: there's very minimal
# steering and the area is covered in trees. You'll need to see which angles will take you near the fewest trees.
#
# Due to the local geology, trees in this area only grow on exact integer coordinates in a grid.
# You make a map (your puzzle input) of the open squares (.) and trees (#) you can see. For example:
#
# ..##.......
# #...#...#..
# .#....#..#.
# ..#.#...#.#
# .#...##..#.
# ..#.##.....
# .#.#.#....#
# .#........#
# #.##...#...
# #...##....#
# .#..#...#.#
# These aren't the only trees, though; due to something you read about once involving arboreal genetics and
# biome stability, the same pattern repeats to the right many times:
#
# ..##.........##.........##.........##.........##.........##.......  --->
# #...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
# .#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
# ..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
# .#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
# ..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....  --->
# .#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
# .#........#.#........#.#........#.#........#.#........#.#........#
# #.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...
# #...##....##...##....##...##....##...##....##...##....##...##....#
# .#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
# You start on the open square (.) in the top-left corner and need to reach the bottom (below the bottom-most
# row on your map).
#
# The toboggan can only follow a few specific slopes (you opted for a cheaper model that prefers rational numbers);
# start by counting all the trees you would encounter for the slope right 3, down 1:
#
# From your starting position at the top-left, check the position that is right 3 and down 1. Then, check the
# position that is right 3 and down 1 from there, and so on until you go past the bottom of the map.
#
# The locations you'd check in the above example are marked here with O where there was an open square and X where
# there was a tree:
#
# ..##.........##.........##.........##.........##.........##.......  --->
# #..O#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
# .#....X..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
# ..#.#...#O#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
# .#...##..#..X...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
# ..#.##.......#.X#.......#.##.......#.##.......#.##.......#.##.....  --->
# .#.#.#....#.#.#.#.O..#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
# .#........#.#........X.#........#.#........#.#........#.#........#
# #.##...#...#.##...#...#.X#...#...#.##...#...#.##...#...#.##...#...
# #...##....##...##....##...#X....##...##....##...##....##...##....#
# .#..#...#.#.#..#...#.#.#..#...X.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
# In this example, traversing the map using this slope would cause you to encounter 7 trees.
#
# Starting at the top-left corner of your map and following a slope of right 3 and down 1, how many trees
# would you encounter?

def day_three_part_one(data):
    x_pos = 0

    line_width = len (data[0])
    tree_count = 0
    x_step = 3

    for line in data:
        current_pos = x_pos % line_width

        if line[current_pos] == '#':
            tree_count = tree_count + 1
        x_pos = x_pos + x_step

    print("Found " + str(tree_count) + " trees")
    return tree_count


# --- Part Two ---
# Time to check the rest of the slopes - you need to minimize the probability of a sudden arboreal stop, after all.
#
# Determine the number of trees you would encounter if, for each of the following slopes, you start at the
# top-left corner and traverse the map all the way to the bottom:
#
# Right 1, down 1.
# Right 3, down 1. (This is the slope you already checked.)
# Right 5, down 1.
# Right 7, down 1.
# Right 1, down 2.
# In the above example, these slopes would find 2, 7, 3, 4, and 2 tree(s) respectively; multiplied together,
# these produce the answer 336.
#
# What do you get if you multiply together the number of trees encountered on each of the listed slopes?

def day_three_part_two(data, x_step, y_step):
    x_pos = 0
    current_line_no = 0

    line_width = len(data[0])
    tree_count = 0

    while current_line_no < len(data):
        current_pos = x_pos % line_width

        if data[current_line_no][current_pos] == '#':
            tree_count = tree_count + 1

        x_pos = x_pos + x_step
        current_line_no = current_line_no + y_step

    print("Found " + str(tree_count) + " trees")
    return tree_count


# assert day_three_part_one(test_data) == 7
# day_three_part_one(data)


# assert day_three_part_two(test_data, 1, 1) == 2
# assert day_three_part_two(test_data, 3, 1) == 7
# assert day_three_part_two(test_data, 5, 1) == 3
# assert day_three_part_two(test_data, 7, 1) == 4
# assert day_three_part_two(test_data, 1, 2) == 2

num1 = day_three_part_two(data, 1, 1)
num2 = day_three_part_two(data, 3, 1)
num3 = day_three_part_two(data, 5, 1)
num4 = day_three_part_two(data, 7, 1)
num5 = day_three_part_two(data, 1, 2)

print("Slope 1 gives " + str(num1))
print("Slope 2 gives " + str(num2))
print("Slope 3 gives " + str(num3))
print("Slope 4 gives " + str(num4))
print("Slope 5 gives " + str(num5))

print("The result is: " + str(num1 * num2 * num3 * num4 * num5))

