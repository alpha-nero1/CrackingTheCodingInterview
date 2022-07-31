"""
    17.25. Word Rectangle
"""

words_input = [
    'hello',
    'helix',
    'aspro',
    'trees',
    'smoke',
    'cigar',
    'purse',
    'hairs'
]

class Rectangle():
    height = None
    length = None
    matrix = []

    def __init__(self, length):
        self.length = length
        self.height = 0

    @staticmethod
    def from_letters(length, height, letters):
        rect = Rectangle(length)
        rect.height = len(letters)
        rect.matrix = letters
        return rect

    def get_letter(self, i, j): return self.matrix[i][j]


def make_partial_rectangle():
    print()

def make_rectangle(length, height):
    print()

def max_rectangle(words):
    sorted_words = sorted(words)
    longest_word = sorted_words[1:]
    length_longest = len(longest_word)
    rect_max = longest_word ^ 2

    for z in range(length_longest, 0, -1):
        for i in range(1, length_longest):
            if (z % i == 0):
                j = z / i
                if (j <= length_longest):
                    # Create a rectangle of length i and height j, i * j = z
                    rectangle = make_rectangle(i, j)
                    if (rectangle != None): return rectangle

    return None



max_rectangle(words_input)