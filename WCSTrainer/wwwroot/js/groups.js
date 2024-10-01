var groupTempList = document.getElementById('groupTempList');

function addItemToGroupPartial(id, firstName, lastName) {

   var exists = Array.from(groupTempList.children).some(function (li) {
      return li.dataset.id == id;
   });

   if (!exists) {
      if (displayMode == "trainee") {
         groupTempList.innerHTML = '';
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
      groupTempList.appendChild(li);
   } else {
      alert(firstName + " " + lastName + " is already in the temporary list.");
   }
}  

function confirmSelectionInPartial() {
   var selectedItems = Array.from(groupTempList.children).map(function (li) {
      return {
         Id: li.dataset.id,
         firstName: li.dataset.firstName,
         lastName: li.dataset.lastName
      };
   });

   confirmSelectionFromPartial(selectedItems);
   groupTempList.innerHTML = '';
}