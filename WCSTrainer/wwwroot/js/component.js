var displayMode;
var inputElement;
var lastSelected;

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
   if (groupsComponent != null) {
      groupsComponent.classList.add("hidden");
      groupsTempList.innerHTML = '';
   }
   if (peopleComponent != null) {
      peopleComponent.classList.add("hidden");
      peopleTempList.innerHTML = '';
   }
   if (overlay) overlay.classList.add("hidden");
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
            removeItem(li, displayMode);
         });
         li.value = item.Id;
         li.textContent = item.Name;
         inputElement.appendChild(li);

         updateInput(displayMode);
      }
   });
   closeComponent();
}

function highlight(element, list) {
   if (lastSelected != null) {
      lastSelected.classList.remove('selected');
   }

   element.classList.add('selected');
   lastSelected = element;
}

var groupsTempList = document.getElementById('groupTempList');

function addItemToGroupPartial(id, Name) {
   var exists = Array.from(groupsTempList.children).some(function (li) {
      return li.dataset.id == id;
   });

   if (!exists) {
      var li = document.createElement('li');
      li.classList.add("pill");
      li.addEventListener("click", function () {
         removeItem(li, displayMode);
      });
      li.textContent = Name;
      li.dataset.id = id;
      li.dataset.Name = Name;
      groupsTempList.appendChild(li);
   } else {
      alert(Name + " is already in the list.");
   }
}

function confirmGroupSelection() {
   var selectedItems = Array.from(groupsTempList.children).map(function (li) {
      return {
         Id: li.dataset.id,
         Name: li.dataset.Name,
      };
   });

   confirmSelectionFromPartial(selectedItems);
   groupsTempList.innerHTML = '';
}


var peopleTempList = document.getElementById('peopleTempList');

function addItemToPartial(id, personName) {
   var exists = Array.from(peopleTempList.children).some(function (li) {
      return li.dataset.id == id;
   });

   if (!exists) {
      if (displayMode == "trainee") {
         peopleTempList.innerHTML = '';
      }
      var li = document.createElement('li');
      li.classList.add("pill");
      li.addEventListener("click", function () {
         removeItem(li, displayMode);
      });
      li.textContent = personName;
      li.dataset.id = id;
      li.dataset.Name = personName;
      peopleTempList.appendChild(li);

   } else {
      alert(personName + " is already in the list.");
   }
}

function confirmPeopleSelection() {
   var selectedItems = Array.from(peopleTempList.children).map(function (li) {
      return {
         Id: li.dataset.id,
         Name: li.dataset.Name,
      };
   });

   confirmSelectionFromPartial(selectedItems);
   peopleTempList.innerHTML = '';
}