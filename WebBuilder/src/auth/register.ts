import { http } from "../package/axios";
import { routerLinks, routers } from "../package/axios/routes";
import { ServerResponse } from "../package/interface/serverResponse";

interface RegisterUserDto {
        username: string;
        password: string;
        confirmPassword: string;
        name: string;
        phone: string;
        email: string;
        address: string;
}

const registerForm = document.getElementById("registerForm");
registerForm?.addEventListener("submit", function (event: Event) {
        event.preventDefault();

        const username = document.getElementById("username") as HTMLInputElement;
        const password = document.getElementById("password") as HTMLInputElement;
        const name = document.getElementById("name") as HTMLInputElement;
        const confirmPassword = document.getElementById("confirmPassword") as HTMLInputElement;
        const phone = document.getElementById("phone") as HTMLInputElement;
        const email = document.getElementById("email") as HTMLInputElement;
        const address = document.getElementById("address") as HTMLInputElement;
        console.log(username);
        console.log(password);
        console.log(name);
        console.log(confirmPassword);
        console.log(phone);
        console.log(email);
        console.log(address);
        if (
                username !== null &&
                password !== null &&
                name !== null &&
                confirmPassword !== null &&
                phone !== null &&
                email !== null &&
                address !== null
        ) {
                const input: RegisterUserDto = {
                        username: username.value,
                        password: password.value,
                        name: name.value,
                        confirmPassword: confirmPassword.value,
                        phone: phone.value,
                        email: email.value,
                        address: address.value,
                };

                http.post<ServerResponse<null>>(routers.registerUser, input).then(() => window.location.assign(routerLinks.loginForm));
        }
});
