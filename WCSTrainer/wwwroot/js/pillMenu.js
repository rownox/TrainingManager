class MultiSelectComponent {
   constructor(wrapper) {
      this.wrapper = wrapper;
      this.selectElement = wrapper.querySelector(".multi-select-comp");
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
         if (!this.pillContainer.querySelector(`.pill[data-value="${option.value}"]`)) {
            this.addPill(option);
         }
      });

      this.selectElement.selectedIndex = -1;
      this.selectElement.style.display = "none";
   }

   addPill(option) {
      const pill = document.createElement("div");
      pill.className = "pill";
      pill.setAttribute("data-value", option.value);
      pill.textContent = option.text;

      pill.addEventListener("click", (event) => {
         event.stopPropagation(); // Prevents the click from triggering the showDropdown
         this.removePill(option.value);
      });

      this.pillContainer.appendChild(pill);
   }

   removePill(value) {
      const pill = this.pillContainer.querySelector(`.pill[data-value="${value}"]`);
      if (pill) pill.remove();

      const option = this.selectElement.querySelector(`option[value="${value}"]`);
      if (option) option.selected = false;
   }
}

document.addEventListener("DOMContentLoaded", () => {
   document.querySelectorAll(".multi-select-wrapper").forEach(wrapper => new MultiSelectComponent(wrapper));
});
