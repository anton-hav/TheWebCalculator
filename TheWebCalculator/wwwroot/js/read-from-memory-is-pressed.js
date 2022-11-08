async function readNumberFromMemoryOnServer(memory) {
    let url = new URL(`${window.location.origin}/ClientServerCalculator/ReadFromMemory`),
        params = { memory: memory };

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    let response = await fetch(url);
    return await response.json();
}

async function readNumberFromMemoryAsync() {

    let memory = await getValueFromMemoryStorageAsync();
    let newData = await readNumberFromMemoryOnServer(memory);
    if (newData.displayMessage == null) {
        await setValueToInputDisplayAsync(newData.memory);
    }
    else {
        await showError(newData);
    }

}

    function readNumberFromMemory() {
        (async () => await readNumberFromMemoryAsync())();
}