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

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nexports.routers = exports.routerLinks = void 0;\r\nexports.routerLinks = {\r\n    home: \"/\",\r\n    loginForm: \"/auth/login\",\r\n};\r\nexports.routers = {\r\n    category: {\r\n        create: \"/api/category\",\r\n        update: \"/api/category\",\r\n    },\r\n    order: {\r\n        addToCart: \"/api/cart/add\",\r\n    },\r\n    user: {\r\n        changePassword: \"/api/user/password\",\r\n        update: \"/api/user\",\r\n        login: \"/api/auth/login\",\r\n        register: \"/api/auth/register\",\r\n    },\r\n    product: {\r\n        create: \"/api/product\",\r\n    },\r\n};\r\n\n\n//# sourceURL=webpack://mono-webpack/./src/package/axios/routes.ts?");

/***/ }),

/***/ "./src/user/updateUser.ts":
/*!********************************!*\
  !*** ./src/user/updateUser.ts ***!
  \********************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nvar axios_1 = __webpack_require__(/*! ../package/axios */ \"./src/package/axios/index.ts\");\r\nvar routes_1 = __webpack_require__(/*! ../package/axios/routes */ \"./src/package/axios/routes.ts\");\r\nvar updateUserForm = document.getElementById(\"updateInformationForm\");\r\nupdateUserForm === null || updateUserForm === void 0 ? void 0 : updateUserForm.addEventListener(\"submit\", function (event) {\r\n    event.preventDefault();\r\n    var name = document.getElementById(\"name\");\r\n    var email = document.getElementById(\"email\");\r\n    var address = document.getElementById(\"address\");\r\n    var phone = document.getElementById(\"phone\");\r\n    if (name !== null && email !== null && address !== null && phone !== null) {\r\n        var input = {\r\n            name: name.value,\r\n            email: email.value,\r\n            address: address.value,\r\n            phone: phone.value,\r\n        };\r\n        axios_1.http.put(routes_1.routers.user.update, input);\r\n    }\r\n});\r\n\n\n//# sourceURL=webpack://mono-webpack/./src/user/updateUser.ts?");

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
/******/ 	var __webpack_exports__ = __webpack_require__("./src/user/updateUser.ts");
/******/ 	
/******/ })()
;