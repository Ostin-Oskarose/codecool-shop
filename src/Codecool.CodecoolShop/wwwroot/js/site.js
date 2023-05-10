let cartCounter = document.querySelector('#cart-items-counter');

if (cartCounter != null) {
    fetch("/api/CartApi/GetAmountOfCartItems")
        .then(res => res.json())
        .then(data => cartCounter.innerText = data)
}