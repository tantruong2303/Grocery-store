/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./src/auth/register.ts":
/*!******************************!*\
  !*** ./src/auth/register.ts ***!
  \******************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nvar axios_1 = __webpack_require__(/*! ../package/axios */ \"./src/package/axios/index.ts\");\r\nvar routes_1 = __webpack_require__(/*! ../package/axios/routes */ \"./src/package/axios/routes.ts\");\r\nvar registerForm = document.getElementById(\"registerForm\");\r\nregisterForm === null || registerForm === void 0 ? void 0 : registerForm.addEventListener(\"submit\", function (event) {\r\n    event.preventDefault();\r\n    var username = document.getElementById(\"username\");\r\n    var password = document.getElementById(\"password\");\r\n    var name = document.getElementById(\"name\");\r\n    var confirmPassword = document.getElementById(\"confirmPassword\");\r\n    var phone = document.getElementById(\"phone\");\r\n    var email = document.getElementById(\"email\");\r\n    var address = document.getElementById(\"address\");\r\n    console.log(username);\r\n    console.log(password);\r\n    console.log(name);\r\n    console.log(confirmPassword);\r\n    console.log(phone);\r\n    console.log(email);\r\n    console.log(address);\r\n    if (username !== null &&\r\n        password !== null &&\r\n        name !== null &&\r\n        confirmPassword !== null &&\r\n        phone !== null &&\r\n        email !== null &&\r\n        address !== null) {\r\n        var input = {\r\n            username: username.value,\r\n            password: password.value,\r\n            name: name.value,\r\n            confirmPassword: confirmPassword.value,\r\n            phone: phone.value,\r\n            email: email.value,\r\n            address: address.value,\r\n        };\r\n        axios_1.http.post(routes_1.routers.user.register, input).then(function () { return window.location.assign(routes_1.routerLinks.loginForm); });\r\n    }\r\n});\r\n\n\n//# sourceURL=webpack://mono-webpack/./src/auth/register.ts?");

/***/ }),

/***/ "./src/package/axios/index.ts":
/*!************************************!*\
  !*** ./src/package/axios/index.ts ***!
  \************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nexports.http = void 0;\r\nvar interceptor_1 = __webpack_require__(/*! ./interceptor */ \"./src/package/axios/interceptor.ts\");\r\nvar http = axios;\r\nexports.http = http;\r\nhttp.defaults.withCredentials = true;\r\nhttp.interceptors.request.use(interceptor_1.requestInterceptor);\r\nhttp.interceptors.response.use(interceptor_1.responseSuccessInterceptor, interceptor_1.responseFailedInterceptor);\r\n\n\n//# sourceURL=webpack://mono-webpack/./src/package/axios/index.ts?");

/***/ }),

/***/ "./src/package/axios/interceptor.ts":
/*!******************************************!*\
  !*** ./src/package/axios/interceptor.ts ***!
  \******************************************/
/***/ ((__unused_webpack_module, exports) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nexports.responseFailedInterceptor = exports.responseSuccessInterceptor = exports.handleCommonResponse = exports.requestInterceptor = void 0;\r\nfunction requestInterceptor(req) {\r\n    var btn = document.getElementById(\"form-btn\");\r\n    var loading = document.getElementById(\"loading\");\r\n    var message = document.getElementById(\"message\");\r\n    var errorMessage = document.getElementById(\"errorMessage\");\r\n    for (var key in req.data) {\r\n        var error = document.getElementById(key.toUpperCase() + \"ERROR\");\r\n        if (error) {\r\n            error.innerHTML = \"\";\r\n        }\r\n    }\r\n    if (errorMessage) {\r\n        errorMessage.innerHTML = \"\";\r\n    }\r\n    if (message) {\r\n        message.innerHTML = \"\";\r\n    }\r\n    if (loading && btn) {\r\n        btn.classList.add(\"hidden\");\r\n        loading.classList.remove(\"hidden\");\r\n        loading.classList.add(\"flex\");\r\n    }\r\n    return req;\r\n}\r\nexports.requestInterceptor = requestInterceptor;\r\nfunction handleCommonResponse() {\r\n    var btn = document.getElementById(\"form-btn\");\r\n    var loading = document.getElementById(\"loading\");\r\n    if (loading && btn) {\r\n        btn.classList.remove(\"hidden\");\r\n        btn.classList.add(\"block\");\r\n        loading.classList.add(\"hidden\");\r\n        loading.classList.remove(\"flex\");\r\n    }\r\n}\r\nexports.handleCommonResponse = handleCommonResponse;\r\nfunction responseSuccessInterceptor(response) {\r\n    var _a, _b, _c, _d;\r\n    handleCommonResponse();\r\n    if ((_b = (_a = response === null || response === void 0 ? void 0 : response.data) === null || _a === void 0 ? void 0 : _a.details) === null || _b === void 0 ? void 0 : _b.message) {\r\n        var message = document.getElementById(\"MESSAGEERROR\");\r\n        if (message) {\r\n            message.innerHTML = (_d = (_c = response === null || response === void 0 ? void 0 : response.data) === null || _c === void 0 ? void 0 : _c.details) === null || _d === void 0 ? void 0 : _d.message;\r\n        }\r\n    }\r\n    return response;\r\n}\r\nexports.responseSuccessInterceptor = responseSuccessInterceptor;\r\nfunction responseFailedInterceptor(error) {\r\n    var _a, _b;\r\n    handleCommonResponse();\r\n    if ((_b = (_a = error.response) === null || _a === void 0 ? void 0 : _a.data) === null || _b === void 0 ? void 0 : _b.details) {\r\n        var details = error.response.data.details;\r\n        for (var key in details) {\r\n            var error_1 = document.getElementById(key.toUpperCase() + \"ERROR\");\r\n            if (error_1) {\r\n                error_1.innerHTML = error_1.getAttribute(\"data-label\") + \" \" + details[key];\r\n            }\r\n            if (error_1 && (key === \"errorMessage\" || key === \"message\")) {\r\n                error_1.innerHTML = \"\" + details[key];\r\n            }\r\n        }\r\n    }\r\n    return Promise.reject(error.response);\r\n}\r\nexports.responseFailedInterceptor = responseFailedInterceptor;\r\n\n\n//# sourceURL=webpack://mono-webpack/./src/package/axios/interceptor.ts?");

/***/ }),

/***/ "./src/package/axios/routes.ts":
/*!*************************************!*\
  !*** ./src/package/axios/routes.ts ***!
  \*************************************/
/***/ ((__unused_webpack_module, exports) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nexports.routers = exports.routerLinks = void 0;\r\nexports.routerLinks = {\r\n    home: \"/\",\r\n    loginForm: \"/auth/login\",\r\n};\r\nexports.routers = {\r\n    category: {\r\n        create: \"/api/category\",\r\n        update: \"/api/category\",\r\n    },\r\n    user: {\r\n        changePassword: \"/api/user/password\",\r\n        update: \"/api/user\",\r\n        login: \"/api/auth/login\",\r\n        register: \"/api/auth/register\",\r\n    },\r\n    product: {\r\n        create: \"/api/product\",\r\n    },\r\n};\r\n\n\n//# sourceURL=webpack://mono-webpack/./src/package/axios/routes.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = __webpack_require__("./src/auth/register.ts");
/******/ 	
/******/ })()
;