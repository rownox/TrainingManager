<script>
    import { onMount } from 'svelte';
    import { writable } from 'svelte/store';

    let displayMode;
    let people = [];
    let groups = [];

    const selectedItems = writable([]);

    let selected = null;

    function updateDisplayMode() {
        const newMode = window.peopleComponentMode;
        if (newMode !== displayMode) {
            displayMode = newMode;
            clearSelection();
        }
    }

    function selectItem(item) {
        selected = {
            name: item.name,
            detailLabel: displayMode === 'groups' ? 'Member Count:' : 'Status:',
            detailValue: displayMode === 'groups' ? item.count : item.status,
            ...(displayMode !== 'groups' && { affGroup: item.groups, hours: item.hours })
        };
    }

    function toggleItem(item) {
        selectedItems.update(items => {
            const index = items.findIndex(i => i.id === item.id);
            return index !== -1
                ? items.filter(i => i.id !== item.id)
                : [...items, item];
        });
    }

    function addSelection() {
        let itemsToAdd = [];
        selectedItems.subscribe(items => {
            itemsToAdd = items.map(item => ({ name: item.name, id: item.id }));
        })();

        if (itemsToAdd.length) {
            let eventName;
            let detail;

            switch(displayMode) {
                case 'trainees':
                    eventName = 'addTraineeEvent';
                    detail = itemsToAdd[0];
                    break;
                case 'groups':
                    eventName = 'addGroupEvent';
                    detail = { items: itemsToAdd };
                    break;
                case 'trainers':
                    eventName = 'addTrainerEvent';
                    detail = { items: itemsToAdd };
                    break;
            }

            const event = new CustomEvent(eventName, { detail });
            document.dispatchEvent(event);
        }

        selectedItems.set([]);
    }

    onMount(() => {
        if (window.employeesData && Array.isArray(window.employeesData)) {
            people = window.employeesData.map(employee => ({
                id: employee.Id,
                name: `${employee.FirstName} ${employee.LastName}`,
                status: employee.Status,
                groups: employee.Skills,
                hours: 1
            }));
        }

        if (window.trainergroupsData && Array.isArray(window.trainergroupsData)) {
            groups = window.trainergroupsData.map(group => ({
                id: group.Id,
                name: group.Name,
                count: 1,
            }));
        }

        window.addEventListener('peopleComponentModeChange', updateDisplayMode);

        updateDisplayMode();
    });
</script>

<div class="people-container">
    <div class="search">
        <input type="search" placeholder="Search By Name" />
    </div>

    <ul>
        {#if displayMode === 'groups'}
            {#each groups as item}
                <li on:click={() => selectItem(item)} 
                    class:selected={$selectedItems.some(i => i.id === item.id)}>
                    <div class="info">
                        <p>{item.name}</p>
                        <div class="sub">
                            <p>Member Count: {item.count}</p>
                        </div>
                    </div>
                    <div class="selector">
                        <img src={`/images/${$selectedItems.some(i => i.id === item.id) ? 'subtract' : 'add'}.svg`}
                             alt={$selectedItems.some(i => i.id === item.id) ? 'Remove' : 'Add'}
                             on:click|stopPropagation={() => toggleItem(item)}>
                    </div>
                </li>
            {/each}
        {:else}
            {#each people.filter(p => displayMode === 'trainers' ? p.status === 'Trainer' : p.status !== 'Trainer') as item}
                <li on:click={() => selectItem(item)} 
                    class:selected={$selectedItems.some(i => i.id === item.id)}>
                    <div class="photo">
                        <div class="frame"></div>
                    </div>
                    <div class="info">
                        <p>{item.name}</p>
                        <div class="sub">
                            <p>Status: </p>
                            <p class:highlight={item.status === "Trainer"}>{item.status}</p>
                        </div>
                    </div>
                    <div class="selector">
                        <img src={`/images/${$selectedItems.some(i => i.id === item.id) ? 'subtract' : 'add'}.svg`}
                             alt={$selectedItems.some(i => i.id === item.id) ? 'Remove' : 'Add'}
                             on:click|stopPropagation={() => toggleItem(item)}>
                    </div>
                </li>
            {/each}
        {/if}
    </ul>

    <p>Selected:</p>

    <div class="list-container">
        <div class="selected-list">
            {#each $selectedItems as item}
                <div class="selection pill">{item.name}</div>
            {/each}
        </div>
    </div>
    
    <button class="btn btnWhite nbg-btn" on:click={addSelection}>
        Add {displayMode === 'trainers' ? 'Trainers' : displayMode === 'groups' ? 'Groups' : 'Trainee'}
    </button>
</div>

<div class="details">
    {#if selected}
        <div class="top">
            <div class="{displayMode !== 'groups' ? 'person-info' : 'group-info'} info-container">
                <p class="title">{selected.name}</p>
                <div class="info">
                    <p class="one">{selected.detailLabel}</p>
                    <p class="two">{selected.detailValue}</p>
                </div>
                {#if displayMode !== 'groups'}
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
                {:else}
                    <div class="info">
                        <p class="one">Members:</p>
                    </div>
                    <div class="list">
                        <p class="item">Placeholder</p>
                    </div>
                {/if}
            </div>
        </div>
    {/if}
</div>

<style>
</style>