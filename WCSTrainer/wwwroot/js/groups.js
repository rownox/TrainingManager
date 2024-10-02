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
      alert(Name + " is already in the temporary list.");
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