async function triggerItemEventOnChangeAsync(element) {

    // Add some checks for this
    element.onchange();
}

async function triggerDisplayInputEventOnChange() {

    let input = document.getElementById('input-display');
    await triggerItemEventOnChangeAsync(input);
}