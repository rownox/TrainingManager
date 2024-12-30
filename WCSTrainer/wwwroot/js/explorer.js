var fileContainer = document.getElementById("fileList");
var currentPath = "/Shared";
var pathDisplay = document.getElementById("path");

function setPath(path) {
   currentPath = path;
   var splitPath = path.split("/");
   pathDisplay.innerHTML = "";
   Array.from(splitPath).forEach(link => {
      var newItem = document.createElement("li");
      newItem.textContent = link;
      newItem.onclick = () => setPath(currentPath + "/" + link)
      pathDisplay.appendChild(newItem)
   });
   updateFiles();
}

function updateFiles() {
   Array.from(fileContainer.children).forEach(child => {
      const dataPath = child.getAttribute('data-path') || '';
      if (!dataPath.includes(currentPath)) {
         child.style.display = 'none';
      } else {
         child.style.display = 'flex';
      }
   });
}

document.addEventListener('DOMContentLoaded', function () {
   document.querySelectorAll('.file-explorer > .folder').forEach(folder => {
      folder.classList.add('open');
   });

   document.querySelectorAll('.file').forEach(file => {
      file.addEventListener('click', function () {
         const path = this.getAttribute('data-path');
         console.log('File clicked:', path);
      });
   });

   updateFiles();
});