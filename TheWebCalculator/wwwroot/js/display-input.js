async function getValueFromInputDisplayAsync() {

    let display = document.getElementById('input-display');
    let value = display.value;
    return value;
}

async function setValueToInputDisplayAsync(value) {

    let display = document.getElementById('input-display');
    display.value = value;
    await triggerDisplayInputEventOnChange();
}

async function cleanDisplayInput() {
    let display = document.getElementById('input-display');
    display.value = "0";
}