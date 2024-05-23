
// Function to fetch and display cards data
function fetchAndDisplayCards() {
fetch('http://localhost:3000/api/cards')
    .then(response => response.json())
    .then(data => {
    const cardsDataContainer = document.getElementById('cardsData');
    cardsDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error('Error fetching cards:', error);
    });
}

// Function to fetch and display player data by username
function fetchAndDisplayPlayer(username) {
fetch(`http://localhost:3000/api/player/${username}`)
    .then(response => response.json())
    .then(data => {
    const playerDataContainer = document.getElementById('playerData');
    playerDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error(`Error fetching player ${username}:`, error);
    });
}

// Function to fetch and display dialogues data
function fetchAndDisplayDialogues() {
fetch('http://localhost:3000/api/dialogues')
    .then(response => response.json())
    .then(data => {
    const dialoguesDataContainer = document.getElementById('dialoguesData');
    dialoguesDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error('Error fetching dialogues:', error);
    });
}

// Function to fetch and display stats data
function fetchAndDisplayStats() {
fetch('http://localhost:3000/api/stats')
    .then(response => response.json())
    .then(data => {
    const statsDataContainer = document.getElementById('statsData');
    statsDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error('Error fetching stats:', error);
    });
}

// Function to fetch and display matches data
function fetchAndDisplayMatches() {
fetch('http://localhost:3000/api/matches')
    .then(response => response.json())
    .then(data => {
    const matchesDataContainer = document.getElementById('matchesData');
    matchesDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error('Error fetching matches:', error);
    });
}

// Function to fetch and display villagers data
function fetchAndDisplayVillagers() {
fetch('http://localhost:3000/api/villagers')
    .then(response => response.json())
    .then(data => {
    const villagersDataContainer = document.getElementById('villagersData');
    villagersDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error('Error fetching villagers:', error);
    });
}

// Function to fetch and display player's team data by username
function fetchAndDisplayPlayerTeam(username) {
fetch(`http://localhost:3000/api/player/${username}/team`)
    .then(response => response.json())
    .then(data => {
    const playerTeamDataContainer = document.getElementById('playerTeamData');
    playerTeamDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error(`Error fetching player ${username}'s team:`, error);
    });
}

// Function to fetch and display player's deck data by username
function fetchAndDisplayPlayerDeck(username) {
fetch(`http://localhost:3000/api/player/${username}/deck`)
    .then(response => response.json())
    .then(data => {
    const playerDeckDataContainer = document.getElementById('playerDeckData');
    playerDeckDataContainer.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
    console.error(`Error fetching player ${username}'s deck:`, error);
    });
}

// Call each function to fetch and display data
fetchAndDisplayCards();
fetchAndDisplayPlayer('exampleUsername');
fetchAndDisplayDialogues();
fetchAndDisplayStats();
fetchAndDisplayMatches();
fetchAndDisplayVillagers();
fetchAndDisplayPlayerTeam('exampleUsername');
fetchAndDisplayPlayerDeck('exampleUsername');

