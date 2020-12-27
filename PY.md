# Python

To run your python files exec `python3 <path_to_file>`

Notes on python.
- Python leans towards the use of global functions to calculate common things. E.g. `len(myArray)`, `range(0, 9) // for i loops`, `str(myNum) // casting...`
- The true and false values are capitalised e.g `True`, `False`
- Can make use of `for in` loops.
- An empty dictionary will evaluate to Falsy, to do checks for defined check `if variable is not None` `None` is the python equivalent of `undefined`
- py constructor = `def __init__(self):` and constructuon: `Dictionary()`
- to get index of for in loop you must use `for (idx, item) in enumerate(array)`
- to create array of fixed size note that `arr = [[]] * 10` will create and array of size 10 but all containing the SAME array ref.
- you can use lambda functions for easy filtering e.g. `filter(lambda chain: len(chain) > 0, self.__items)`
- Prefixing a func or var with `__` makes it private!!