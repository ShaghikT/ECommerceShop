import { event } from "jquery"

document.querySelectorAll('.add-to-cart').forEach(button => {
    button.addEventListener('click', asyncb(event) => {
        const productId = event.target.dataset.productId;
        const quantityInput = document.getElementById(`quantity-${productId}`);
        const quantity = quantityInput.value ;

        const response = await fetch(`/Cart/AddToCart`, {
            method: 'Post',
            headers: {
                'Content-Type': 'applcation/Json'
            },
            body: JSON.stringify({ productId, quantity })
        });

        if(response.ok)
    {
        const cart = await response.json();

        if (cart.updated) {
            alert('Product quantity updated in cart');
        }
        else {
            alert('Product added ro cart')
        }
    }

        else {
        alert("Failed to add product to cart");
    }
});
    
});

document.addEventListener("DomContentLoadede", () => {
    const removeButtons = document.querySelectorAll(".remove-from-cart");
    removeButtons.forEach((button) => {
        button.addEventListener("click", async (event) => {
            event.preventDefault();
            const productId = event.target.closest("tr").dataset.productId;
            const response = await fetch(`/cart/remove?productId = ${productId}`, {
                method: "Post"
            });

            if (response.ok) {
                //refresh the page or u[date the DOM dynamically
                location.reload();
            }
            else {
                alert("Failed to remove")
            }
        });
    });
});