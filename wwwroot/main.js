const passwordBtn = document.getElementById("password-eye");
 
passwordBtn.addEventListener("click", (e) => {
    const passwordInput = document.getElementById("password");
    const icon = passwordBtn.querySelectorAll("i");

    const isVisible = (icon[0].innerText == "visibility");
    passwordInput.type = isVisible ? "password" : "text";
    icon[0].innerText = isVisible ? "visibility_off" : "visibility";
})