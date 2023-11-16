/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./**/*.{razor,html,cshtml}",
      "./node_modules/flowbite/**/*.js"],
    theme: {
      extend: {
        colors: {
          'jendamark-blue': {
            100: '#e6f1f6',
            200: '#b3d5e4',
            300: '#66acca',
            400: '#3390b8',
            500: '#0074a6',
            600: '#005d85',
            700: '#004664',
            800: '#002332',
            900: '#000c11',
          },
          'jendamark-gray': {
            100: '#ececec',
            200: '#c6c6c6',
            300: '#a0a0a0',
            400: '#797979',
            500: '#404040',
            600: '#333333',
            700: '#262626',
            800: '#1a1a1a',
            900: '#060606',
          },
        }
      },
    },
    plugins: [
      require('flowbite/plugin')
    ],
  }
  