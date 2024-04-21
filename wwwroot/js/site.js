// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let openShopping = document.querySelector('.shopping');
let closeShopping = document.querySelector('.closeShopping');
let list = document.querySelector('.list');
let listCard = document.querySelector('.listCard');
let body = document.querySelector('body');
let total = document.querySelector('.total');
let quantity = document.querySelector('.quantity');

openShopping.addEventListener('click', () => {
    body.classList.add('active');
})
closeShopping.addEventListener('click', () => {
    body.classList.remove('active');
})
// Get all "Buy Now" buttons
let buyButtons = document.querySelectorAll('.product-btn');

// Add event listener to each "Buy Now" button
buyButtons.forEach(button => {
    button.addEventListener('click', () => {
        // Get product details from the clicked button's parent element
        let productCard = button.closest('.product');
        let productInfo = productCard.querySelector('.product-info');
        let productName = productInfo.querySelector('.product-title').textContent;
        let productPrice = parseInt(productInfo.querySelector('.product-price').textContent.replace('$', ''));
        let productImageSrc = productCard.querySelector('img').src;

        // Create a new list item for the cart
        let listItem = document.createElement('li');
        listItem.innerHTML = `
            <div>
                <img src="${productImageSrc}" alt="${productName}">
            </div>
            <div>
                <div>${productName}</div>
                <div>$${productPrice}</div>
            </div>
        `;

        // Append the new list item to the cart list
        listCard.appendChild(listItem);

        // Update total price
        let currentTotal = parseInt(total.textContent.replace('$', ''));
        total.textContent = `$${currentTotal + productPrice}`;

        // Update quantity (optional)
        quantity.textContent = parseInt(quantity.textContent) + 1;
    });
});