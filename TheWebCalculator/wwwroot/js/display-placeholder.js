async function getValueFromPlaceholderDisplayAsync() {

    let placeholder = document.getElementById('placeholder-display');
    let items = placeholder.textContent.trim().split(/\s+/);;
    return items;
}

async function setValueToPlaceholderDisplayAsync(value, operation) {

    let placeholder = document.getElementById('placeholder-display');
    placeholder.innerHTML = `${value} ${operation}`;
    await triggerDisplayInputEventOnChange();
}

async function cleanDisplayPlaceholder() {
    let display = document.getElementById('placeholder-display');
    display.innerHTML = "";
}