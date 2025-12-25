const confirmForm = document.getElementById('confirmForm');

if (confirmForm) {
    confirmForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const res = await fetch('/api/auth/confirm-registration', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                email: document.getElementById('confirmEmail').value,
                otp: document.getElementById('confirmOtp').value
            })
        });
        const data = await res.text();
        document.getElementById('confirmMessage').innerText = data;
        if (res.ok) {
            setTimeout(() => {
                window.location.href = "/login.html";
            }, 1000);
        }
    });
});
