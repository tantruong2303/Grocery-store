import { http } from "../package/axios";
import { routers } from "../package/axios/routes";
import { ServerResponse } from "../package/interface/serverResponse";

let imageFile: File;

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

interface CreateCategoryDto {
        name: string;
        description: string;
        originalPrice: number;
        retailPrice: number;
        quantity: number;
        categoryId: string;
        file: File;
}

const createProductForm = document.getElementById("createProductForm");

createProductForm?.addEventListener("submit", function (event: Event) {
        event.preventDefault();
        const name = document.getElementById("name") as HTMLInputElement;
        const description = document.getElementById("description") as HTMLInputElement;
        const originalPrice = document.getElementById("originalPrice") as HTMLInputElement;
        const retailPrice = document.getElementById("retailPrice") as HTMLInputElement;
        const quantity = document.getElementById("quantity") as HTMLInputElement;
        const categoryId = document.getElementById("categoryId") as HTMLInputElement;

        if (name != null && description != null && originalPrice != null && retailPrice != null && quantity != null && categoryId != null) {
                const formData = new FormData();
                console.log(name.value);
                formData.append("name", name.value);
                formData.append("description", description.value);
                formData.append("originalPrice", originalPrice.value);
                formData.append("retailPrice", retailPrice.value);
                formData.append("quantity", quantity.value);
                formData.append("categoryId", categoryId.value);
                formData.append("file", imageFile);

                // http.post<ServerResponse<null>>(routers.product.create, formData, {}).then();
        }
});