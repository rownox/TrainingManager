let currentFilters = {
   maxCount: 10,
   searchTerm: '',
   showArchived: false,
   showVerified: true,
   showCompleted: true,
   showActive: true,
   showAwaiting: true,
   detailed: false
};

let debounceTimeout;

function debounce(func, wait) {
   return function executedFunction(...args) {
      const later = () => {
         clearTimeout(debounceTimeout);
         func(...args);
      };
      clearTimeout(debounceTimeout);
      debounceTimeout = setTimeout(later, wait);
   };
}

function loadOrders() {
   const queryString = new URLSearchParams(currentFilters).toString();
   fetch(`?handler=Orders&${queryString}`)
      .then(response => response.json())
      .then(renderOrders);
}

function renderOrders(orders) {
   const container = document.getElementById('orderListContainer');
   if (currentFilters.detailed) {
      container.innerHTML = `
                          <table id="dataTable" class="order-table">
                              <tr>
                                  <th>ID</th>
                                  <th>Trainee</th>
                                  <th>Begin Date</th>
                                  <th>Lesson</th>
                                  <th>Skill</th>
                                  <th>Priority</th>
                                  <th></th>
                              </tr>
                              ${orders.map(order => `
                                  <tr class="${getOrderClasses(order)}">
                                      <td><p class="${getTypeClass(order.status)} dot" title="${order.status}">${order.id} ⬤</p></td>
                                      <td>${order.traineeName}</td>
                                      <td>${new Date(order.beginDate).toLocaleDateString()}</td>
                                      <td>${order.lessonName}</td>
                                      <td>${order.skillName}</td>
                                      <td>${order.priority}</td>
                                      <td>
                                          <a href="./TrainingOrders/Details?id=${order.id}" class="btn nbg-btn btnWhite">View</a>
                                      </td>
                                  </tr>
                              `).join('')}
                          </table>
                      `;
   } else {
      container.innerHTML = `
                          <div class="order-list">
                              <ul>
                                  ${orders.map(order => `
                                      <li class="${getOrderClasses(order)}">
                                          <div class="info">
                                              <div class="title">
                                                  <a class="name ${order.archived ? 'archived' : 'unarchived'}"
                                                     href="./TrainingOrders/Details?id=${order.id}">
                                                     TO #${order.id} - ${order.lessonName}
                                                  </a>
                                                  ${order.skillName ? `
                                                      <a class="skill-name black-pill"
                                                         href="/Skills/Details?id=${order.skillId}">
                                                         ${order.skillName}
                                                      </a>
                                                  ` : ''}
                                              </div>
                                              <div class="sub">
                                                  <div class="sub-text">
                                                      <p class="identifier">Trainee - ${order.traineeName}</p>
                                                  </div>
                                              </div>
                                          </div>
                                      </li>
                                  `).join('')}
                              </ul>
                          </div>
                      `;
   }
}

function getOrderClasses(order) {
   const type = getTypeClass(order.status);
   return `${type} ${order.status} ${order.archived ? 'Archived' : ''}`;
}

function getTypeClass(status) {
   switch (status) {
      case 'Active': return 'active';
      case 'Verified': return 'verified';
      case 'Completed': return 'completed';
      default: return 'awaiting';
   }
}

document.getElementById('maxCount').addEventListener('change', function (e) {
   const value = parseInt(e.target.value);
   currentFilters.maxCount = value;

   if (value === -1) {
      const container = document.getElementById('orderListContainer');
      container.innerHTML = '<div class="loading">Loading all records...</div>';
   }

   loadOrders();
});

document.getElementById('viewToggle').addEventListener('click', function () {
   currentFilters.detailed = !currentFilters.detailed;
   this.textContent = currentFilters.detailed ? 'Simple View' : 'Detailed View';
   loadOrders();
});

document.getElementById('searchInput').addEventListener('input', debounce(function (e) {
   currentFilters.searchTerm = e.target.value;
   loadOrders();
}, 300));

['Archived', 'Verified', 'Completed', 'Active', 'Awaiting'].forEach(status => {
   const checkbox = document.getElementById(`show${status}`);
   checkbox.addEventListener('change', function () {
      currentFilters[`show${status}`] = this.checked;
      loadOrders();
   });
});

document.addEventListener('DOMContentLoaded', loadOrders);