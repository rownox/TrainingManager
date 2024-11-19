class MultiSelectComponent {
   constructor(wrapper, onUpdateFilters) {
      this.wrapper = wrapper;
      this.selectElement = wrapper.querySelector(".multi-select-comp");
      this.onUpdateFilters = onUpdateFilters;
      this.selectedValues = new Set(); // Use Set to track selected values
      this.init();
   }

   init() {
      this.pillContainer = document.createElement("div");
      this.pillContainer.className = "pill-container";
      this.wrapper.insertBefore(this.pillContainer, this.selectElement);

      this.selectElement.style.display = "none";
      this.pillContainer.addEventListener("click", () => this.showDropdown());
      this.selectElement.addEventListener("change", () => this.handleSelection());
   }

   showDropdown() {
      this.selectElement.style.display = "block";
      this.selectElement.focus();
      this.selectElement.addEventListener("blur", () => {
         this.selectElement.style.display = "none";
      }, { once: true });
   }

   handleSelection() {
      Array.from(this.selectElement.selectedOptions).forEach(option => {
         if (!this.selectedValues.has(option.value)) {
            this.selectedValues.add(option.value);
            this.addPill(option);
         }
      });

      this.updateFilters();
      this.selectElement.selectedIndex = -1;
      this.selectElement.style.display = "none";
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
      if (this.onUpdateFilters) this.onUpdateFilters(selectedValues);
   }
}

document.addEventListener("DOMContentLoaded", () => {
   const updateFilters = (selectedValues, type) => {
      if (type === "priority") {
         currentFilters.priorityIds = selectedValues;
      } else if (type === "month") {
         currentFilters.monthIds = selectedValues;
      }
      currentFilters.currentPage = 1;
      saveFilters();
      loadOrders();
   };

   document.querySelectorAll(".multi-select-wrapper").forEach((wrapper, index) => {
      new MultiSelectComponent(wrapper, (selectedValues) => {
         const type = index === 0 ? "priority" : "month";
         updateFilters(selectedValues, type);
      });
   });
});
