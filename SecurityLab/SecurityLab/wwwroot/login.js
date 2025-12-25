const loginForm = document.getElementById('loginForm');
const otpForm = document.getElementById('otpForm');

if (loginForm) {
    loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const res = await fetch('/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                email: document.getElementById('loginEmail').value,
                password: document.getElementById('loginPassword').value
            })
        });
        const data = await res.text();
        document.getElementById('loginMessage').innerText = data;
        if (res.ok) {
            loginForm.style.display = 'none';
            otpForm.style.display = 'block';
        }
    });
}

if (otpForm) {
    otpForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const res = await fetch('/api/auth/confirm-login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                email: document.getElementById('loginEmail').value,
                otp: document.getElementById('otp').value
            })
        });
        const data = await res.text();
        document.getElementById('loginMessage').innerText = data;
        if (res.ok) {
            setTimeout(() => {
                alert("Login успешен! Пренасочување на почетна страна...");
                window.location.href = "/index.html";
            }, 1000);
        }
    });
}
