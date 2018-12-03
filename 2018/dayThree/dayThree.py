
def part_one():
    fabric = [[0 for x in range(1000)] for y in range(1000)]

    overlaps = 0

    input_file = open("input.txt", "r")

    claims = input_file.readlines()

    input_file.close()

    for line in claims:

        [_, _, start_coordinates, size_of_claim] = line.split()

        start_coordinates = start_coordinates[:-1]

        [start_x, start_y] = start_coordinates.split(',')

        [width, height] = size_of_claim.split('x')

        for w in range(int(width)):

            for h in range(int(height)):
                fabric[w + int(start_x)][h + int(start_y)] = fabric[w + int(start_x)][h + int(start_y)] + 1

    for line in fabric:

        for x in line:

            if int(x) > 1:
                overlaps = overlaps + 1

    print("Number of overlaps is: ", overlaps)


def part_two():

    fabric_size = 1000

    input_file = open("input.txt", "r")
    claims = input_file.readlines()

    fabric = [[0 for x in range(fabric_size)] for y in range(fabric_size)]
    input_file.close()

    claim_area = [[0 for x in range(2)] for y in range(len(claims))]

    for line in claims:
        [claim_number_str, _, start_coordinates, size_of_claim] = line.split()

        claim_number = int(claim_number_str[1:])
        start_coordinates = start_coordinates[:-1]
        [start_x, start_y] = start_coordinates.split(',')

        [width, height] = size_of_claim.split('x')

        #print("setting claim no ", claim_number, " at position: ", claim_number - 1, " to ", int(width) * int(height))

        claim_area[claim_number - 1][0] = claim_number
        claim_area[claim_number - 1][1] = int(width) * int(height)

        for w in range(int(width)):
            for h in range(int(height)):
                if fabric[w + int(start_x)][h + int(start_y)] == 0:
                    fabric[w + int(start_x)][h + int(start_y)] = claim_number
                else:
                    fabric[w + int(start_x)][h + int(start_y)] = -1

   # print("Claim area: ", claim_area)
    #print("Fabric: ", fabric)

    for claim in claim_area:
        covered_area = 0
        for w in range(fabric_size):
            for h in range(fabric_size):
               # print("Checking pos: ", w, ":", h, "which contains ", fabric[w][h], " wanted: ", claim[0])
                if fabric[w][h] == claim[0]:
                    #print("Match found")
                    covered_area = covered_area + 1
        if claim[1] == covered_area:
            print("Claim no ", int(claim[0]), "at position: ", claim[0] - 1, " covers ", claim[1], "number of squares")
            print("complete claim found: ", claim[0])

            #print(claim_area)

            break




#part_one()
part_two()

