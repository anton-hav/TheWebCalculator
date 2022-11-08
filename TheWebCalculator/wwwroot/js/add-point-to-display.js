async function addPointToDisplayAsync() {

    let display = document.getElementById('input-display');
    let value = display.value;
    let isPointExist = await isPointExistAsync(value);
    if (!isPointExist) {
        let newValue = "";
        if (value == 0) {
            newValue = "0."
        }
        else newValue = `${value}.`;
        display.value = newValue;
    }
}

async function isPointExistAsync(value) {
    if (value.includes(".")) return true;

    return false;
}

function addPointToDisplay() {
    (async () => await addPointToDisplayAsync())();
}