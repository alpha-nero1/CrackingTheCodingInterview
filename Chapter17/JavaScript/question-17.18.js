// Entry function.
const shortestSubsequence = (bigArr, smallArr) => {
    // Build the next elements array.
    const nextElements = buildAllNextElements(bigArr, smallArr);
    // Get the closures, closures indicate the max position of the next element present
    const closures = getClosures(nextElements);
    return getShortestClosure(closures);
}

const buildAllNextElements = (bigArr, smallArr) => {
    const nextElements = [[]];
    for (let i = 0; i < smallArr.length; i++) {
        if (nextElements.length <= i) nextElements.push([]);
        nextElements[i] = buildNextElementsArray(bigArr, smallArr[i]);
    }
    console.log('Next elements')
    console.log(nextElements);
    return nextElements;
}

// Crawl the big array backwards recording points where the next of the given value is,
// pretty clever!
const buildNextElementsArray = (bigArr, value) => {
    let next = -1;
    const nexts = [];
    for (let i = bigArr.length - 1; i > -1; i--) {
        if (bigArr[i] === value) next = i;
        nexts.unshift(next);
    }
    return nexts;
}

const getClosures = (nextElements) => {
    const maxNextElement = [];
    for (let i = 0; i < nextElements[0].length; i++) {
        maxNextElement.push(getClosureForIndex(nextElements, i));
    }
    console.log('Closures')
    console.log(maxNextElement)
    return maxNextElement;
}

const getClosureForIndex = (nextElements, index) => {
    let max = -1;
    for (let i = 0; i < nextElements.length; i++) {
        if (nextElements[i][index] === -1) return -1;
        max = Math.max(max, nextElements[i][index]);
    }
    return max;
}

// Further study this function.
const getShortestClosure = (closures) => {
    let bestStart = -1;
    let bestEnd = -1;

    for (let i = 0; i < closures.length; i++) {
        if (closures[i] === -1) break;
        const current = closures[i] - i;
        if (bestStart === -1 || current < (bestEnd - bestStart)) {
            bestStart = i;
            bestEnd = closures[i];
        }
    }
    return [bestStart, bestEnd];
}


const res = shortestSubsequence(
    [7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 8, 9, 7],
    [1, 5, 9]
);

console.log(res);