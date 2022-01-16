# ^ results to true if one and only one of the opperands evaluates to true.
# ^ is a XOR
print('-- XOR --')
print('Binary XOR operator copies the bit if is set in one operand but not both.')
print('0 ^ 0: ', 0 ^ 0)
print('1 ^ 1: ', 1 ^ 1)
print('1 ^ 0: ', 1 ^ 0)
print('0 ^ 1: ', 0 ^ 1)

print('\n-- AND --')
print('Binary AND operator copies the bit if is set in both operands.')
print('0 & 0: ', 0 & 0)
print('1 & 1: ', 1 & 1)
print('1 & 0: ', 1 & 0)
print('0 & 1: ', 0 & 1)

print('\n-- OR --')
print('Binary OR operator copies the bit if is set in either operands.')
print('0 | 0: ', 0 | 0)
print('1 | 1: ', 1 | 1)
print('1 | 0: ', 1 | 0)
print('0 | 1: ', 0 | 1)

print('\n-- Ones Complement --')
print('Binary One\'s Complement Operator is unary and has the effect of \'flipping\' bits.')
print('~1', ~1)
print('~0', ~0)
print('~9', ~9)
print('~6', ~6)

print('\n-- Shift Operators --')
print('-- Left Shift --')
print('All values in left operand are shifted left by n places.')
print('This doubles the number.')
print('1 << 1', 1 << 1)
print('2 << 1', 2 << 1)
print('5 << 1', 5 << 1)

print('\n-- Right Shift --')
print('All values in left operand are shifted right by n places.')
print('This halvs the number (note halving an odd number will result in the rouded down half).')
print('1 >> 1', 1 >> 1)
print('2 >> 1', 2 >> 1)
print('5 >> 1', 5 >> 1)


# Printing numbers in binary string format using :03b
print('\n-- Formatting --')
print("{:03b}".format(8))
print("{:03b}".format(10))
print("{:03b}".format(10 ^ 8))
