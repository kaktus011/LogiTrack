// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification

function toggleSidebar() {
    const sidebar = document.querySelector('.sidebar');
    const mainContent = document.querySelector('.main-content');
    const header = document.querySelector('.header');
    sidebar.classList.toggle('closed');
    mainContent.classList.toggle('shifted');
    header.classList.toggle('shifted');
}

function toggleDropdown() {
    const dropdown = document.getElementById('profileDropdown');
    dropdown.style.display = dropdown.style.display === 'block' ? 'none' : 'block';
}

// Close the user menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.profile-button')) {
        const dropdowns = document.getElementsByClassName('profile-dropdown-menu');
        for (let i = 0; i < dropdowns.length; i++) {
            const openDropdown = dropdowns[i];
            if (openDropdown.style.display === 'block') {
                openDropdown.style.display = 'none';
            }
        }
    }
}

function showCurrentTime() {
    const now = new Date();
    const options = { timeZone: 'Europe/Sofia', hour: '2-digit', minute: '2-digit', second: '2-digit', hour12: false };
    const timeString = now.toLocaleTimeString('en-US', options);
    document.getElementById('currentTime').textContent = `Current Time: ${timeString}`;
}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            document.getElementById('location').textContent = "User denied the request for Geolocation.";
            break;
        case error.POSITION_UNAVAILABLE:
            document.getElementById('location').textContent = "Location information is unavailable.";
            break;
        case error.TIMEOUT:
            document.getElementById('location').textContent = "The request to get user location timed out.";
            break;
        case error.UNKNOWN_ERROR:
            document.getElementById('location').textContent = "An unknown error occurred.";
            break;
    }
}