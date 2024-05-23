// var unityInstance = UnityLoader.instantiate("unityContainer", "Build/myGame.json", {
//     onProgress: function (unityInstance, progress) {
//         console.log(progress * 100 + "%");
//     }
// });

const baseUrl = 'http://localhost:3000/api';

// Función para hacer una solicitud fetch a la ruta /cards
const fetchCards = async () => {
  const response = await fetch(`${baseURL}/cards`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};

// Función para hacer una solicitud fetch a la ruta /player/:username
const fetchPlayer = async (username) => {
  const response = await fetch(`${baseURL}/player/${username}`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};

// Función para hacer una solicitud fetch a la ruta /dialogues
const fetchDialogues = async () => {
  const response = await fetch(`${baseURL}/dialogues`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};

// Función para hacer una solicitud fetch a la ruta /stats
const fetchStats = async () => {
  const response = await fetch(`${baseURL}/stats`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};

// Función para hacer una solicitud fetch a la ruta /matches
const fetchMatches = async () => {
  const response = await fetch(`${baseURL}/matches`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};

// Función para hacer una solicitud fetch a la ruta /villagers
const fetchVillagers = async () => {
  const response = await fetch(`${baseURL}/villagers`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};

// Función para hacer una solicitud fetch a la ruta /player/:username/team
const fetchPlayerTeam = async (username) => {
  const response = await fetch(`${baseURL}/player/${username}/team`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};

// Función para hacer una solicitud fetch a la ruta /player/:username/deck
const fetchPlayerDeck = async (username) => {
  const response = await fetch(`${baseURL}/player/${username}/deck`);
  const data = await response.json();
  console.log(data); // Hacer algo con los datos devueltos
};