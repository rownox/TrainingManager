var peopleTempList = document.getElementById('peopleTempList');

function addItemToPartial(id, firstName, lastName) {
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
         removeItem(li);
      });
      li.textContent = firstName + ' ' + lastName;
      li.dataset.id = id;
      li.dataset.firstName = firstName;
      li.dataset.lastName = lastName;
      peopleTempList.appendChild(li);
   } else {
      alert(firstName + " " + lastName + " is already in the temporary list.");
   }
}  

function confirmPeopleSelection() {
   var selectedItems = Array.from(peopleTempList.children).map(function (li) {
      return {
         Id: li.dataset.id,
         firstName: li.dataset.firstName,
         lastName: li.dataset.lastName
      };
   });

   confirmSelectionFromPartial(selectedItems);
   peopleTempList.innerHTML = '';
}