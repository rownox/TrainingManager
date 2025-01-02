var fileContainer = document.getElementById("fileList");
var currentPath = "/Shared";
var pathDisplay = document.getElementById("path");


function setPath(path) {
   currentPath = path.endsWith("/") ? path.slice(0, -1) : path;
   const splitPath = currentPath.split("/").filter(Boolean);
   pathDisplay.innerHTML = "";
   let accumulatedPath = "";

   splitPath.forEach((segment, index) => {
      accumulatedPath += (index > 0 ? "/" : "") + segment;

      const newItem = document.createElement("li");
      newItem.textContent = segment;

      newItem.onclick = () => setPath("/" + splitPath.slice(0, index + 1).join("/"));
      pathDisplay.appendChild(newItem);

      if (index < splitPath.length - 1) {
         const arrow = document.createElement("li");
         arrow.textContent = "->";
         pathDisplay.appendChild(arrow);
      }
   });

   updateFiles();
}


function updateFiles() {
   Array.from(fileContainer.children).forEach(child => {
      const dataPath = child.getAttribute('data-path') || '';
      if (dataPath.startsWith(currentPath + "/") || dataPath === currentPath) {
         child.style.display = 'flex';
      } else {
         child.style.display = 'none';
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