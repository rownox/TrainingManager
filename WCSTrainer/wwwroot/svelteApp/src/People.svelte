<script>
    let people = [
        { id: 1, name: 'John Doe', status: 'Trainer', groups: 'Sales' },
        { id: 2, name: 'Jane Smith', status: 'Trainer', groups: 'HR' },
        { id: 3, name: 'Heath Simmons', status: 'Trainee', groups: 'HR, Sales' },
        { id: 4, name: 'Alex Johnson', status: 'Trainee', groups: 'HR' },
        { id: 5, name: 'Jamie Lee', status: 'Trainee', groups: '' },
        { id: 6, name: 'Taylor Morgan', status: 'Trainee', groups: 'HR' },
        { id: 7, name: 'Casey Smith', status: 'Trainee', groups: '' },
        { id: 8, name: 'Jordan Brown', status: 'Trainee', groups: 'Sales' }
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

    let selectedPersonOrGroup = null;

    function handleClick(event) {
        if (selectedPersonOrGroup) {
            selectedPersonOrGroup.classList.remove('selected');
        }
        selectedPersonOrGroup = event.currentTarget;
        selectedPersonOrGroup.classList.add('selected');
        updateDetails();
    }

    function updateDetails() {
        let name, detailLabel, detailValue, affGroup;
        let topSection = document.querySelector('.details .top');
        let personInfo = topSection.querySelector('.person-info');
        let groupInfo = topSection.querySelector('.group-info');

        if (selectedPersonOrGroup.dataset.personId) {
            let personId = parseInt(selectedPersonOrGroup.dataset.personId);
            let person = people.find(person => person.id === personId);

            name = person.name;
            detailLabel = 'Status:';
            detailValue = person.status;
            affGroup = person.groups;

            personInfo.style.display = 'block';
            groupInfo.style.display = 'none';

            personInfo.querySelector('.title').textContent = name;
            personInfo.querySelector('.info:nth-child(2) .two').textContent = detailValue;
            personInfo.querySelector('.info:nth-child(3) .two').textContent = affGroup;
        } else if (selectedPersonOrGroup.dataset.groupId) {
            let groupId = parseInt(selectedPersonOrGroup.dataset.groupId);
            let group = groups.find(group => group.id === groupId);

            name = group.name;
            detailLabel = 'Member Count:';
            detailValue = group.count;

            groupInfo.style.display = 'block';
            personInfo.style.display = 'none';

            groupInfo.querySelector('.title').textContent = name;
            groupInfo.querySelector('.info:nth-child(2) .two').textContent = detailValue;
        }
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
            <li on:click={handleClick} data-person-id={person.id}>
                <p>{person.name}</p>
                <p class="sub">Status: {person.status}</p>
            </li>
        {/each}
    </ul>

    <p>Groups</p>
    <ul id="groups">
        {#each groups as group}
            <!-- svelte-ignore a11y-click-events-have-key-events -->
            <li on:click={handleClick} data-group-id={group.id}>
                <p>{group.name}</p>
                <p class="sub">Member Count: {group.count}</p>
            </li>
        {/each}
    </ul>
</div>

<div class="details">
    <div class="top">
        <div class="person-info info-container" style="display: none;">
            <p class="title">Placeholder</p>
            <div class="info">
                <p class="one">Status:</p>
                <p class="two">Placeholder</p>
            </div>
            <div class="info">
                <p class="one">Affiliated groups:</p>
                <p class="two">Placeholder</p>
            </div>
            <div class="info">
                <p class="one">Assigned Trainings:</p>
            </div>
            <div class="list">
                <p class="item">Placeholder</p>
            </div>
            <div class="info">
                <p class="one">Total Assigned Hours:</p>
                <p class="two">Placeholder</p>
            </div>
        </div>
        
        <div class="group-info info-container" style="display: none;">
            <p class="title">Placeholder</p>
            <div class="info">
                <p class="one">Member Count:</p>
                <p class="two">Placeholder</p>
            </div>
            <div class="info">
                <p class="one">Members:</p>
            </div>
            <div class="list">
                <p class="item">Placeholder</p>
            </div>
        </div>
    </div>
    
    <div class="bottom">
        <!-- svelte-ignore a11y-missing-attribute -->
        <a class="btn btnBlue bg-btn">Add Trainer</a>
    </div>
</div>

<style>
</style>
