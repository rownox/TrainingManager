var peopleTempList = document.getElementById('peopleTempList');

function addItemToPartial(id, firstName, lastName) {
   var personName = firstName + ' ' + lastName;
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