// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

addEventToQuantityElements();

function addEventToQuantityElements() {
    let elements = document.querySelectorAll(".quantity");

    for (let element of elements) {
        element.setAttribute("onchange","countElementCost(this)")
    }
}

function countElementCost(quantity) {
    console.log(quantity.value)
    document.querySelector("#totalPrice" + quantity.id).textContent = parseInt(document.querySelector("#unitPrice" + quantity.id).textContent) * parseInt(quantity.value) ;
}

