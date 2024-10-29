function update(searchElement) {
   var value = searchElement.value.toLowerCase();
   var elements = document.getElementsByClassName("searchable");

   if (value == "") {
      for (var i = 0; i < elements.length; i++) {
         elements[i].style.display = "flex";
      }
   } else {
      for (var i = 0; i < elements.length; i++) {
         var id = elements[i].id.toLowerCase();
         if (id.indexOf(value) === -1) {
            elements[i].style.display = "none";
         } else {
            elements[i].style.display = "flex";
         }
      }
   }
}