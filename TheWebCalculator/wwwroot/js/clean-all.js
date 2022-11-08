async function cleanAllAsync() {

    await cleanDisplayInput();
    await cleanDisplayPlaceholder();
    await triggerDisplayInputEventOnChange();
}

function cleanAll() {
    (async () => await cleanAllAsync())();
}