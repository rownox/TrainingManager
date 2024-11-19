class MultiSelectComponent {
   constructor(wrapper, onUpdateFilters, type) {
      this.wrapper = wrapper;
      this.selectElement = wrapper.querySelector(".multi-select-comp");
      this.type = type; // 'priority' or 'month'
      this.onUpdateFilters = onUpdateFilters;
      this.selectedValues = new Set(); // Use Set to track selected values
      this.init();
   }

   init() {
      this.pillContainer = document.createElement("div");
      this.pillContainer.className = "pill-container";
      this.wrapper.insertBefore(this.pillContainer, this.selectElement);
      this.selectElement.style.display = "none";

      // Add click event to pill container to show dropdown
      this.pillContainer.addEventListener("click", (e) => {
         if (e.target === this.pillContainer) {
            this.showDropdown();
         }
      });

      // Add change event to select element
      this.selectElement.addEventListener("change", () => this.handleSelection());
   }

   showDropdown() {
      this.selectElement.style.display = "block";
      this.selectElement.focus();

      // Hide dropdown when clicked outside
      const hideDropdown = (e) => {
         if (!this.wrapper.contains(e.target)) {
            this.selectElement.style.display = "none";
            document.removeEventListener('click', hideDropdown);
         }
      };

      // Add a small delay to prevent immediate closure
      setTimeout(() => {
         document.addEventListener('click', hideDropdown);
      }, 0);
   }

   handleSelection() {
      // Clear existing selection
      this.pillContainer.innerHTML = '';
      this.selectedValues.clear();

      // Add new selections
      Array.from(this.selectElement.selectedOptions).forEach(option => {
         this.selectedValues.add(option.value);
         this.addPill(option);
      });

      this.updateFilters();
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
      // Remove pill from DOM
      const pill = this.pillContainer.querySelector(`.pill[data-value="${value}"]`);
      if (pill) pill.remove();

      // Deselect corresponding option
      const option = this.selectElement.querySelector(`option[value="${value}"]`);
      if (option) option.selected = false;

      // Remove from selected values
      this.selectedValues.delete(value);
      this.updateFilters();
   }

   updateFilters() {
      // Convert selected values to array of integers
      const selectedValues = Array.from(this.selectedValues).map(value => parseInt(value));

      // Call the update filters callback with selected values
      if (this.onUpdateFilters) {
         this.onUpdateFilters(selectedValues, this.type);
      }
   }
}

document.addEventListener("DOMContentLoaded", () => {
   const updateFilters = (selectedValues, type) => {
      console.log(`Raw selected values for ${type}:`, selectedValues);
      console.log(`Current filters before update:`, currentFilters);

      // Explicitly handle each type of filter
      if (type === "priority") {
         currentFilters.priorityIds = selectedValues.length > 0 ? selectedValues : null;
         console.log(`Updated priority filters:`, currentFilters.priorityIds);
      } else if (type === "month") {
         currentFilters.monthIds = selectedValues.length > 0 ? selectedValues : null;
         console.log(`Updated month filters:`, currentFilters.monthIds);
      }

      // Reset to first page and reload orders
      currentFilters.currentPage = 1;
      saveFilters();
      loadOrders();
   };

   // Create multi-select components for priorities and months
   const multiSelectWrappers = document.querySelectorAll(".multi-select-wrapper");
   multiSelectWrappers.forEach((wrapper, index) => {
      const type = index === 0 ? "priority" : "month";
      new MultiSelectComponent(wrapper, updateFilters, type);
   });
});