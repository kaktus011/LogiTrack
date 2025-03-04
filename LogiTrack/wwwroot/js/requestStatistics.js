﻿
async function fetchRequestStatusDistribution() {
    try {
        const response = await fetch('/Logistics/GetRequestStatusDistribution');
        const data = await response.json();

        const labels = Object.keys(data.statusCounts);
        const counts = Object.values(data.statusCounts);

        const ctx = document.getElementById('requestStatusChart').getContext('2d');
        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [{
                    data: counts,
                    backgroundColor: [
                        '#00aa87', '#FF6384', '#3498db', '#f1c40f', '#9b59b6'
                    ],
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'bottom'
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching request status distribution:', error);
    }
}
async function fetchResponseTimes() {
    try {
        const response = await fetch('/Logistics/GetAverageResponseTime');
        const data = await response.json();

        console.log('Fetched data:', data);

        const labels = ['Max Response Time', 'Average Response Time'];
        const values = [data.maxResponseTime, data.averageResponseTime];

        const ctx = document.getElementById('responseTimeChart').getContext('2d');

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Response Time (minutes)',
                    data: values,
                    backgroundColor: ['#00aa87', '#FF6384'],
                    borderColor: ['#00aa87', '#FF6384'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Time (minutes)'
                        },
                        ticks: {
                            stepSize: 10
                        }
                    }
                },
                plugins: {
                    legend: {
                        display: false
                    },
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.label}: ${tooltipItem.raw} minutes`;
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching response times:', error);
    }
}
async function renderHeatMap() {
    try {
        const response = await fetch('/Logistics/GetMonthlyRequestPatterns');
        const data = await response.json();

        const daysInMonth = new Date(new Date().getFullYear(), new Date().getMonth() + 1, 0).getDate();
        const dailyCounts = Array(daysInMonth).fill(0);

        for (const [day, count] of Object.entries(data.data)) {
            const dayIndex = parseInt(day, 10) - 1;
            if (dayIndex >= 0 && dayIndex < daysInMonth) {
                dailyCounts[dayIndex] = count;
            }
        }

        const heatmapData = dailyCounts.map((count, index) => ({
            x: index + 1,
            y: count,
            v: count
        }));

        new Chart(document.getElementById('heatMapChart'), {
            type: 'scatter',
            data: {
                datasets: [{
                    label: 'Requests per Day',
                    data: heatmapData,
                    pointStyle: 'rect',
                    pointRadius: 10,
                    backgroundColor(context) {
                        const value = context.raw.v;
                        const colorIntensity = Math.min(value * 15, 255);
                        return `#FF6384`;
                    },
                }]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        type: 'linear',
                        position: 'bottom',
                        title: { display: true, text: 'Day of the Month' },
                        ticks: {
                            stepSize: 1,
                            min: 1,
                            max: daysInMonth
                        }
                    },
                    y: {
                        title: { display: true, text: 'Request Count' },
                        beginAtZero: true,
                        ticks: {
                            stepSize: 1,
                            callback: function (value) { return Number.isInteger(value) ? value : null; }
                        }
                    }
                },
                plugins: {
                    tooltip: {
                        callbacks: {
                            label: function (context) {
                                return `Day ${context.raw.x}: ${context.raw.y} request(s)`;
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching heat map data:', error);
    }
}
document.addEventListener('DOMContentLoaded', function () {
    async function fetchTopClients() {
        try {
            const response = await fetch('/Logistics/GetTopClients');
            if (!response.ok) {
                throw new Error('Failed to fetch top clients data.');
            }

            const data = await response.json();
            console.log('Fetched top clients data:', data);

            const labels = Object.keys(data);
            const requestCounts = Object.values(data);

            const ctx = document.getElementById('topClientsChart').getContext('2d');
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Number of Requests',
                        data: requestCounts,
                        backgroundColor: '#00aa87',
                        borderColor: '#00aa87',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: 'Number of Requests'
                            }
                        },
                        x: {
                            title: {
                                display: true,
                                text: 'Client Companies'
                            },
                            ticks: {
                                maxRotation: 45,
                                minRotation: 0
                            }
                        }
                    },
                    plugins: {
                        legend: {
                            display: false
                        },
                        tooltip: {
                            callbacks: {
                                label: function (tooltipItem) {
                                    return `${tooltipItem.label}: ${tooltipItem.raw} requests`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
            console.error('Error fetching top clients data:', error);
        }
    }

    fetchTopClients();
});

document.addEventListener('DOMContentLoaded', async function () {
    await fetchRequestStatusDistribution();
    await fetchResponseTimes();
    await renderHeatMap();
});

