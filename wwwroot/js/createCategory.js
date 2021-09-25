(()=>{"use strict";var e,t,r,n,o={284:(e,t,r)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.http=void 0;var n=r(603),o=axios;t.http=o,o.defaults.withCredentials=!0,o.interceptors.request.use(n.requestInterceptor),o.interceptors.response.use(n.responseSuccessInterceptor,n.responseFailedInterceptor)},603:(e,t)=>{function r(){var e=document.getElementById("form-btn"),t=document.getElementById("loading");t&&e&&(e.classList.remove("hidden"),e.classList.add("block"),t.classList.add("hidden"),t.classList.remove("flex"))}Object.defineProperty(t,"__esModule",{value:!0}),t.responseFailedInterceptor=t.responseSuccessInterceptor=t.handleCommonResponse=t.requestInterceptor=void 0,t.requestInterceptor=function(e){var t=document.getElementById("form-btn"),r=document.getElementById("loading"),n=document.getElementById("MESSAGEERROR"),o=document.getElementById("ERRORMESSAGEERROR");for(var a in e.data){var s=document.getElementById(a.toUpperCase()+"ERROR");s&&(s.innerHTML="")}return o&&(o.innerHTML=""),n&&(n.innerHTML=""),r&&t&&(t.classList.add("hidden"),r.classList.remove("hidden"),r.classList.add("flex")),e},t.handleCommonResponse=r,t.responseSuccessInterceptor=function(e){var t,n,o,a;if(r(),null===(n=null===(t=null==e?void 0:e.data)||void 0===t?void 0:t.details)||void 0===n?void 0:n.message){var s=document.getElementById("MESSAGEERROR");s&&(s.innerHTML=null===(a=null===(o=null==e?void 0:e.data)||void 0===o?void 0:o.details)||void 0===a?void 0:a.message)}return e},t.responseFailedInterceptor=function(e){var t,n;if(r(),null===(n=null===(t=e.response)||void 0===t?void 0:t.data)||void 0===n?void 0:n.details){var o=e.response.data.details;for(var a in o){var s=document.getElementById(a.toUpperCase()+"ERROR");s&&(s.innerHTML=s.getAttribute("data-label")+" "+o[a]),!s||"errorMessage"!==a&&"message"!==a||(s.innerHTML=""+o[a])}}return Promise.reject(e.response)}},312:(e,t)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.routers=t.routerLinks=void 0,t.routerLinks={home:"/",loginForm:"/auth/login"},t.routers={category:{create:"/api/category",update:"/api/category"},order:{addToCart:"/api/cart/add",getCart:"/api/cart",create:"/api/order"},user:{changePassword:"/api/user/password",update:"/api/user",login:"/api/auth/login",register:"/api/auth/register"},product:{create:"/api/product",update:"/api/product"}}}},a={};function s(e){var t=a[e];if(void 0!==t)return t.exports;var r=a[e]={exports:{}};return o[e](r,r.exports,s),r.exports}e=s(284),t=s(312),r=1,n=document.getElementById("createCategoryForm"),document.querySelectorAll('input[name="status"]').forEach((function(e){e.addEventListener("click",(function(){r=Number(e.value)}))})),null==n||n.addEventListener("submit",(function(n){n.preventDefault();var o=document.getElementById("name"),a=document.getElementById("description");if(null!=o&&null!=a&&null!=r){var s={name:o.value,description:a.value,status:r};e.http.post(t.routers.category.create,s).then((function(){o.value="",a.value=""}))}}))})();