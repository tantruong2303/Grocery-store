import { http } from "../package/axios";
import { routers } from "../package/axios/routes";

const store = document.getElementById("store");
const btnList = store?.querySelectorAll('button[type="button"]');

// string productId, int quantity
btnList?.forEach((btn) => {
        btn.addEventListener("click", function (event) {
                const id = btn.getAttribute("data-id") || "";
                http.post(routers.order.addToCart, { productId: id, quantity: 1 }).then(() => {
                        window.location.reload();
                });
        });
});

const addToCart = document?.querySelectorAll('div[data-group="addCart"]');
addToCart?.forEach((item) => {
        const id = item.getAttribute("data-id") || "";
        const plus = item.querySelectorAll('button[data-group="plus"]')[0];
        const label = item.querySelectorAll('div[data-group="label"]')[0];
        const minus = item.querySelectorAll('button[data-group="minus"]')[0];

        plus.addEventListener("click", function () {
                http.post(routers.order.addToCart, { productId: id, quantity: 1 }).then(() => {
                        window.location.reload();
                });
        });
        minus.addEventListener("click", function () {
                http.post(routers.order.addToCart, { productId: id, quantity: -1 }).then(() => {
                        window.location.reload();
                });
        });
});
