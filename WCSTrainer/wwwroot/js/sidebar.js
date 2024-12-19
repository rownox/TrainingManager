function toggleExpand() {
   var textElements = document.getElementsByClassName("text");
   var menuElements = document.getElementsByClassName("condensable");
   var isHidden = !textElements[0].classList.contains("hidden");

   Array.from(textElements).forEach(function (item) {
      item.classList.toggle("hidden", isHidden);
   });

   Array.from(menuElements).forEach(function (item) {
      if (isHidden) {
         item.classList.add("condensed");
      } else {
         item.classList.remove("condensed");
      }
   });

   localStorage.setItem("allTextHidden", isHidden);
}

document.addEventListener("DOMContentLoaded", function () {
   var textElements = document.getElementsByClassName("text");
   var menuElements = document.getElementsByClassName("condensable");
   var isHidden = localStorage.getItem("allTextHidden") === "true";

   Array.from(textElements).forEach(function (item) {
      item.classList.toggle("hidden", isHidden);
   });

   Array.from(menuElements).forEach(function (item) {
      item.classList.toggle("condensed", isHidden);
   });
});
