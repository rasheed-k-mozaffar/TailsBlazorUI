/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.razor"],
  purge: ["./**/*.razor"],
  theme: {
    extend: {
      colors: {
        primary: {
          lighten: '#b2bbd2',
          DEFAULT: '#283044',
          darken: '#1e2433'
        },
        secondary: {
          lighten: '#9fb5d1',
          DEFAULT: '#3e5c81',
          darken: '#35506e'
        },
        tertiary: {
          lighten: '#d6aed5',
          DEFAULT: '#ad5eaa',
          darken: '#954b93'
        },
        error: {
          lighten: '#edabab',
          DEFAULT: '#d74242',
          darken: '#ca2b2b'
        },
        success: {
          lighten: '#b9e3b5',
          DEFAULT: '#5bbe52',
          darken: '#4db143'
        },
        warning: {
          lighten: '#fae3b2',
          DEFAULT: '#f4bc44',
          darken: '#f3b32b'
        },
        info: {
          lighten: '#a6d5f2',
          DEFAULT: '#52ade6',
          darken: '#3ba2e3'
        },
        neutral: {
          lighten: '#e0e0e0',
          DEFAULT: '#bebebe',
          darken: '#a3a3a3'
        },
        text: {
          lighten: '#e0e0e0',
          DEFAULT: '#252525',
          darken: '#141414'
        }
      }
    },
  },
  plugins: [],
}

