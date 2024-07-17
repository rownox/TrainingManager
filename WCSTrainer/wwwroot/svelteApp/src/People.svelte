<script>
    import { onMount } from 'svelte';
    import { writable } from 'svelte/store';

    let displayMode = 'both';
    let people = [];
    let groups = [];

    const selectedPeople = writable([]);
    const selectedGroups = writable([]);
    let peopleShowing = true;

    let selected = null;


    function updateDisplayMode() {
        const newMode = window.peopleComponentMode || 'both';
        if (newMode !== displayMode) {
            displayMode = newMode;
            clearSelection();
        }
    }

    function clearSelection() {
        selectedPeople.set([]);
        selectedGroups.set([]);
        selected = null;
    }

    function selectItem(item, type) {
        selected = {
            name: item.name,
            detailLabel: type === 'person' ? 'Status:' : 'Member Count:',
            detailValue: type === 'person' ? item.status : item.count,
            ...(type === 'person' && { affGroup: item.groups, hours: item.hours })
        };

        if (displayMode === 'trainees' && type === 'person') {
            selectedPeople.set([item]);
        }
    }

    function toggleSelection(item, type) {
        if (displayMode === 'trainees' && type === 'person') {
            selectedPeople.set([item]);
        } else {
            const store = type === 'person' ? selectedPeople : selectedGroups;
            store.update(items => {
                const index = items.findIndex(i => i.id === item.id);
                return index !== -1
                    ? items.filter(i => i.id !== item.id)
                    : [...items, item];
            });
        }
    }

    function addSelection() {
        let selectedItems = [];

        selectedPeople.subscribe(people => {
            selectedItems = [...selectedItems, ...people.map(person => ({ name: person.name, id: person.id }))];
        });

        if (displayMode !== 'trainees') {
            selectedGroups.subscribe(groups => {
                selectedItems = [...selectedItems, ...groups.map(group => ({ name: group.name, id: group.id }))];
            });
        }

        if (selectedItems.length) {
            const eventName = displayMode === 'trainers' ? 'addTrainerEvent' : 'addTraineeEvent';
            const detail = displayMode === 'trainees'
                ? selectedItems[0]
                : { items: selectedItems };
            const event = new CustomEvent(eventName, { detail });
            document.dispatchEvent(event);
        }
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

        window.addTrainerEvent = function(selectedPerson) {
            document.dispatchEvent(new CustomEvent('addTrainerEvent', { detail: selectedPerson }));
        };

        window.addTraineeEvent = function(selectedPerson) {
            document.dispatchEvent(new CustomEvent('addTraineeEvent', { detail: selectedPerson }));
        };

        return () => {
            window.removeEventListener('peopleComponentModeChange', updateDisplayMode);
        };
    });
</script>

<div class="people-container">
    <div class="search">
        <input type="search" placeholder="Search By Name" />
    </div>

    <ul id={peopleShowing ? 'people' : 'groups'}>
        {#each peopleShowing ? people.filter(p => displayMode === 'both' || (displayMode === 'trainers' ? p.status === 'Trainer' : p.status !== 'Trainer')) : groups as item}
            <!-- svelte-ignore a11y-click-events-have-key-events -->
            <li on:click={() => selectItem(item, peopleShowing ? 'person' : 'group')} 
                class:selected={peopleShowing 
                    ? $selectedPeople.some(p => p.id === item.id)
                    : $selectedGroups.some(g => g.id === item.id)}>
                {#if peopleShowing}
                    <div class="photo">
                        <div class="frame"></div>
                    </div>
                {/if}
                <div class="info">
                    <p>{item.name}</p>
                    <div class="sub">
                        <p>{peopleShowing ? 'Status:' : 'Member Count:'} </p>
                        <p class:highlight={peopleShowing && item.status === "Trainer"}>
                            {peopleShowing ? item.status : item.count}
                        </p>
                    </div>
                </div>
                <div class="selector">
                    <img src={`/images/${(peopleShowing ? $selectedPeople : $selectedGroups).some(i => i.id === item.id) ? 'subtract' : 'add'}.svg`}
                         on:click={() => toggleSelection(item, peopleShowing ? 'person' : 'group')}
                         alt={peopleShowing ? $selectedPeople.some(p => p.id === item.id) ? 'Remove' : 'Add' : $selectedGroups.some(g => g.id === item.id) ? 'Remove' : 'Add'}>
                </div>
            </li>
        {/each}
    </ul>

    <p>Selected:</p>

    <div class="list-container">
        <div class="selected-list">
            {#if displayMode === 'trainees'}
                {#each $selectedPeople as item}
                    <div class="selection pill">{item.name}</div>
                {/each}
            {:else}
                {#each [...$selectedPeople, ...$selectedGroups] as item}
                    <div class="selection pill">{item.name}</div>
                {/each}
            {/if}
        </div>
    </div>
    
    <button class="btn btnWhite nbg-btn" on:click={addSelection}>
        Add {displayMode === 'trainers' ? 'Trainers' : 'Trainee'}
    </button>
</div>

<div class="details">
    {#if selected}
        <div class="top">
            <div class="{selected.affGroup ? 'person-info' : 'group-info'} info-container">
                <p class="title">{selected.name}</p>
                <div class="info">
                    <p class="one">{selected.detailLabel}</p>
                    <p class="two">{selected.detailValue}</p>
                </div>
                {#if selected.affGroup}
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