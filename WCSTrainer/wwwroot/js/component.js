var displayMode;
var inputElement;

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

function openComponent(mode) {
   displayMode = mode;
   inputElement = document.getElementById(mode + "List");

   var peopleComponent = document.getElementById("people-component");
   var groupsComponent = document.getElementById("groups-component");
   var overlay = document.querySelector(".overlay");
   if (mode == "group") {
      if (groupsComponent) groupsComponent.classList.remove("hidden");
   } else {
      if (peopleComponent) peopleComponent.classList.remove("hidden");
   }
   if (overlay) overlay.classList.remove("hidden");
}

function closeComponent() {
   var peopleComponent = document.getElementById("people-component");
   var groupsComponent = document.getElementById("groups-component");
   var overlay = document.querySelector(".overlay");
   if (groupsComponent) groupsComponent.classList.add("hidden");
   if (peopleComponent) peopleComponent.classList.add("hidden");
   if (overlay) overlay.classList.add("hidden");

   peopleTempList.innerHTML = '';
   groupsTempList.innerHTML = '';
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
         li.textContent = item.Name;
         inputElement.appendChild(li);

         updateInput(displayMode);
      }
   });
   closeComponent();
}