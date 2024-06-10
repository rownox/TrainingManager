import svelte from 'rollup-plugin-svelte';
import resolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs';
import { terser } from 'rollup-plugin-terser';
import json from '@rollup/plugin-json';
import path from 'path';

const production = !process.env.ROLLUP_WATCH;

export default {
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
        resolve(),
        commonjs(),
        json(),
        production && terser()
    ]
};
