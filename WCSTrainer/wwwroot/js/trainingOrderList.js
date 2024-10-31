const closeModalBtn = document.querySelector(".btn-close");
const deleteText = document.getElementById("deleteText");
const deleteBtn = document.querySelector("#deleteBtn");
const overlay = document.querySelector(".overlay");
const modal = document.querySelector(".modal");

function checkedBox(checkboxElem) {
   toggleDisplay(checkboxElem.id, checkboxElem.checked);
   localStorage.setItem(checkboxElem.id, checkboxElem.checked);
   searchTrainingOrders();
}

function loadCheckboxStates() {
   var checkboxes = document.querySelectorAll(".selections input[type='checkbox']");
   var archivedItems = document.getElementsByClassName("Archived");
   Array.from(archivedItems).forEach(item => {
      item.style.display = "none";
   });

   checkboxes.forEach(checkbox => {
      var storedState = localStorage.getItem(checkbox.id);
      if (storedState !== null) {
         checkbox.checked = (storedState === "true");
         toggleDisplay(checkbox.id, checkbox.checked);
      }
   });
}

function toggleDisplay(className, show) {
   var elements = document.getElementsByClassName(className);
   var archivedCheckbox = document.getElementById("Archived");
   var verifiedCheckbox = document.getElementById("Verified");
   var completedCheckbox = document.getElementById("Completed");
   var activeCheckbox = document.getElementById("Active");
   var awaitingCheckbox = document.getElementById("Awaiting Approval");

   for (var i = 0; i < elements.length; i++) {
      var item = elements[i];
      var isArchived = item.classList.contains("Archived");
      var isVerified = item.classList.contains("Verified");
      var isCompleted = item.classList.contains("Completed");
      var isActive = item.classList.contains("Active");
      var isAwaiting = item.classList.contains("Awaiting");

      item.style.display = "none";

      if (isArchived && archivedCheckbox.checked) {
         if (
            (isVerified && verifiedCheckbox.checked) ||
            (isCompleted && completedCheckbox.checked) ||
            (isActive && activeCheckbox.checked) ||
            (isAwaiting && awaitingCheckbox.checked)
         ) {
            item.style.display = "flex";
         }
      } else if (!isArchived) {
         if (
            (isVerified && verifiedCheckbox.checked) ||
            (isCompleted && completedCheckbox.checked) ||
            (isActive && activeCheckbox.checked) ||
            (isAwaiting && awaitingCheckbox.checked)
         ) {
            item.style.display = "flex";
         }
      }
   }
}

function searchTrainingOrders() {
   var input = document.getElementById('searchInput');
   var filter = input.value.toLowerCase();
   var elements = document.getElementsByClassName("searchable");
   var maxCount = parseInt(document.querySelector('.drop-main').value);
   var visibleCount = 0;

   for (var i = 0; i < elements.length; i++) {
      var item = elements[i];
      var id = item.id.toLowerCase();
      var name = item.getAttribute('data-name').toLowerCase();
      var matchesSearch = id.includes(filter) || name.includes(filter);
      var matchesCheckbox = shouldDisplay(item);

      if (matchesSearch && matchesCheckbox) {
         if (visibleCount < maxCount) {
            item.style.display = "flex";
            visibleCount++;
         } else {
            item.style.display = "none";
         }
      } else {
         item.style.display = "none";
      }
   }
}

function shouldDisplay(item) {
   var archivedCheckbox = document.getElementById("Archived");
   var verifiedCheckbox = document.getElementById("Verified");
   var completedCheckbox = document.getElementById("Completed");
   var activeCheckbox = document.getElementById("Active");
   var awaitingCheckbox = document.getElementById("Awaiting Approval");

   var isArchived = item.classList.contains("Archived");
   var isVerified = item.classList.contains("Verified");
   var isCompleted = item.classList.contains("Completed");
   var isActive = item.classList.contains("Active");
   var isAwaiting = item.classList.contains("Awaiting");

   if (isArchived && !archivedCheckbox.checked) return false;
   if (isVerified && !verifiedCheckbox.checked) return false;
   if (isCompleted && !completedCheckbox.checked) return false;
   if (isActive && !activeCheckbox.checked) return false;
   if (isAwaiting && !awaitingCheckbox.checked) return false;

   return true;
}

function updateMaxCount(value) {
   searchTrainingOrders();
}

function submitForm() {
   document.getElementById('maxCountForm').submit();
}

window.onload = function () {
   loadCheckboxStates();
   searchTrainingOrders();
};