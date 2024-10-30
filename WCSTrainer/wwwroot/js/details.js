document.addEventListener('DOMContentLoaded', function () {
   var printButton = document.getElementById('printButton');
   if (printButton) {
      printButton.addEventListener('click', function () {
         window.print();
      });
   }
});