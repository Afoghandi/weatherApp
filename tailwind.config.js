module.exports = {
    mode: "jit",
    content: ["./Views/**/*.cshtml", "./wwwroot/**/*.js"],
    theme: {
        extend: {
            animation: {
                fadeIn: "fadeIn 1s ease-in-out",
                bounceIcon: "bounceIcon 2s infinite",
            },
            keyframes: {
                fadeIn: {
                    "0%": { opacity: 0 },
                    "100%": { opacity: 1 },
                },
                bounceIcon: {
                    "0%, 100%": { transform: "translateY(0)" },
                    "50%": { transform: "translateY(-10px)" },
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
    },
    mode: "jit",
    plugins: [],
};
