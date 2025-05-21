export function setupSidebar(toggleBtnId, sidebarSelector) {
  const toggleBtn = document.getElementById(toggleBtnId);
  const sidebar = document.querySelector(sidebarSelector);
  const icon = toggleBtn.querySelector('i');

  toggleBtn.addEventListener('click', () => {
    const isOpen = sidebar.classList.toggle('open');
    
    // Toggle icon
    if (isOpen) {
      icon.classList.remove('fa-bars');
      icon.classList.add('fa-times');
    } else {
      icon.classList.remove('fa-times');
      icon.classList.add('fa-bars');
    }
  });

  // Close sidebar when clicking outside
  document.addEventListener('click', (event) => {
    const isClickInside = sidebar.contains(event.target) || toggleBtn.contains(event.target);
    if (!isClickInside && sidebar.classList.contains('open')) {
      sidebar.classList.remove('open');
      icon.classList.remove('fa-times');
      icon.classList.add('fa-bars');
    }
  });
}
