// ----------------------
// Register
// ----------------------
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
        const data = await res.json(); // користиме JSON
        document.getElementById('registerMessage').innerText = data.message + (data.otp ? `\nOTP за тест: ${data.otp}` : '');
        if (res.ok) {
            setTimeout(() => {
                window.location.href = "/confirm.html";
            }, 1000);
        }
    });
}

// ----------------------
// Confirm Registration OTP
// ----------------------
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
        const data = await res.json();
        document.getElementById('confirmMessage').innerText = data.message || data;
        if (res.ok) {
            setTimeout(() => {
                window.location.href = "/login.html";
            }, 1000);
        }
    });
}

// ----------------------
// Login + OTP
// ----------------------
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
        const data = await res.json();
        document.getElementById('loginMessage').innerText = data.message + (data.otp ? `\nOTP за тест: ${data.otp}` : '');
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
        const data = await res.json();
        document.getElementById('loginMessage').innerText = data.message || data;
        if (res.ok) {
            setTimeout(() => {
                alert("Login successful! Redirecting to home...");
                window.location.href = "/index.html";
            }, 1000);
        }
    });
}
