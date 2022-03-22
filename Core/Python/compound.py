import sys

def compound(args):
    [_, starting_amount, compound_pa, anums] = args

    if (len(args) < 4):
        print('Insufficient arguments for calculation...')
        return 0

    amount = float(starting_amount)

    for _ in range(0, int(anums)):
        amount *= float(compound_pa)

    return "{:,}".format(round(amount, 2))



result = compound(sys.argv)
print()
print(f'starting amount ${"{:,}".format(float(sys.argv[1]))} invested at rate {sys.argv[2]} for {sys.argv[3]} terms = ${result}')
print()
