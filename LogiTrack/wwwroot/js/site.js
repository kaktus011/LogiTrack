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

async function getCurrentLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    } else {
        document.getElementById('location').textContent = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    const lat = position.coords.latitude;
    const long = position.coords.longitude;
    fetchLocation(lat, long);
}

async function fetchLocation(lat, long) {
    const apiKey = 'test';
    const url = `https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${long}&key=${apiKey}`;

    try {
        const response = await fetch(url);
        const data = await response.json();

        if (data.results && data.results.length > 0) {
            const address = data.results[0].formatted_address;
            document.getElementById('location').textContent = address;
        } else {
            document.getElementById('location').textContent = "Unable to retrieve location.";
        }
    } catch (error) {
        console.error("Error fetching location:", error);
        document.getElementById('location').textContent = "Error fetching location.";
    }

    showCurrentTime();
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

window.onload = getCurrentLocation;