//todo: Flag-based logic should be removed. Redo it later!!!!

async function isCalculatorStateIsEnabledAsync() {

    let state = document.getElementById('calculator-state-id');
    let value = state.value;
    if (value == "enable") {
        return true
    }
    return false;
}

async function isCalculatorStateIsErrorAsync() {

    let state = document.getElementById('calculator-state-id');
    let value = state.value;
    if (value == "error") {
        return true
    }
    return false;
}

async function setValueToCalculatorStateAsync(value) {

    let state = document.getElementById('calculator-state-id');
    state.value = value;
}

async function setEnableToCalculatorStateAsync() {

    await setValueToCalculatorStateAsync("enable");
}

async function setErrorToCalculatorStateAsync() {

    await setValueToCalculatorStateAsync("error");
}

async function setResultToCalculatorStateAsync() {

    await setValueToCalculatorStateAsync("result");
}