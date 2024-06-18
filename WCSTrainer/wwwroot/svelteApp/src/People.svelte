<script>
    import { onMount } from 'svelte';

    let people = [
        { id: 1, name: 'John Doe', status: 'Trainer', groups: 'Sales', hours: 1 },
        { id: 2, name: 'Jane Smith', status: 'Trainer', groups: 'HR', hours: 1 },
        { id: 3, name: 'Heath Simmons', status: 'Trainee', groups: 'HR, Sales', hours: 1 },
        { id: 4, name: 'Alex Johnson', status: 'Trainee', groups: 'HR', hours: 1 },
        { id: 5, name: 'Jamie Lee', status: 'Trainee', groups: '', hours: 1 },
        { id: 6, name: 'Taylor Morgan', status: 'Trainee', groups: 'HR', hours: 1 },
        { id: 7, name: 'Casey Smith', status: 'Trainee', groups: '', hours: 1 },
        { id: 8, name: 'Jordan Brown', status: 'Trainee', groups: 'Sales', hours: 1 }
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

    let selected = null;
    let selectedPerson = null;
    let selectedGroup = null;

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
</script>

<div class="people-container">
    <div class="search">
        <input type="search" placeholder="Search By Name" />
    </div>

    <p>People</p>
    <ul id="people">
        {#each people as person}
            <!-- svelte-ignore a11y-click-events-have-key-events -->
            <li on:click={() => selectPerson(person)} class:selected={selectedPerson === person}>
                <p>{person.name}</p>
                <p class="sub">Status: {person.status}</p>
            </li>
        {/each}
    </ul>

    <p>Groups</p>
    <ul id="groups">
        {#each groups as group}
            <!-- svelte-ignore a11y-click-events-have-key-events -->
            <li on:click={() => selectGroup(group)} class:selected={selectedGroup === group}>
                <p>{group.name}</p>
                <p class="sub">Member Count: {group.count}</p>
            </li>
        {/each}
    </ul>
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
    
    <div class="bottom">
        <a class="btn btnBlue bg-btn">Add Trainer</a>
    </div>
</div>

<style>
</style>
