// This is your test publishable API key.
const stripe = new Stripe('pk_test_51PJHNSE0AQaB4GOLSda0kGPVJrEP2g3d1jTAhe0rBRlLLgsQFY0iwQkGkJKFobYFQnn4fid8Ti9b9r11qveYxG4F00xzAgzuHq');

initialize();

// Create a Checkout Session
async function initialize() {
  const fetchClientSecret = async () => {
    const response = await fetch("/create-checkout-session", {
      method: "POST",
    });
    const { clientSecret } = await response.json();
    return clientSecret;
  };

  const checkout = await stripe.initEmbeddedCheckout({
    fetchClientSecret,
  });

  // Mount Checkout
  checkout.mount('#checkout');
}