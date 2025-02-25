﻿let currentFilters = {
   pageSize: 10,
   currentPage: 1,
   searchTerm: '',
   showArchived: false,
   showVerified: true,
   showCompleted: true,
   showActive: true,
   showScheduling: true,
   showApproving: true,
   detailed: false,
   priorityIds: [],
   monthIds: [],
   yearIds: []
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
   const queryParams = new URLSearchParams({
      ...currentFilters,
      priorityIds: currentFilters.priorityIds && currentFilters.priorityIds.length > 0 ? currentFilters.priorityIds.join(',') : '',
      monthIds: currentFilters.monthIds && currentFilters.monthIds.length > 0 ? currentFilters.monthIds.join(',') : '',
      yearIds: currentFilters.yearIds && currentFilters.yearIds.length > 0 ? currentFilters.yearIds.join(',') : ''
   });

   fetch(`?handler=Orders&${queryParams.toString()}`)
      .then(response => response.json())
      .then(data => {
         renderOrders(data);
         renderPagination(data.totalCount);
      })
      .catch(error => {
         console.error('Error loading orders:', error);
         const container = document.getElementById('orderListContainer');
         container.innerHTML = `<div class="error">Failed to load orders: ${error.message}</div>`;
      });
}

function renderOrders(data) {
   const container = document.getElementById('orderListContainer');
   const currentDate = new Date();
   const day = currentDate.getDate();
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
            </tr>
            ${data.orders.map(order => `
               <tr class="${getOrderClasses(order)}" onclick="window.location.href='./TrainingOrders/Details?id=${order.id}'" style="cursor: pointer;">
                  <td><p class="${getTypeClass(order.status)}" title="${order.status}">${order.id}</p></td>
                  <td>${order.traineeName}</td>
                  <td>${order.beginDate}</td>
                  <td>${order.lessonName}</td>
                  <td>${order.skillName}</td>
                  <td>${order.priority}</td>
               </tr>
            `).join('')}
         </table>
      `;
   } else {
      container.innerHTML = `
         <div class="order-list">
            <ul>
               ${data.orders.map(order => `
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

                     ${currentDate > new Date(order.beginDate) &&
                     (currentDate - new Date(order.beginDate)) > 2 * 24 * 60 * 60 * 1000 &&
                     order.status == "Active" ?
                        `<div class="overdue">
                            <img src="/images/Warning.svg" title="Overdue Training" />
                         </div>` : ''}
                  </li>
               `).join('')}
            </ul>
         </div>
      `;
   }
}

function renderPagination(totalCount) {
   const totalPages = currentFilters.pageSize === -1 ? 1 : Math.ceil(totalCount / currentFilters.pageSize);
   const pagination = document.getElementById('pagination');

   let html = '';
   if (totalPages > 1) {
      html += `<button class="btn bg-btn btnWhite" onclick="changePage(1)" ${currentFilters.currentPage === 1 ? 'disabled' : ''}>|<</button>`;
      html += `<button class="btn bg-btn btnWhite" onclick="changePage(${currentFilters.currentPage - 1})" ${currentFilters.currentPage === 1 ? 'disabled' : ''}><</button>`;
      html += `<span>Page ${currentFilters.currentPage} of ${totalPages}</span>`;
      html += `<button class="btn bg-btn btnWhite" onclick="changePage(${currentFilters.currentPage + 1})" ${currentFilters.currentPage === totalPages ? 'disabled' : ''}>></button>`;
      html += `<button class="btn bg-btn btnWhite" onclick="changePage(${totalPages})" ${currentFilters.currentPage === totalPages ? 'disabled' : ''}>>|</button>`;
   } else {
      html += `<span>Showing all ${totalCount} records</span>`;
   }
   pagination.innerHTML = html;
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
      case 'Scheduling': return 'scheduling';
      default: return 'approving';
   }
}

function initializeUI() {
   document.getElementById('pageSize').value = currentFilters.pageSize.toString();
   document.getElementById('searchInput').value = currentFilters.searchTerm;
   document.getElementById('viewToggle').textContent = currentFilters.detailed ? 'Switch to Simple View' : 'Switch to Detailed View';

   ['Archived', 'Verified', 'Completed', 'Active', 'Scheduling', 'Approving'].forEach(status => {
      const checkbox = document.getElementById(`show${status}`);
      checkbox.checked = currentFilters[`show${status}`];
   });

}

document.getElementById('pageSize').addEventListener('change', function (e) {
   const value = parseInt(e.target.value);
   currentFilters.pageSize = value;
   currentFilters.currentPage = 1;

   if (value === -1) {
      const container = document.getElementById('orderListContainer');
      container.innerHTML = '<div class="loading">Loading all records...</div>';
   }
   loadOrders();
});

document.getElementById('viewToggle').addEventListener('click', function () {
   currentFilters.detailed = !currentFilters.detailed;
   this.textContent = currentFilters.detailed ? 'Switch to Simple View' : 'Switch to Detailed View';
   loadOrders();
});

document.getElementById('searchInput').addEventListener('input', debounce(function (e) {
   currentFilters.searchTerm = e.target.value;
   currentFilters.currentPage = 1;
   loadOrders();
}, 300));

['Archived', 'Verified', 'Completed', 'Active', 'Scheduling', 'Approving'].forEach(status => {
   const checkbox = document.getElementById(`show${status}`);
   checkbox.addEventListener('change', function () {
      currentFilters[`show${status}`] = this.checked;
      loadOrders();
   });
});

function changePage(page) {
   currentFilters.currentPage = page;
   loadOrders();
}

document.addEventListener('DOMContentLoaded', () => {
   moduleType = "A";
   initializeUI();
   loadOrders();
});