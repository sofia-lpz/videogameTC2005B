import * as colometaMysql from './colometa.mysql.js'

const getCards = async () => {
  try {
    const cards = await colometaMysql.getCards();
    return cards;
  } catch (err) {
    console.error(err);
  }
}

const getPlayer = async (username) => {
  try {
    const player = await colometaMysql.getPlayer(username);
    return player;
  }
  catch (err) {
    console.error(err);
  }
}

const getDialogues = async () => {
  try {
    const dialogues = await colometaMysql.getDialogues();
    return dialogues;
  } catch (err) {
    console.error(err);
  }
}

const getStats = async () => {
  try {
    const stats = await colometaMysql.getStats();
    return stats;
  } catch (err) {
    console.error(err);
  }
}

const getMatches = async () => {
  try {
    const matches = await colometaMysql.getMatches();
    return matches;
  } catch (err) {
    console.error(err);
  }
}

const getVillagers = async () => {
  try {
    const villagers = await colometaMysql.getVillagers();
    return villagers;
  } catch (err) {
    console.error(err);
  }
}

const getPlayerTeam = async (username) => {
  try {
    const playerTeam = await colometaMysql.getPlayerTeam(username);
    return playerTeam;
  } catch (err) {
    console.error(err);
  }
}

const getPlayerDeck = async (username) => {
  try {
    const playerDeck = await colometaMysql.getPlayerDeck(username);
    return playerDeck;
  } catch (err) {
    console.error(err);
  }
}

const getPlayerMatches = async (username) => {
  try {
    const playerMatches = await colometaMysql.getPlayerMatches(username);
    return playerMatches;
  } catch (err) {
    console.error(err);
  }
}

const getPlayerStats = async (username) => {
  try {
    const playerStats = await colometaMysql.getPlayerStats(username);
    return playerStats;
  } catch (err) {
    console.error(err);
  }
}

const getAuth = async (username, password) => {
  try {
    const auth = await colometaMysql.getAuth(username, password);
    return auth;
  } catch (err) {
    console.error(err);
  }
}


export {
  getCards,
  getPlayer,
  getDialogues,
  getStats,
  getMatches,
  getVillagers,
  getPlayerTeam,
  getPlayerDeck,
  getPlayerMatches,
  getPlayerStats,
  getAuth
};