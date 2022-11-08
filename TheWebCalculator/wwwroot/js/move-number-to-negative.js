async function showNegativeNumberOnDisplayAsync() {

    let value = await getValueFromInputDisplayAsync();
    let newValue;
    if (value == "0") {
        newValue = digit;
    }
    else {
        newValue = -value;
    }

    await setValueToInputDisplayAsync(newValue);
}

function showNegativeNumberOnDisplay() {
    (async () => await showNegativeNumberOnDisplayAsync())();
}