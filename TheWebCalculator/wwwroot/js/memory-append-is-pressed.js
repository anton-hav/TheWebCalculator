async function validateDataAndAddNumberToMemory(currentValue, memory) {
    let url = new URL(`${window.location.origin}/ClientServerCalculator/AddCurrentNumberToMemory`),
        params = { currentNumber: currentValue, memory: memory };

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    let response = await fetch(url);
    return await response.json();
}

    async function appendNumberToMemoryAsync() {

    let displayValue = await getValueFromInputDisplayAsync();
    let isStateError = await isCalculatorStateIsErrorAsync();
    if (!isStateError) {
        let memory = await getValueFromMemoryStorageAsync();
        let newData = await validateDataAndAddNumberToMemory(displayValue, memory);
        if (newData.displayMessage == null) {
            await setValueToMemoryStorageAsync(newData.memory);
        }
        else {
            await showError(newData);
        }
    }
}

    function appendNumberToMemory() {
        (async () => await appendNumberToMemoryAsync())();
}