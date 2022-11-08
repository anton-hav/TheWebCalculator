async function cleanMemoryWithServer(memory) {
    let url = new URL(`${window.location.origin}/ClientServerCalculator/CleanMemory`),
        params = { memory: memory };

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    let response = await fetch(url);
    return await response.json();
}

async function cleanMemoryAsync() {

    let memory = await getValueFromMemoryStorageAsync();
    let newData = await cleanMemoryWithServer(memory);
    if (newData.displayMessage == null) {
        await setValueToMemoryStorageAsync(newData.memory);
    }
    else {
        await showError(newData);
    }

}

    function cleanMemory() {
        (async () => await cleanMemoryAsync())();
}