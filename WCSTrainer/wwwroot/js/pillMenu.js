class MultiSelectComponent {
   constructor(wrapper, onUpdateFilters, type) {
      this.wrapper = wrapper;
      this.selectElement = wrapper.querySelector(".multi-select-comp");
      this.type = type;
      this.onUpdateFilters = onUpdateFilters;
      this.selectedValues = new Set();
      this.init();
   }

   init() {
      this.pillContainer = document.createElement("div");
      this.pillContainer.className = "pill-container";
      this.wrapper.insertBefore(this.pillContainer, this.selectElement);
      this.selectElement.style.display = "none";

      this.pillContainer.addEventListener("click", (e) => {
         if (e.target === this.pillContainer) {
            this.showDropdown();
         }
      });

      this.selectElement.addEventListener("mousedown", (e) => {
         e.preventDefault();
         this.toggleOptionSelection(e.target);
      });

      this.loadInitialPills();
   }


   showDropdown() {
      this.selectElement.style.display = "block";
      this.selectElement.focus();

      const hideDropdown = (e) => {
         if (!this.wrapper.contains(e.target)) {
            this.selectElement.style.display = "none";
            document.removeEventListener('click', hideDropdown);
         }
      };

      setTimeout(() => {
         document.addEventListener('click', hideDropdown);
      }, 0);
   }

   handleSelection() {
      this.pillContainer.innerHTML = '';
      this.selectedValues.clear();

      Array.from(this.selectElement.selectedOptions).forEach(option => {
         this.selectedValues.add(option.value);
         this.addPill(option);
      });

      this.updateFilters();
   }

   addPill(option) {
      const pill = document.createElement("div");
      pill.className = "pill";
      pill.setAttribute("data-value", option.value);
      pill.textContent = option.text;
      pill.addEventListener("click", (event) => {
         event.stopPropagation();
         this.removePill(option.value);
      });

      this.pillContainer.appendChild(pill);
   }

   removePill(value) {
      const pill = this.pillContainer.querySelector(`.pill[data-value="${value}"]`);
      if (pill) pill.remove();

      const option = this.selectElement.querySelector(`option[value="${value}"]`);
      if (option) option.selected = false;

      this.selectedValues.delete(value);
      this.updateFilters();
   }

   updateFilters() {
      const selectedValues = Array.from(this.selectedValues).map(value => parseInt(value));

      if (this.onUpdateFilters) {
         this.onUpdateFilters(selectedValues, this.type);
      }
   }

   loadInitialPills() {
      Array.from(this.selectElement.selectedOptions).forEach(option => {
         this.selectedValues.add(option.value);
         this.addPill(option);
      });
   }

   toggleOptionSelection(option) {
      if (!option.value) return;

      if (option.selected) {
         option.selected = false;
         this.removePill(option.value);
      } else {
         option.selected = true;
         this.addPill(option);
      }

      this.updateFilters();
   }


}

document.addEventListener("DOMContentLoaded", () => {
   const updateFilters = (selectedValues, type) => {
      if (type === "priority") {
         currentFilters.priorityIds = selectedValues.length > 0 ? selectedValues : null;
      } else if (type === "month") {
         currentFilters.monthIds = selectedValues.length > 0 ? selectedValues : null;
      }
      //else if (type === "year") {
      //   currentFilters.yearIds = selectedValues.length > 0 ? selectedValues : null;
      //}
      currentFilters.currentPage = 1;
      loadOrders();
   };

   const multiSelectWrappers = document.querySelectorAll(".multi-select-wrapper");
   multiSelectWrappers.forEach((wrapper, index) => {
      //const type = index === 0 ? "priority" : index === 1 ? "month" : "year";
      const type = index === 0 ? "priority" : "month";
      new MultiSelectComponent(wrapper, updateFilters, type);
   });
});
