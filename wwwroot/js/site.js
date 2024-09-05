// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    let quantity = document.querySelector('.quantity');
    let cartItemCount = document.getElementById('cartItemCount').value;
    quantity.textContent = parseInt(cartItemCount, 10);
});
function showPopup(productId) {
    // Set the value of the hidden input field with the product ID
    document.getElementById('productId').value = productId;
    // Display the popup
    document.getElementById('quantityPopup').style.display = 'flex';
}

function closePopup() {
    // Hide the popup by setting its display style to 'none'
    document.getElementById('quantityPopup').style.display = 'none';
}

