class BitUtils {
  // Operations inspired by: https://www.tutorialspoint.com/convert-an-array-of-binary-numbers-to-corresponding-integer-in-javascript
  
  /**
   * Get a bit at position. Trick is to use AND!
   *
   * @param { Number } integer integer value.
   * @param { Number } pos position of bit to get.
   */
  static GetBit(integer, pos) {
    // Shifts 1 over to pos. We then and with this to get the bit.
    return integer & (1 << pos);
  }

  /**
   * Set a bit in an int. Trick for Set is to use OR!
   * 
   * @param { Number } integer integer value.
   * @param { Number } pos position of bit.
   * @param { Number } value value bit should be.
   */
  static SetBit(integer, pos, value = 1) {
    return integer | (value << pos)
  }

  /**
   * Clear the bit at position. Trick use an AND of the negated value.
   *
   * @param { Number } integer integer value.
   * @param { Number } pos position of bit to clear.
   */
  static ClearBit(integer, pos) {
    const mask = ~(1 << pos); // opposite of 00001000 for instance (11110111).
    // We get this "all 1s" from the mask negation.
    return integer & mask;
  }

  /**
   * Update a bit in integer at position pos to value.
   *
   * @param { Number } integer integer value.
   * @param { Number } pos position of bit to clear.
   * @param { Number } value new bit value.
   */
  static UpdateBit(integer, pos, value) {
    const mask = ~(1 << pos); // The mask to clear!
    return (integer & mask) | (value << pos); // or the (integer & mask) to the value we want to set!
  }

  /**
   * Clear the bits from the highest bit to "pos".
   *
   * @param { Number } integer integer value.
   * @param { Number } pos position value.
   */
  static ClearBitsFromMostSignificantBitToPos(integer, pos) {
    const mask = (1 << pos) - 1; // gives us a sequence of 0s followed by ones after pos.
    // Trick: -1 in binary is represented in ALL ones! -1 = 11111111
    return integer & mask; // Anding then clears those bigger bits through to pos.
  }

  /**
   * Clear the bits from position to 0.
   *
   * @param { Number } integer integer value.
   * @param { Number } pos position value.
   */
  static ClearBitsFromPosToLeastSignificant(integer, pos) {
    const mask = (-1 << (pos + 1)); // get a sequence of all 1s and shift it left leaving
    // an opening for our clearing 0s.
    // e.g 11111111 << 4 = 11110000
    return integer & mask;
  }

  /**
   * Convert binary representation string to int.
   *
   * @param { String } binaryStr string to convert.
   */
  static BinaryToInt(binaryStr) {
    if (binaryStr) {
      let accValue = 0;
      // Iterate the binary string and create our accumulated value.
      for (let i = 0; i < binaryStr.length; i++) {
        // Shift the acc value left by 1 bit on each loop
        // and OR with the current binary value to insert it.
        // Oh thats ffin' cheeky!
        accValue = (accValue << 1) | +binaryStr[i];
      }
      return accValue;
    }
    return null;
  }
  
  /**
   * Convert an integer to binary string representation.
   *
   * @param { Number } integer integer to convert.
   */
  static IntToBinary(integer) {
    // The unsigned bitwise >>> shifts elements to the right.
    // Doing >>> by 0 will coerce the value to an unsigned int binary representation
    // of the negative value.
    return (integer >>> 0).toString(2);
  }
}

module.exports = { BitUtils }