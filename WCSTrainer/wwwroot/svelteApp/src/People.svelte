<script>
    import { onMount } from 'svelte';
    import { writable } from 'svelte/store';

    let people = [
        { id: 1, name: 'John Doe', status: 'Trainer', groups: 'Sales', hours: 1 },
        { id: 2, name: 'Jane Smith', status: 'Trainer', groups: 'HR', hours: 1 },
        { id: 3, name: 'Heath Simmons', status: 'Trainer', groups: 'HR, Sales', hours: 1 },
        { id: 4, name: 'Alex Johnson', status: 'Trainer', groups: 'HR', hours: 1 },
        { id: 5, name: 'Jamie Lee', status: 'Trainer', groups: '', hours: 1 },
        { id: 6, name: 'Taylor Morgan', status: 'Trainee', groups: '', hours: 1 },
        { id: 7, name: 'Casey Smith', status: 'Trainee', groups: '', hours: 1 },
        { id: 8, name: 'Jordan Brown', status: 'Trainee', groups: '', hours: 1 }
    ];

    let groups = [
        { id: 1, name: 'HR', count: 6 },
        { id: 2, name: 'Sales', count: 12 },
        { id: 3, name: 'Marketing', count: 8 },
        { id: 4, name: 'Engineering', count: 15 },
        { id: 5, name: 'Finance', count: 10 },
        { id: 6, name: 'Customer Support', count: 7 },
        { id: 7, name: 'IT', count: 5 },
        { id: 8, name: 'Operations', count: 9 }
    ];

    const selectedPeople = writable([]);
    const selectedGroups = writable([]);
    let peopleShowing = true;

    function toggleSelection(item, type) {
        if (type === 'person') {
            selectedPeople.update(people => {
                const index = people.findIndex(person => person.id === item.id);
                if (index !== -1) {
                    people.splice(index, 1);
                } else {
                    people.push(item);
                }
                return [...people];
            });
        } else {
            selectedGroups.update(groups => {
                const index = groups.findIndex(group => group.id === item.id);
                if (index !== -1) {
                    groups.splice(index, 1);
                } else {
                    groups.push(item);
                }
                return [...groups];
            });
        }
    }

    function toggleVisible() {
        peopleShowing = !peopleShowing;
    }

    function addTrainers() {
        let selectedNames = [];
        selectedPeople.subscribe(people => {
            selectedNames = people.map(person => person.name);
        });
        selectedGroups.subscribe(groups => {
            selectedNames = selectedNames.concat(groups.map(group => group.name));
        });

        const selectedData = selectedNames.join(', ');
        if (selectedData) {
            const event = new CustomEvent('addTrainerEvent', { detail: selectedData });
            document.dispatchEvent(event);
        }
    }

    onMount(() => {
        window.addTrainerEvent = function(selectedPerson) {
            const event = new CustomEvent('addTrainerEvent', { detail: selectedPerson });
            document.dispatchEvent(event);
        };
    });
</script>

<div class="people-container">
    <div class="search">
        <input type="search" placeholder="Search By Name" />
    </div>

    <div class="tabs">
        <button class="tab" on:click={toggleVisible}>People</button>
        <button class="tab" on:click={toggleVisible}>Groups</button>
    </div>

    {#if peopleShowing}
        <ul id="people">
            {#each people as person}
                <li on:click={() => toggleSelection(person, 'person')}
                    class:selected={$selectedPeople.some(p => p.id === person.id)} tabindex="0">
                    <p>{person.name}</p>
                    <p class="sub">Status: {person.status}</p>
                </li>
            {/each}
        </ul>
    {:else}
        <ul id="groups">
            {#each groups as group}
                <li on:click={() => toggleSelection(group, 'group')}
                    class:selected={$selectedGroups.some(g => g.id === group.id)} tabindex="0">
                    <p>{group.name}</p>
                    <p class="sub">Member Count: {group.count}</p>
                </li>
            {/each}
        </ul>
    {/if}

    <p>Selected:</p>

    <div class="list-container">
        <div class="selected-list">
            {#each $selectedPeople as selectedPerson}
                <div class="selection pill">{selectedPerson.name}</div>
            {/each}

            {#each $selectedGroups as selectedGroup}
                <div class="selection pill">{selectedGroup.name}</div>
            {/each}
        </div>
    </div>
    
    <button class="btn btnWhite nbg-btn" on:click={addTrainers}>Add Trainers</button>
</div>

<div class="details">
    {#if $selectedPeople.length || $selectedGroups.length}
        <div class="top">
            {#each $selectedPeople as selectedPerson}
                <div class="person-info info-container">
                    <p class="title">{selectedPerson.name}</p>
                    <div class="info">
                        <p class="one">Status:</p>
                        <p class="two">{selectedPerson.status}</p>
                    </div>
                    <div class="info">
                        <p class="one">Affiliated groups:</p>
                        <p class="two">{selectedPerson.groups}</p>
                    </div>
                    <div class="info">
                        <p class="one">Total Assigned Hours:</p>
                        <p class="two">{selectedPerson.hours}</p>
                    </div>
                </div>
            {/each}

            {#each $selectedGroups as selectedGroup}
                <div class="group-info info-container">
                    <p class="title">{selectedGroup.name}</p>
                    <div class="info">
                        <p class="one">Member Count:</p>
                        <p class="two">{selectedGroup.count}</p>
                    </div>
                </div>
            {/each}
        </div>
    {/if}
</div>

<style>
</style>
