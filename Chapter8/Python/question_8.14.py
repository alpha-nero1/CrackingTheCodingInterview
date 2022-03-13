str_to_bool = lambda st : True if st == '1' else False


def count_eval(expr, bool_res):
    parenthesised = ''
    if (len(expr) == 0): return 0
    if (len(expr) == 1): return 1 if str_to_bool(expr) == bool_res else 0

    ways = 0
    i = 1
    while (i < len(expr)):
        char = expr[i]
        left = expr[0:i]
        right = expr[(i + 1):len(expr)]

        left_true = count_eval(left, True)
        left_false = count_eval(left, False)
        i += 2

    return parenthesised

print(count_eval('0^0&0^1|1'))