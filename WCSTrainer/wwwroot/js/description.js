window.onload = function () {
   var textareas = document.querySelectorAll(".desc-resize");
   textareas.forEach(function (textarea) {
      textarea.style.height = 'auto';
      textarea.style.height = textarea.scrollHeight + 'px';
   });
};
