function addItemToGroupPartial(id, firstName, lastName) {

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
         removeItem2(li);
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
function openGroupsComponent() {
   inputElement = document.getElementById("GroupList");

   var groupsComponent = document.getElementById("groups-component");
   var overlay = document.querySelector(".overlay");
   if (groupsComponent) groupsComponent.classList.remove("hidden");
   if (overlay) overlay.classList.remove("hidden");
}