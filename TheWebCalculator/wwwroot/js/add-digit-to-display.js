async function addDigitToDisplayAsync(digit) {
    
    let value = await getValueFromInputDisplayAsync();
    let newValue;
    if (value == "0") {
        newValue = digit;
        await setValueToInputDisplayAsync(newValue);
    }
    else {
        var isNumberValid = await checkValueForOverflow(value);
        if (isNumberValid) {
            newValue = value + digit;
            await setValueToInputDisplayAsync(newValue);
        }        
    }

    
}

async function checkValueForOverflow(value) {
    const maxValue = 1e27;

    if (Number(value) >= maxValue || Number(value) <= -maxValue) return false;

    return true;
}

function addDigitToDisplay(digit) {
    (async () => await addDigitToDisplayAsync(digit))();
}