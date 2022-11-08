async function getCalculatedDataFromServerWithAddAddition(previousValue, currentValue, operation) {
    let url = new URL(`${window.location.origin}/ClientServerCalculator/AddAdditionalOperation`),
        params = { previousNumber: previousValue, currentNumber: currentValue, operation: operation };

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    let response = await fetch(url);
    return await response.json();
}

async function addAdditionOperationAsync() {

    let displayValue = await getValueFromInputDisplayAsync();
    let [placeholderValue, operation] = await getValueFromPlaceholderDisplayAsync();
    let operationName = await getOperationStringNameBySymbol(operation);
    let newData = await getCalculatedDataFromServerWithAddAddition(placeholderValue, displayValue, operationName);

    if (newData.displayMessage == null) {
        await showResult(newData);
    }
    else {
        await showError(newData);
    }
}

function addAdditionOperation() {
    (async () => await addAdditionOperationAsync())();
}

