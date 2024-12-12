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

      this.selectElement.addEventListener("change", () => this.handleSelection());
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
}

