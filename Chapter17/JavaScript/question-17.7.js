// From core.
const mapToArray = (map) => {
    const ret = [];
    if (!map) return ret;

    map.forEach((value, key) => {
        ret.push([key, value]);
    })
    return ret;
}

// Both inputs are 2d arrays.
const findTrueNameFreqs = (nameFreqsArr, synonymsArr) => {
    const nameFreqs = new Map(nameFreqsArr);
    const synonyms = new Map(synonymsArr);
    
    return (() => {
        // Keep track of what names have been counted with a set.
        const counted = new Set();
        // True count we will later return.
        const trueCount = new Map();

        // Build synonym map.
        nameFreqs.forEach((count, name) => {
            const syn = synonyms.get(name)
            // If there is no synonym we can just add to the true count directly.
            if (!syn) {
                trueCount.set(name, count);
                return;
            }

            // Get the count of the synonym and combined
            const synCount = nameFreqs.get(syn) ?? 0;
            const combined = synCount + count;

            console.log(name, syn, count, synCount, combined, counted)

            // If the current name has not yet been counted.
            if (!counted.has(name)) 
            {
                // Calculate what the total count will be.
                const countTouse = counted.has(syn) ? count : combined;
                
                // Set the true count to be this name and delete the synonym.
                trueCount.set(name, countTouse);
                trueCount.delete(syn)
                // This is the new name for the group.
                // if (combined !== count) counted.add(name);
                counted.add(syn);

            }
        });
        return mapToArray(trueCount);
    })();
}

console.log(findTrueNameFreqs(
    [
        ['Jonny', 10],
        ['Jon', 3],
        ['Davis', 2],
        ['Kari', 3],
        ['Johnny', 11],
        ['Carlton', 8],
        ['Carleton', 2],
        ['Jonathan', 9],
        ['Cartrie', 5],
    ],
    [
        ['Jonathan', 'John'],
        ['Jon', 'Jonny'],
        ['Jonny', 'Johnny'],
        ['Johnny', 'Jonny'],
        ['Kari', 'Carrie'],
        ['Carleton', 'Carlton'],
    ]
));