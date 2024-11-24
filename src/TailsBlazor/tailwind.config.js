/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.razor", "./**/*.razor.cs", "./**/*.cs", "./**/*.css"],
  theme: {
    extend: {
      colors: {
        primary: {
          lighten: '#E4E9F1',
          DEFAULT: '#283044',
          darken: '#1e2433'
        },
        secondary: {
          lighten: '#E4EAF2',
          DEFAULT: '#3E5C81',
          darken: '#35506E'
        },
        tertiary: {
          lighten: '#F8F1F8',
          DEFAULT: '#AD5EAA',
          darken: '#954B93'
        },
        error: {
          lighten: '#FBEEEE',
          DEFAULT: '#D74242',
          darken: '#CA2B2B'
        },
        success: {
          lighten: '#E1F4E9',
          DEFAULT: '#3CB870',
          darken: '#35975E'
        },
        warning: {
          lighten: '#FEF8EC',
          DEFAULT: '#F4BC44',
          darken: '#F3B32B'
        },
        info: {
          lighten: '#EDF7FC',
          DEFAULT: '#52ADE6',
          darken: '#3BA2E3'
        },
        neutral: {
          lighten: '#F5F5F5',
          DEFAULT: '#CCCCCC',
          darken: '#BFBFBF'
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
  purge: false
}

