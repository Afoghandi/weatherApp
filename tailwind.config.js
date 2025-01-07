module.exports = {
    content: ["./Views/**/*.cshtml", "./wwwroot/**/*.js"],
    theme: {
        extend: {
            animation: {
                fadeIn: "fadeIn 1s ease-in-out",
            },
            keyframes: {
                fadeIn: {
                    "0%": { opacity: 0 },
                    "100%": { opacity: 1 },
                },
            },
            colors: {
                primary: "#4F7886", 
                secondary: "#D1E8E4", 
            },
            fontFamily: {
                sans: ['"Roboto"', "sans-serif"],
            },
        },

    },
    plugins: [],
};
