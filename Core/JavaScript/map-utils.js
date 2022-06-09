const mapToArray = (map) => {
    const ret = [];
    if (!map) return ret;

    map.forEach((value, key) => {
        ret.push([key, value]);
    })
    return ret;
}