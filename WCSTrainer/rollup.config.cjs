const svelte = require('rollup-plugin-svelte');
const resolve = require('@rollup/plugin-node-resolve').default;
const commonjs = require('@rollup/plugin-commonjs');
const json = require('@rollup/plugin-json');
const path = require('path');

const production = !process.env.ROLLUP_WATCH;

module.exports = {
    input: 'src/main.js',
    output: {
        sourcemap: true,
        format: 'iife',
        name: 'app',
        file: path.resolve(__dirname, 'wwwroot/js/bundle.js')
    },
    plugins: [
        svelte({
            dev: !production,
            css: css => {
                css.write(path.resolve(__dirname, 'wwwroot/css/bundle.css'));
            }
        }),
        resolve({
            browser: true,
            dedupe: ['svelte']
        }),
        commonjs(),
        json()
    ]
};
