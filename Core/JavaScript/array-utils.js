// ;)
const fill2DArray = (width, height, el) => {
    const arr = [];
    let row = 0;
    let totalAmount = width * height;

    for (let i = 0; i < totalAmount; i++) {
        let col = i % width;
        if (row === 0) arr.push([]);
        arr[col].push(el);
        if (col === width - 1) {
            row += 1;
        }
    }
    return arr;
}

module.exports = { fill2DArray }