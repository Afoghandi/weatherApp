module.exports = {
    mode: "jit", // Just-in-time mode enabled
    content: ["./Views/**/*.cshtml", "./wwwroot/**/*.js"],
    theme: {
        extend: {
            animation: {
                fadeIn: "fadeIn 1s ease-in-out",
                bounceIcon: "bounceIcon 2s infinite",
                'background-pan': 'background-pan 10s infinite linear',
                spinSlow: "spinSlow 20s linear infinite",
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
                'background-pan': {
                    '0%': { backgroundPosition: '0% 50%' },
                    '100%': { backgroundPosition: '100% 50%' },
                },
                spinSlow: {
                    "0%": { transform: "rotate(0deg)" },
                    "100%": { transform: "rotate(360deg)" },
                },
            },
            colors: {
                primary: "#4F7886",
                secondary: "#D1E8E4",
                sunny: {
                    light: "#FFED85", // Softer yellow
                    dark: "#FFC107", // Vibrant golden yellow
                },
                cloudy: {
                    light: "#C4D7E1", // Softer grayish blue
                    dark: "#5D738F",  // Stronger steel blue
                },
                rainy: {
                    light: "#7393B3", // Calming blue
                    dark: "#1C4E80", // Deep navy blue
                },
                snowy: {
                    light: "#E0EFFF", // Frosty light blue
                    dark: "#A9D2E6", // Soft icy blue
                },
                overcast: {
                    light: "#C0C0C0", // Gentle silver gray
                    dark: "#808080", // Medium gray
                },
                thunderstorm: {
                    light: "#A29BFE", // Electric violet
                    dark: "#6C5CE7", // Deep stormy purple
                },

            },
            backgroundImage: {
                'gradient-sunny': 'linear-gradient(to bottom, #FFED85, #FFC107)',
                'gradient-cloudy': 'linear-gradient(to bottom, #C4D7E1, #5D738F)',
                'gradient-rainy': 'linear-gradient(to bottom, #7393B3, #1C4E80)',
                'gradient-snowy': 'linear-gradient(to bottom, #E0EFFF, #A9D2E6)',
                'gradient-overcast': 'linear-gradient(to bottom, #C0C0C0, #808080)',
                'gradient-thunderstorm': 'linear-gradient(to bottom, #A29BFE, #6C5CE7)',
            },
            fontFamily: {
                sans: ['"Roboto"', "sans-serif"],
            },
            boxShadow: {
                '3d': '0 4px 6px rgba(0, 0, 0, 0.1), 0 8px 12px rgba(0, 0, 0, 0.15)',
                'card-hover': '0 10px 15px rgba(0, 0, 0, 0.2)',
            },
        },
    },
    safelist: [
        'bg-gradient-sunny',
        'bg-gradient-cloudy',
        'bg-gradient-rainy',
        'bg-gradient-snowy',
        'bg-gradient-overcast',
        'bg-gradient-thunderstorm',
        'animate-background-pan',
        'animate-spinSlow',
        'bg-cover',
        'bg-center',
        'shadow-lg',
        'rounded-lg',
    ],
    plugins: [],
};
