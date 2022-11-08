function adjastTextFontSize() {

    let input = document.getElementById('input-display')

    let length = input.textLength;
    
    if (length > 20) {

        let sizeRate = length - 20;
        input.style.fontSize = `${42 - sizeRate}px`;
    }
    else {
        input.style.fontSize = `42px`;
    }
}


(async () => {
    await adjastTextFontSize();
})();