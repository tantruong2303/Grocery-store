var path = require("path");

module.exports = {
        entry: {
                login: "./src/auth/login.ts",
                register: "./src/auth/register.ts",
                createCategory: "./src/category/create.ts",
                updateCategory: "./src/category/update.ts",
        },
        output: {
                path: __dirname + "/../wwwroot/js",
                filename: "[name].js",
        },
        resolve: {
                alias: {
                        parchment: path.resolve(__dirname, "node_modules/parchment/src/parchment.ts"),
                        quill$: path.resolve(__dirname, "node_modules/quill/quill.js"),
                },
                extensions: [".js", ".ts", ".svg"],
        },
        module: {
                rules: [
                        {
                                test: /\.js$/,
                                use: [
                                        {
                                                loader: "babel-loader",
                                                options: {
                                                        presets: ["es2015"],
                                                },
                                        },
                                ],
                        },
                        {
                                test: /\.ts$/,
                                use: [
                                        {
                                                loader: "ts-loader",
                                                options: {
                                                        compilerOptions: {
                                                                declaration: false,
                                                                target: "es5",
                                                                module: "commonjs",
                                                        },
                                                        transpileOnly: true,
                                                },
                                        },
                                ],
                        },
                        {
                                test: /\.svg$/,
                                use: [
                                        {
                                                loader: "html-loader",
                                                options: {
                                                        minimize: true,
                                                },
                                        },
                                ],
                        },
                ],
        },
};
