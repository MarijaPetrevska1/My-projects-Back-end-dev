const registerForm = document.getElementById('registerForm');

if (registerForm) {
    registerForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const res = await fetch('/api/auth/register', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                username: document.getElementById('username').value,
                email: document.getElementById('email').value,
                password: document.getElementById('password').value
            })
        });
        const data = await res.text();
        document.getElementById('registerMessage').innerText = data;
        if (res.ok) {
            setTimeout(() => {
                window.location.href = "/confirm.html";
            }, 1000);
        }
    });
});
