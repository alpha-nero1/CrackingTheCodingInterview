class Board():

    def __init__(self, size):
        self.locations = [[None] * size] * size
        self.__circle_location(4, 4)

    def __check_pos(self, x, y):
        print()

    def __move_x(self, x, y, pos):
        ret_array = [x, y, False]
        print('aa hey', x, (x + pos))        
        for i in range(x, (x + pos)):
            print('x', i)
            # Check status of position
            self.__check_pos(i, y)
            ret_array[0] = i
        return ret_array

    def __move_y(self, x, y, pos):
        ret_array = [x, y, False]

        for i in range(y, (y + pos)):
            print('y', i)
            # Check status of position
            self.__check_pos(x, i)
            ret_array[1] = i
        return ret_array

    def __move_right(self, x, y, pos):
        return self.__move_x(x, y, pos)

    def __move_down(self, x, y, pos):
        return self.__move_y(x, y, pos)

    def __move_left(self, x, y, pos):
        print('hey', x, y, pos * -1)
        return self.__move_x(x, y, (pos * -1))

    def __move_up(self, x, y, pos):
        print('hey 2', x, y, pos * -1)
        return self.__move_y(x, y, (pos * -1))

    def __circle_location(self, x, y, layer = 1):
        item = self.locations[x][y]
        if (layer == 4): return
        print('circling ', x, y)
        # 8, 16, 24
        items_multiplier = 8
        total_layer_items = layer * items_multiplier
        # Do the circle!
        # Start at the left most top element.
        start_point_x = x + (layer * -1)
        start_point_y = y + (layer * -1)

        side_length = int(total_layer_items / 4)
        print(side_length)
        right = self.__move_right(start_point_x + 1, start_point_y, side_length)
        down = self.__move_down(right[0], right[1], side_length)
        left = self.__move_left(down[0], down[1], side_length)
        up = self.__move_up(left[0], left[1], side_length)

        has_empty = right[2] and down[2] and left[2] and up[2]

        return self.__circle_location(x, y, layer + 1) if has_empty else True


board = Board(8)

for i in range(5, 3):
    print('aa h', i)