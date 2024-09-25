var displayMode;
var inputElement;
var partialTempList = document.getElementById('partialTempList');

function updateInput(mode) {
   var element = document.getElementById(mode + "List");
   var outputElement = document.getElementById(mode + "Input");

   var trainerListItems = Array.from(element.getElementsByTagName("li"));
   outputElement.value = trainerListItems.map(item => `${item.getAttribute("value")}`).join(", ");
}

function removeItem(item, mode) {
   if (item.tagName === "LI") {
      item.remove();
      updateInput(mode);
   }
}

function addItemToPartial(id, firstName, lastName) {

   var exists = Array.from(partialTempList.children).some(function (li) {
      return li.dataset.id == id;
   });

   if (!exists) {
      if (displayMode == "trainee") {
         partialTempList.innerHTML = '';
      }
      var li = document.createElement('li');
      li.classList.add("pill");
      li.addEventListener("click", function () {
         removeItem(li);
      });
      li.textContent = firstName + ' ' + lastName;
      li.dataset.id = id;
      li.dataset.firstName = firstName;
      li.dataset.lastName = lastName;
      partialTempList.appendChild(li);
   } else {
      alert(firstName + " " + lastName + " is already in the temporary list.");
   }
}  

function confirmSelectionInPartial() {
   var selectedItems = Array.from(partialTempList.children).map(function (li) {
      return {
         Id: li.dataset.id,
         firstName: li.dataset.firstName,
         lastName: li.dataset.lastName
      };
   });

   confirmSelectionFromPartial(selectedItems);
   partialTempList.innerHTML = '';
}

function confirmSelectionFromPartial(selectedItems) {
   selectedItems.forEach(function (item) {
      var itemExistsInList = Array.from(inputElement.children).some(function (li) {
         return li.value == item.Id;
      });

      if (!itemExistsInList) {
         if (displayMode == "trainee") {
            inputElement.innerHTML = '';
         }
         var li = document.createElement('li');

         li.classList.add("pill");
         li.addEventListener("click", function () {
            removeItem(li);
         });
         li.value = item.Id;
         li.textContent = item.firstName + ' ' + item.lastName;
         inputElement.appendChild(li);

         updateInput(displayMode);
      }
   });
   closeComponent();
}

function openComponent(mode) {
   displayMode = mode;
   inputElement = document.getElementById(mode + "List");

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
   
   partialTempList.innerHTML = '';
}
