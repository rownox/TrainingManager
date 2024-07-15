function initPeopleComponent() {
    const searchInput = document.getElementById('searchInput');
    const itemList = document.getElementById('itemList');
    const selectedList = document.getElementById('selectedList');
    const addSelectionBtn = document.getElementById('addSelectionBtn');
    const details = document.getElementById('details');

    let selectedItems = [];

    searchInput.addEventListener('input', function () {
        const searchTerm = this.value.toLowerCase();
        Array.from(itemList.children).forEach(li => {
            const text = li.textContent.toLowerCase();
            li.style.display = text.includes(searchTerm) ? '' : 'none';
        });
    });

    itemList.addEventListener('click', function (e) {
        const li = e.target.closest('li');
        if (li) {
            const id = li.dataset.id;
            const type = li.dataset.type;
            toggleSelection(id, type);
            updateSelectedList();
            updateDetails(li);
        }
    });

    addSelectionBtn.addEventListener('click', function () {
        // Implement add selection logic
        console.log('Add selection:', selectedItems);
    });

    function toggleSelection(id, type) {
        const index = selectedItems.findIndex(item => item.id === id);
        if (index > -1) {
            selectedItems.splice(index, 1);
        } else {
            selectedItems.push({ id, type });
        }
    }

    function updateSelectedList() {
        selectedList.innerHTML = selectedItems.map(item =>
            `<div class="selection pill">${getItemName(item.id)}</div>`
        ).join('');
    }

    function updateDetails(li) {
        // Implement details update logic
        details.innerHTML = `<p>Selected: ${li.querySelector('.info p').textContent}</p>`;
    }

    function getItemName(id) {
        const li = itemList.querySelector(`li[data-id="${id}"]`);
        return li ? li.querySelector('.info p').textContent : '';
    }
}

// Call this when the DOM is ready
document.addEventListener('DOMContentLoaded', initPeopleComponent);

// Also expose it globally in case you need to reinitialize after dynamic loading
window.initPeopleComponent = initPeopleComponent;