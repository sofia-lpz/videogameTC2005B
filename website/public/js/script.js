// var unityInstance = UnityLoader.instantiate("unityContainer", "Build/myGame.json", {
//     onProgress: function (unityInstance, progress) {
//         console.log(progress * 100 + "%");
//     }
// });

const baseUrl = 'http://localhost:3000/api';

// Function to fetch cards from the API
async function fetchCards() {
    try {
        const response = await fetch(`${baseUrl}/cards`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const data = await response.json();
        displayCards(data);
    } catch (error) {
        console.error('Error fetching cards:', error);
    }
}

// Function to fetch player info from the API
async function fetchPlayer(username) {
    try {
        const response = await fetch(`${baseUrl}/player/${username}`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const data = await response.json();
        displayPlayerInfo(data);
    } catch (error) {
        console.error('Error fetching player info:', error);
    }
}

// Function to fetch player matches from the API
async function fetchPlayerMatches(username) {
    try {
        const response = await fetch(`${baseUrl}/player/${username}/matches`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const data = await response.json();
        displayPlayerMatches(data);
    } catch (error) {
        console.error('Error fetching player matches:', error);
    }
}

// Function to display cards on the webpage
function displayCards(cards) {
    const container = document.getElementById('cards-container');
    container.innerHTML = '<h2>Cards</h2>';
    cards.forEach(card => {
        const cardElement = document.createElement('div');
        cardElement.classList.add('card');
        cardElement.innerHTML = `<h3>${card.title}</h3><p>${card.description}</p>`;
        container.appendChild(cardElement);
    });
}

// Function to display player info on the webpage
function displayPlayerInfo(player) {
    const container = document.getElementById('player-info');
    container.innerHTML = `<h2>Player Info</h2><div class="player-info"><h3>${player.username}</h3><p>${player.info}</p></div>`;
}

// Function to display player matches on the webpage
function displayPlayerMatches(matches) {
    const container = document.getElementById('player-matches');
    container.innerHTML = '<h2>Player Matches</h2>';
    matches.forEach(match => {
        const matchElement = document.createElement('div');
        matchElement.classList.add('player-match');
        matchElement.innerHTML = `<h3>Match ID: ${match.id}</h3><p>${match.details}</p>`;
        container.appendChild(matchElement);
    });
}

// Example usage: Fetch data when the page loads
window.onload = function() {
    fetchCards();
    fetchPlayer('exampleUsername'); // Replace with actual username
    fetchPlayerMatches('exampleUsername'); // Replace with actual username
};