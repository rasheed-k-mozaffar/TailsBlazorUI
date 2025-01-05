/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.razor", "./**/*.razor.cs", "./**/*.cs", "./**/*.css", "../**/*.razor"],
  theme: {
    extend: {
      spacing: {
        '13': '3.25rem', // Example: 52px
        '14': '3.5rem',  // Example: 56px
        '15': '3.75rem', // Example: 60px
        '17': '4.25rem', // Example: 68px
        '18': '4.5rem',  // Example: 72px
        '19': '4.75rem', // Example: 76px
        '21': '5.25rem', // Example: 84px
        '22': '5.5rem',  // Example: 88px
        '23': '5.75rem', // Example: 92px
        '25': '6.25rem', // Example: 100px
        '26': '6.5rem',  // Example: 104px
        '27': '6.75rem', // Example: 108px
        '29': '7.25rem', // Example: 116px
        '30': '7.5rem',  // Example: 120px
        '31': '7.75rem', // Example: 124px
        '33': '8.25rem', // Example: 132px
        '34': '8.5rem',  // Example: 136px
        '35': '8.75rem', // Example: 140px
        '37': '9.25rem', // Example: 148px
        '38': '9.5rem',  // Example: 152px
        '39': '9.75rem', // Example: 156px
      },
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
          lighten: '#A7A7A7',
          DEFAULT: '#626262',
          darken: '#141414'
        }
      }
    },
  },
  plugins: [],
  purge: false
}

