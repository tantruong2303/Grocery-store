(()=>{"use strict";var e={284:(e,t,n)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.http=void 0;var r=n(603),a=axios;t.http=a,a.defaults.withCredentials=!0,a.interceptors.request.use(r.requestInterceptor),a.interceptors.response.use(r.responseSuccessInterceptor,r.responseFailedInterceptor)},603:(e,t)=>{function n(){var e=document.getElementById("form-btn"),t=document.getElementById("loading");t&&e&&(e.classList.remove("hidden"),e.classList.add("block"),t.classList.add("hidden"),t.classList.remove("flex"))}Object.defineProperty(t,"__esModule",{value:!0}),t.responseFailedInterceptor=t.responseSuccessInterceptor=t.handleCommonResponse=t.requestInterceptor=void 0,t.requestInterceptor=function(e){var t=document.getElementById("form-btn"),n=document.getElementById("loading"),r=document.getElementById("MESSAGEERROR"),a=document.getElementById("ERRORMESSAGEERROR");for(var o in e.data){var d=document.getElementById(o.toUpperCase()+"ERROR");d&&(d.innerHTML="")}return a&&(a.innerHTML=""),r&&(r.innerHTML=""),n&&t&&(t.classList.add("hidden"),n.classList.remove("hidden"),n.classList.add("flex")),e},t.handleCommonResponse=n,t.responseSuccessInterceptor=function(e){var t,r,a,o;if(n(),null===(r=null===(t=null==e?void 0:e.data)||void 0===t?void 0:t.details)||void 0===r?void 0:r.message){var d=document.getElementById("MESSAGEERROR");d&&(d.innerHTML=null===(o=null===(a=null==e?void 0:e.data)||void 0===a?void 0:a.details)||void 0===o?void 0:o.message)}return e},t.responseFailedInterceptor=function(e){var t,r;if(n(),null===(r=null===(t=e.response)||void 0===t?void 0:t.data)||void 0===r?void 0:r.details){var a=e.response.data.details;for(var o in a){var d=document.getElementById(o.toUpperCase()+"ERROR");d&&(d.innerHTML=d.getAttribute("data-label")+" "+a[o]),!d||"errorMessage"!==o&&"message"!==o||(d.innerHTML=""+a[o])}}return Promise.reject(e.response)}},312:(e,t)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.routers=t.routerLinks=void 0,t.routerLinks={home:"/",loginForm:"/auth/login"},t.routers={category:{create:"/api/category",update:"/api/category"},order:{addToCart:"/api/cart/add",getCart:"/api/cart",create:"/api/order"},user:{changePassword:"/api/user/password",update:"/api/user",login:"/api/auth/login",register:"/api/auth/register"},product:{create:"/api/product",update:"/api/product"}}}},t={};function n(r){var a=t[r];if(void 0!==a)return a.exports;var o=t[r]={exports:{}};return e[r](o,o.exports,n),o.exports}(()=>{var e,t=n(284),r=n(312),a=1;document.querySelectorAll('input[name="status"]').forEach((function(e){var t=e;t.getAttribute("checked")&&(a=Number(t.value)),e.addEventListener("click",(function(){console.log("hello"),a=Number(t.value)}))}));var o=document.getElementById("image");null==o||o.addEventListener("change",(function(){var t=new FileReader;t.onload=function(){var e=t.result,n=document.getElementById("image-preview");n&&(n.src=e)};var n=this;n&&n.files&&(e=n.files[0],t.readAsDataURL(n.files[0]))}));var d=document.getElementById("updateProductForm");null==d||d.addEventListener("submit",(function(n){n.preventDefault();var o=document.getElementById("productId"),d=document.getElementById("name"),i=document.getElementById("description"),l=document.getElementById("originalPrice"),s=document.getElementById("retailPrice"),u=document.getElementById("quantity"),c=document.getElementById("categoryId");if(null!=d&&null!=i&&null!=l&&null!=s&&null!=u&&null!=c&&null!=o){var p=new FormData;console.log(d.value),p.append("productId",o.value),p.append("name",d.value),p.append("description",i.value),p.append("originalPrice",l.value),p.append("retailPrice",s.value),p.append("quantity",u.value),p.append("categoryId",c.value),p.append("file",e),p.append("status",String(a)),t.http.put(r.routers.product.update,p).then((function(){window.location.assign("/product")}))}}))})()})();