
export function initializePeopleComponent() {
    var employeesDataElement = document.getElementById('employeesData');
    var employeesData = employeesDataElement.value ? JSON.parse(employeesDataElement.value) : [];
    window.employeesData = employeesData;

    var trainergroupsDataElement = document.getElementById('trainergroupsData');
    var trainergroupsData = trainergroupsDataElement.value ? JSON.parse(trainergroupsDataElement.value) : [];
    window.trainergroupsData = trainergroupsData;

    var peopleComponent = document.getElementById("sv-comp-people");
    var overlay = document.querySelector(".overlay");
    var trainersInput = document.getElementById("trainersInput");
    var trainList = document.getElementById("trainerList");
    var trainee = document.getElementById("trainee");
    var traineeInput = document.getElementById("traineeInput");
    var person = document.getElementsByClassName("person");

    function safeAddEventListener(element, event, handler) {
        if (element) {
            element.addEventListener(event, handler);
        }
    }

    safeAddEventListener(overlay, "click", closeComponent);

    safeAddEventListener(trainee, "click", function (event) {
        if (event.target.tagName === "LI") {
            event.target.remove();
            updateTraineeInput();
        }
    });

    safeAddEventListener(trainList, "click", function (event) {
        if (event.target.tagName === "LI") {
            event.target.remove();
            updateTrainersInput();
        }
    });

    Array.from(person).forEach(item => {
        safeAddEventListener(item, "click", addTrainer);
    });

    function addTrainer(trainerNames) {
        if (!trainerNames || !trainerNames.trim()) return;

        if (typeof trainerNames === 'string') {
            var names = trainerNames.split(',');
        } else if (trainerNames instanceof Event) {
            names = [trainerNames.target.textContent.trim()];
        } else {
            return;
        }

        var trainerList = document.getElementById("trainerList");
        if (!trainerList) return;

        names.forEach(name => {
            name = name.trim();
            if (!Array.from(trainerList.getElementsByTagName("li")).some(li => li.textContent.trim() === name)) {
                trainerList.innerHTML += `<li draggable="true" class="pill">${name}</li>`;
            }
        });

        updateTrainersInput();
    }

    function addTrainee(traineeName, traineeId) {
        if (!traineeName || !traineeName.trim() || !traineeId) return;

        var traineeList = document.getElementById("trainee");
        if (!traineeList) return;

        traineeList.innerHTML = `<li value="${traineeId}" class="pill">${traineeName.trim()}</li>`;
        updateTraineeInput();
    }

    function updateTrainersInput() {
        if (!trainList || !trainersInput) return;

        var trainerListItems = Array.from(trainList.getElementsByTagName("li"));
        trainersInput.value = trainerListItems.map(item => item.textContent.trim()).join(", ");
    }

    function updateTraineeInput() {
        if (!trainee || !traineeInput) return;

        var traineeListItems = Array.from(trainee.getElementsByTagName("li"));
        traineeInput.value = traineeListItems.length > 0 ? traineeListItems[0].getAttribute("value") : "";
    }

    if (trainList) {
        const trainerListObserver = new MutationObserver(updateTrainersInput);
        trainerListObserver.observe(trainList, { childList: true, subtree: true });
    }

    if (trainee) {
        const traineeObserver = new MutationObserver(updateTraineeInput);
        traineeObserver.observe(trainee, { childList: true, subtree: true });
    }

    document.addEventListener("addTrainerEvent", function (event) {
        addTrainer(event.detail.names);
        closeComponent();
    });

    document.addEventListener("addTraineeEvent", function (event) {
        addTrainee(event.detail.name, event.detail.id);
        closeComponent();
    });

    updateTrainersInput();
    updateTraineeInput();
}

export function openComponent(mode) {
    window.peopleComponentMode = mode;
    window.dispatchEvent(new Event('peopleComponentModeChange'));

    var peopleComponent = document.getElementById("sv-comp-people");
    var overlay = document.querySelector(".overlay");
    if (peopleComponent) peopleComponent.classList.remove("hidden");
    if (overlay) overlay.classList.remove("hidden");
}

export function closeComponent() {
    var peopleComponent = document.getElementById("sv-comp-people");
    var overlay = document.querySelector(".overlay");
    if (peopleComponent) peopleComponent.classList.add("hidden");
    if (overlay) overlay.classList.add("hidden");
}

window.openComponent = openComponent;