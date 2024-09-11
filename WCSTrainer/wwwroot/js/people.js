function updateInput(input, output) {
   var trainerListItems = Array.from(input.getElementsByTagName("li"));
   output.value = trainerListItems.map(item => `${item.getAttribute("value")}`).join(", ");
}

function removeItem(item) {
   if (item.tagName === "LI") {
      item.remove();
      // updateInput();
   }
}

function addItemToPartial(id, firstName, lastName) {
   var listElement = document.getElementById('partialTempList');
   var exists = Array.from(listElement.children).some(function (li) {
      return li.textContent === firstName + ' ' + lastName;
   });

   if (!exists) {
      var li = document.createElement('li');
      li.classList.add("pill");
      li.addEventListener("click", function () {
         removeItem(li);
      });
      li.textContent = firstName + ' ' + lastName;
      li.dataset.id = id;
      li.dataset.firstName = firstName;
      li.dataset.lastName = lastName;
      listElement.appendChild(li);
   } else {
      alert(firstName + " " + lastName + " is already in the temporary list.");
   }
}

function confirmSelectionInPartial() {
   var listElement = document.getElementById('partialTempList');
   var selectedItems = Array.from(listElement.children).map(function (li) {
      return {
         Id: li.dataset.id,
         firstName: li.dataset.firstName,
         lastName: li.dataset.lastName
      };
   });

   confirmSelectionFromPartial(selectedItems);
   listElement.innerHTML = '';
}

function confirmSelectionFromPartial(selectedItems) {
   var listElement = document.getElementById('trainerList');
   selectedItems.forEach(function (item) {
      var itemExistsInList = Array.from(listElement.children).some(function (li) {
         return li.textContent === item.firstName + ' ' + item.lastName;
      });

      if (!itemExistsInList) {
         var li = document.createElement('li');
         li.classList.add("pill");
         li.addEventListener("click", function () {
            removeItem(li);
         });
         li.value = item.Id;
         li.textContent = item.firstName + ' ' + item.lastName;
         listElement.appendChild(li);
      }
   });
   closeComponent();
}

function openComponent(mode) {
   window.peopleComponentMode = mode;
   window.dispatchEvent(new Event('peopleComponentModeChange'));

   var peopleComponent = document.getElementById("people-component");
   var overlay = document.querySelector(".overlay");
   if (peopleComponent) peopleComponent.classList.remove("hidden");
   if (overlay) overlay.classList.remove("hidden");
}

function closeComponent() {
   var peopleComponent = document.getElementById("people-component");
   var overlay = document.querySelector(".overlay");
   if (peopleComponent) peopleComponent.classList.add("hidden");
   if (overlay) overlay.classList.add("hidden");
}
