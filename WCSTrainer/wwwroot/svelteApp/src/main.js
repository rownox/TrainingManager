import App from './App.svelte';

function initSvelteComponents() {

    if (document.getElementById('sv-comp-app')) {
        new App({
            target: document.getElementById('sv-comp-app')
        });
    }
}

initSvelteComponents();
