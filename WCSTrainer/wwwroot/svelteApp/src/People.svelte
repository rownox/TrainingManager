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

    let selectedPerson = null;
    let selectedGroup = null;
    let selected = null;

    function selectPerson(person) {
        selectedPerson = person;
        selectedGroup = null;
    }

    function selectGroup(group) {
        selectedGroup = group;
        selectedPerson = null;
    }

    $: if (selectedPerson) {
        selected = {
            name: selectedPerson.name,
            detailLabel: 'Status:',
            detailValue: selectedPerson.status,
            affGroup: selectedPerson.groups,
            hours: selectedPerson.hours
        };
    }

    $: if (selectedGroup) {
        selected = {
            name: selectedGroup.name,
            detailLabel: 'Member Count:',
            detailValue: selectedGroup.count
        };
    }

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

    function setCurrent(item) {
    }

    function toggleVisible(isVisible) {
        peopleShowing = isVisible;
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
        <button class="tab" on:click={() => toggleVisible(true)} class:open-tab={peopleShowing}>People</button>
        <button class="tab" on:click={() => toggleVisible(false)} class:open-tab={!peopleShowing}>Groups</button>
    </div>

    {#if peopleShowing}
        <ul id="people">
            {#each people as person}
                <li 
                    on:click={() => selectPerson(person)}
                    class:selected={$selectedPeople.some(p => p.id === person.id)}>
                    <div class="info">
                        <p>{person.name}</p>
                        <p class="sub">Status: {person.status}</p>
                    </div>
                    <div class="selector">
                        <input type="checkbox" on:click={() => toggleSelection(person, 'person')}>
                    </div>
                </li>
            {/each}
        </ul>
    {:else}
        <ul id="groups">
            {#each groups as group}
                <li 
                    on:click={() => selectGroup(group)}
                    class:selected={$selectedGroups.some(g => g.id === group.id)}>
                    <div class="info">
                        <p>{group.name}</p>
                        <p class="sub">Member Count: {group.count}</p>
                    </div>
                    <div class="selector">
                        <input type="checkbox" on:click={() => toggleSelection(group, 'group')}>
                    </div>
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
    {#if selected}
        <div class="top">
            {#if selectedPerson}
                <div class="person-info info-container">
                    <p class="title">{selected.name}</p>
                    <div class="info">
                        <p class="one">Status:</p>
                        <p class="two">{selected.detailValue}</p>
                    </div>
                    <div class="info">
                        <p class="one">Affiliated groups:</p>
                        <p class="two">{selected.affGroup}</p>
                    </div>
                    <div class="info">
                        <p class="one">Assigned Trainings:</p>
                    </div>
                    <div class="list">
                        <p class="item">Placeholder</p>
                    </div>
                    <div class="info">
                        <p class="one">Total Assigned Hours:</p>
                        <p class="two">{selected.hours}</p>
                    </div>
                </div>
            {/if}

            {#if selectedGroup}
                <div class="group-info info-container">
                    <p class="title">{selected.name}</p>
                    <div class="info">
                        <p class="one">Member Count:</p>
                        <p class="two">{selected.detailValue}</p>
                    </div>
                    <div class="info">
                        <p class="one">Members:</p>
                    </div>
                    <div class="list">
                        <p class="item">Placeholder</p>
                    </div>
                </div>
            {/if}
        </div>
    {/if}
</div>

<style>
</style>
