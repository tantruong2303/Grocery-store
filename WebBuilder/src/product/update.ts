import { http } from "../package/axios";
import { routers } from "../package/axios/routes";
import { ServerResponse } from "../package/interface/serverResponse";

let imageFile: File;
let status = 1;

const statusList = document.querySelectorAll('input[name="status"]');
statusList.forEach((radio) => {
        const element = radio as HTMLInputElement;
        if (element.getAttribute("checked")) {
                status = Number(element.value);
        }
        radio.addEventListener("click", function () {
                console.log("hello");
                status = Number(element.value);
        });
});

const image = document.getElementById("image");
image?.addEventListener("change", function () {
        const reader = new FileReader();
        reader.onload = function () {
                const dataURL = reader.result;
                const output = document.getElementById("image-preview");

                if (output) {
                        (output as any).src = dataURL;
                }
        };
        const input = this as HTMLInputElement;
        if (input && input.files) {
                imageFile = input.files[0];
                reader.readAsDataURL(input.files[0]);
        }
});

interface UpdateProductDto {
        productId: string;
        name: string;
        description: string;
        originalPrice: number;
        retailPrice: number;
        quantity: number;
        categoryId: string;
        file: File;
}

const updateProductForm = document.getElementById("updateProductForm");

updateProductForm?.addEventListener("submit", function (event: Event) {
        event.preventDefault();
        const productId = document.getElementById("productId") as HTMLInputElement;
        const name = document.getElementById("name") as HTMLInputElement;
        const description = document.getElementById("description") as HTMLInputElement;
        const originalPrice = document.getElementById("originalPrice") as HTMLInputElement;
        const retailPrice = document.getElementById("retailPrice") as HTMLInputElement;
        const quantity = document.getElementById("quantity") as HTMLInputElement;
        const categoryId = document.getElementById("categoryId") as HTMLInputElement;

        if (
                name != null &&
                description != null &&
                originalPrice != null &&
                retailPrice != null &&
                quantity != null &&
                categoryId != null &&
                productId != null
        ) {
                const formData = new FormData();
                console.log(name.value);
                formData.append("productId", productId.value);
                formData.append("name", name.value);
                formData.append("description", description.value);
                formData.append("originalPrice", originalPrice.value);
                formData.append("retailPrice", retailPrice.value);
                formData.append("quantity", quantity.value);
                formData.append("categoryId", categoryId.value);
                formData.append("file", imageFile);
                formData.append("status", String(status));

                http.put<ServerResponse<null>>(routers.product.update, formData).then(() => {
                        window.location.assign("/product");
                });
        }
});
