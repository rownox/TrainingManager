function toggleExpand() {
   var textElements = document.getElementsByClassName("text");
   Array.from(textElements).forEach(function (item, index) {
      item.classList.toggle("hidden");

      if (item.classList.contains("hidden")) {
         localStorage.setItem("textHidden-" + index, "true");
      } else {
         localStorage.setItem("textHidden-" + index, "false");
      }
   });
}

document.addEventListener("DOMContentLoaded", function () {
   var textElements = document.getElementsByClassName("text");

   Array.from(textElements).forEach(function (item, index) {
      var isHidden = localStorage.getItem("textHidden-" + index);

      if (isHidden === "true") {
         item.classList.add("hidden");
      } else {
         item.classList.remove("hidden");
      }
   });
});
