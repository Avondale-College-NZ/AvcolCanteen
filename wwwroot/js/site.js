// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let openShopping = document.querySelector('.shopping');
let closeShopping = document.querySelector('.closeShopping');
let listCard = document.querySelector('.listCard');
let body = document.querySelector('body');
let total = document.querySelector('.total');
let quantity = document.querySelector('.quantity');

openShopping.addEventListener('click', () => {
    body.classList.add('active');
});

closeShopping.addEventListener('click', () => {
    body.classList.remove('active');
});

// Get all "Buy Now" buttons
let buyButtons = document.querySelectorAll('.product-btn');

// Initialize total price and quantity
let totalPrice = 0;
let totalQuantity = 0;

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
        <div style="margin-right:10px">
        ${productName}
        </div>
        <div style="margin-right:10px">
        $${productPrice}
        </div>
      <div style="margin-right:10px">
        <button class="remove-btn">
          <img src="/Images/delete.svg" alt="Remove">
        </button>
      </div>
    `;

        // Append the new list item to the cart list
        listCard.appendChild(listItem);

        // Update total price and quantity
        totalPrice += productPrice;
        total.textContent = `$${totalPrice}`;
        totalQuantity++;
        quantity.textContent = totalQuantity;

        // Add event listener to the remove button
        let removeButton = listItem.querySelector('.remove-btn');
        removeButton.addEventListener('click', () => {
            listItem.remove(); // Remove the list item from the cart
            // Recalculate total price and quantity after removing the product
            totalPrice -= productPrice;
            total.textContent = `$${totalPrice}`;
            totalQuantity--;
            quantity.textContent = totalQuantity;
        });
    });
});
$('.dropdown-el').click(function (e) {
    e.preventDefault();
    e.stopPropagation();
    $(this).toggleClass('expanded');
    $('#' + $(e.target).attr('for')).prop('checked', true);
});
$(document).click(function () {
    $('.dropdown-el').removeClass('expanded');
});