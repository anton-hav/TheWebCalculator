async function getValueFromMemoryStorageAsync() {

    let display = document.getElementById('memory-storage-id');
    let value = display.value;
    return value;
}

async function setValueToMemoryStorageAsync(value) {

    let display = document.getElementById('memory-storage-id');
    display.value = value;
}

async function cleanMemoryStorage() {
    let display = document.getElementById('memory-storage-id');
    display.value = "0";
}