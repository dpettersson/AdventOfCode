import sys



def load_data_from_file():
    input_file = open("testdata.txt", "r")
    input_data = input_file.readline().split(" ")
    input_file.close()

    return input_data


def parse_child(child_data):
    pos = 0
    metadata_sum = 0

    if len(child_data) != 0:

        child_count = child_data[0]
        metadata_length = child_data[1]

        print("Next child:")
        print("Child count:", child_count)
        print("child_data: ", metadata_length)

        child_no = 0

        while child_no < int(child_count):

            [length_consumed, meta_data_acc] = parse_child(child_data[2 + pos:])

            pos = pos + length_consumed
            metadata_sum = meta_data_acc + metadata_sum
            print("Metadata_sum:", metadata_sum)

            child_no = child_no + 1

        pos = pos + 2
        child_metadata = child_data[pos:pos + int(metadata_length)]
        pos = pos + int(metadata_length)

        for meta in child_metadata:
            metadata_sum = metadata_sum + int(meta)

    return [pos, metadata_sum]


def generate_nodes(child_data):

    children = []
    metadata = []
    consumed_length_acc = 0

    if len(child_data) != 0:
        child_count = int(child_data[0])
        metadata_length = int(child_data[1])
        consumed_length_acc = consumed_length_acc + 2 + metadata_length

        if child_count == 0:
            metadata = child_data[2:2 + metadata_length]

        else:
            consumed_length = 0
            child_no = 0

            while child_no < child_count:

                new_child, consumed_length = generate_nodes(child_data[2 + consumed_length:])

                children.append(new_child)
                consumed_length_acc = consumed_length_acc + consumed_length
                child_no = child_no + 1

            metadata = child_data[consumed_length_acc- metadata_length:consumed_length_acc + metadata_length]

        return [[metadata, children], consumed_length_acc]


def climb(tree):

    if len(tree) != 0:

        metas = tree[0]
        print("metas:", metas)
        children = tree[1]
        print("Children:", children)

        if len(children) == 0:
            child_sum = sum(map(int, metas))
            print("returns:", child_sum)
            return child_sum
        else:

            meta_sum = 0
            for meta in metas:
                if int(meta) > 0 and  int(meta) < len(children):
                    meta_sum = meta_sum + int(climb(children[int(meta) - 1]))

            return meta_sum


#
# --- Day 8: Memory Maneuver ---
# The sleigh is much easier to pull than you'd expect for something its weight.
# Unfortunately, neither you nor the Elves know which way the North Pole is from here.
#
# You check your wrist device for anything that might help.
# It seems to have some kind of navigation system! A
# ctivating the navigation system produces more bad news: "Failed to start navigation system.
# Could not read software license file."
#
# The navigation system's license file consists of a list of numbers (your puzzle input).
# The numbers define a data structure which, when processed, produces some kind of tree that can be used to c
# alculate the license number.
#
# The tree is made up of nodes; a single, outermost node forms the tree's root,
# and it contains all other nodes in the tree (or contains nodes that contain nodes, and so on).
#
# Specifically, a node consists of:
#
# A header, which is always exactly two numbers:
# The quantity of child nodes.
# The quantity of metadata entries.
# Zero or more child nodes (as specified in the header).
# One or more metadata entries (as specified in the header).
# Each child node is itself a node that has its own header, child nodes, and metadata. For example:
#
# 2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2
# A----------------------------------
#     B----------- C-----------
#                      D-----
# In this example, each node of the tree is also marked with an underline starting with a letter for
# easier identification. In it, there are four nodes:
#
# A, which has 2 child nodes (B, C) and 3 metadata entries (1, 1, 2).
# B, which has 0 child nodes and 3 metadata entries (10, 11, 12).
# C, which has 1 child node (D) and 1 metadata entry (2).
# D, which has 0 child nodes and 1 metadata entry (99).
# The first check done on the license file is to simply add up all of the metadata entries.
# In this example, that sum is 1+1+2+10+11+12+2+99=138.
#
# What is the sum of all metadata entries?


def part_one():

    license_data = load_data_from_file()
    [_, metadata_sum] = parse_child(license_data)
    print("The metadata sums up to ", metadata_sum)

# --- Part Two ---
# The second check is slightly more complicated:
# you need to find the value of the root node (A in the example above).
#
# The value of a node depends on whether it has child nodes.
#
# If a node has no child nodes, its value is the sum of its metadata entries.
# So, the value of node B is 10+11+12=33, and the value of node D is 99.
#
# However, if a node does have child nodes, the metadata entries become indexes which refer to
# those child nodes. A metadata entry of 1 refers to the first child node, 2 to the second,
# 3 to the third, and so on.
# The value of this node is the sum of the values of the child nodes referenced by the metadata entries.
# If a referenced child node does not exist, that reference is skipped. A child node can be referenced multiple
# time and counts each time it is referenced. A metadata entry of 0 does not refer to any child node.
#
# For example, again using the above nodes:
#
# Node C has one metadata entry, 2. Because node C has only one child node, 2 references a child node
# which does not exist, and so the value of node C is 0.
# Node A has three metadata entries: 1, 1, and 2. The 1 references node A's first child node, B, and the 2
# references node A's second child node, C.
# Because node B has a value of 33 and node C has a value of 0, the value of node A is 33+33+0=66.
# So, in this example, the value of the root node is 66.
#
# What is the value of the root node?


def part_two():
    import sys
    x = 1500
    sys.setrecursionlimit(x)

    license_data = load_data_from_file()
    tree = generate_nodes(license_data)

    print("Tree", tree)

    print("The value of the root node is:", climb(tree[0]))


#part_one()
part_two()








