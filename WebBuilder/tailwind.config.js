const theme = require("tailwindcss/defaultTheme");

module.exports = {
        purge: ["./../Views/**/*.cshtml"],
        darkMode: false, // or 'media' or 'class'
        theme: { spacing: { ...theme.spacing, 101: "25.25rem" }, extend: {} },
        variants: {
                extend: {},
        },
        plugins: [],
};
