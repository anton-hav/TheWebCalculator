async function getCalculatedDataFromServerWithAddCalculate(previousValue, currentValue, operation) {
    let url = new URL(`${window.location.origin}/ClientServerCalculator/CalculateExpression`),
        params = { previousNumber: previousValue, currentNumber: currentValue, operation: operation };

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    let response = await fetch(url);
    return await response.json();
}

async function addCalculateOperationAsync() {

    let displayValue = await getValueFromInputDisplayAsync();
    let [placeholderValue, operation] = await getValueFromPlaceholderDisplayAsync();
    let operationName = await getOperationStringNameBySymbol(operation);
    let newData = await getCalculatedDataFromServerWithAddCalculate(placeholderValue, displayValue, operationName);

    if (newData.displayMessage == null) {
        await showResult(newData);
    }
    else {
        await showError(newData);
    }
}

function addCalculateOperation() {
    (async () => await addCalculateOperationAsync())();
}

