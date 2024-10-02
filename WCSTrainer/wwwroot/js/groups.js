var groupTempList = document.getElementById('groupTempList');

function addItemToGroupPartial(id, Name) {

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
      li.textContent = Name;
      li.dataset.id = id;
      li.dataset.Name = Name;
      groupTempList.appendChild(li);
   } else {
      alert(Name + " is already in the temporary list.");
   }
}  

function confirmGroupSelection() {
   var selectedItems = Array.from(groupTempList.children).map(function (li) {
      return {
         Id: li.dataset.id,
         Name: li.dataset.Name,
      };
   });

   confirmSelectionFromPartial(selectedItems);
   groupTempList.innerHTML = '';
}