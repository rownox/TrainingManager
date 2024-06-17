import App from './App.svelte';
import People from './People.svelte';

function initSvelteComponents() {

    if (document.getElementById('sv-comp-app')) {
        new App({
            target: document.getElementById('sv-comp-app')
        });
    }

    if (document.getElementById('sv-comp-people')) {
        new People({
            target: document.getElementById('sv-comp-people')
        });
    }
}

initSvelteComponents();
