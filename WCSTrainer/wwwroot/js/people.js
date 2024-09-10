var tempSelectedItems = [];

function updateTrainersInput(input, output) {
   var trainerListItems = Array.from(input.getElementsByTagName("li"));
   output.value = trainerListItems.map(item => `${item.getAttribute("value")}`).join(", ");
}

function removeItem(item) {
   if (item.tagName === "LI") {
      item.remove();
      // updateTrainersInput();
      // updateTraineeInput();
      // updateGroupsInput();
   }
}

function addItemToPartial(id, firstName, lastName) {
   var exists = tempSelectedItems.some(function (item) {
      return item.firstName == firstName && item.lastName == lastName;
   });

   if (!exists) {
      tempSelectedItems.push({ Id: id, firstName: firstName, lastName: lastName });

      var listElement = document.getElementById('partialTempList');
      var li = document.createElement('li');
      li.classList.add("pill");
      li.addEventListener("click", function () {
         removeItem(li);
      })
      li.textContent = firstName + ' ' + lastName;
      listElement.appendChild(li);
   } else {
      alert(firstName + " " + lastName + " is already in the temporary list.");
   }
}

function confirmSelectionInPartial() {
   confirmSelectionFromPartial(tempSelectedItems);

   tempSelectedItems = [];
   document.getElementById('partialTempList').innerHTML = '';
}

function confirmSelectionFromPartial(selectedItems) {
   var listElement = document.getElementById('trainerList');

   selectedItems.forEach(function (item) {
      var itemExistsInList = Array.from(listElement.children).some(function (li) {
         return li.textContent == item.firstName + ' ' + item.lastName;
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
