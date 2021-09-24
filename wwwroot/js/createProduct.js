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

/***/ "./src/product/create.ts":
/*!*******************************!*\
  !*** ./src/product/create.ts ***!
  \*******************************/
/***/ ((__unused_webpack_module, exports) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nvar imageFile;\r\nvar image = document.getElementById(\"image\");\r\nimage === null || image === void 0 ? void 0 : image.addEventListener(\"change\", function () {\r\n    var reader = new FileReader();\r\n    reader.onload = function () {\r\n        var dataURL = reader.result;\r\n        var output = document.getElementById(\"image-preview\");\r\n        if (output) {\r\n            output.src = dataURL;\r\n        }\r\n    };\r\n    var input = this;\r\n    if (input && input.files) {\r\n        imageFile = input.files[0];\r\n        reader.readAsDataURL(input.files[0]);\r\n    }\r\n});\r\nvar createProductForm = document.getElementById(\"createProductForm\");\r\ncreateProductForm === null || createProductForm === void 0 ? void 0 : createProductForm.addEventListener(\"submit\", function (event) {\r\n    event.preventDefault();\r\n    var name = document.getElementById(\"name\");\r\n    var description = document.getElementById(\"description\");\r\n    var originalPrice = document.getElementById(\"originalPrice\");\r\n    var retailPrice = document.getElementById(\"retailPrice\");\r\n    var quantity = document.getElementById(\"quantity\");\r\n    var categoryId = document.getElementById(\"categoryId\");\r\n    if (name != null && description != null && originalPrice != null && retailPrice != null && quantity != null && categoryId != null) {\r\n        var formData = new FormData();\r\n        console.log(name.value);\r\n        formData.append(\"name\", name.value);\r\n        formData.append(\"description\", description.value);\r\n        formData.append(\"originalPrice\", originalPrice.value);\r\n        formData.append(\"retailPrice\", retailPrice.value);\r\n        formData.append(\"quantity\", quantity.value);\r\n        formData.append(\"categoryId\", categoryId.value);\r\n        formData.append(\"file\", imageFile);\r\n        // http.post<ServerResponse<null>>(routers.product.create, formData, {}).then();\r\n    }\r\n});\r\n\n\n//# sourceURL=webpack://mono-webpack/./src/product/create.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = {};
/******/ 	__webpack_modules__["./src/product/create.ts"](0, __webpack_exports__);
/******/ 	
/******/ })()
;