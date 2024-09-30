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

function closeComponent() {
   var peopleComponent = document.getElementById("people-component");
   var groupsComponent = document.getElementById("groups-component");
   var overlay = document.querySelector(".overlay");
   if (groupsComponent) groupsComponent.classList.add("hidden");
   if (peopleComponent) peopleComponent.classList.add("hidden");
   if (overlay) overlay.classList.add("hidden");

   partialTempList.innerHTML = '';
}
