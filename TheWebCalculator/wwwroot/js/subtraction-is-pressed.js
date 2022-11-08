async function getCalculatedDataFromServerWithAddSubtraction(previousValue, currentValue, operation) {
    let url = new URL(`${window.location.origin}/ClientServerCalculator/AddSubtractionOperation`),
        params = { previousNumber: previousValue, currentNumber: currentValue, operation: operation };

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    let response = await fetch(url);
    return await response.json();
}

async function addSubtractionOperationAsync() {

    let displayValue = await getValueFromInputDisplayAsync();
    let [placeholderValue, operation] = await getValueFromPlaceholderDisplayAsync();
    let operationName = await getOperationStringNameBySymbol(operation);
    let newData = await getCalculatedDataFromServerWithAddSubtraction(placeholderValue, displayValue, operationName);


    if (newData.displayMessage == null) {
        await showResult(newData);
    }
    else {
        await showError(newData);
    }
}

function addSubtractionOperation() {
    (async () => await addSubtractionOperationAsync())();
}

