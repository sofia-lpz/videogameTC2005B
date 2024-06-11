import * as colometaMysql from './colometa.mysql.js'

const getCards = async () => {
  try {
    const cards = await colometaMysql.getCards();
    return cards;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getDialogues = async () => {
  try {
    const dialogues = await colometaMysql.getDialogues();
    return dialogues;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getStats = async () => {
  try {
    const stats = await colometaMysql.getStats();
    return stats;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getMatches = async () => {
  try {
    const matches = await colometaMysql.getMatches();
    return matches;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getVillagers = async () => {
  try {
    const villagers = await colometaMysql.getVillagers();
    return villagers;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getPlayerTeam = async (username) => {
  try {
    const playerTeam = await colometaMysql.getPlayerTeam(username);
    return playerTeam;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getPlayerDeck = async (username) => {
  try {
    const playerDeck = await colometaMysql.getPlayerDeck(username);
    return playerDeck;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getPlayerMatches = async (username) => {
  try {
    const playerMatches = await colometaMysql.getPlayerMatches(username);
    return playerMatches;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getPlayerStats = async (username) => {
  try {
    const playerStats = await colometaMysql.getPlayerStats(username);
    return playerStats;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getAuth = async (username, password) => {
  try {
    const auth = await colometaMysql.getAuth(username, password);
    return auth;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const createPlayer = async (username, password) => {
  try {
    const player = await colometaMysql.createPlayer(username, password);
    return player;
  } catch (err) {
    console.error(err);
    return { error: err.message };
    
  }
}

const createPlayerMatch = async (username, won) => {
  try {
    const playerMatch = await colometaMysql.createPlayerMatch(username, won);
    return playerMatch;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const createPlayerStats = async (username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound) => {
  try {
    const playerStats = await colometaMysql.createPlayerStats(username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound);
    return playerStats;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const createCardUse = async (username, cardId, timesUsed) => {
  try {
    const cardUse = await colometaMysql.createCardUse(username, cardId, timesUsed);
    return cardUse;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const createVillagerUse = async (username, villagerId, timesUsed) => {
  try {
    const villagerUse = await colometaMysql.createVillagerUse(username, villagerId, timesUsed);
    return villagerUse;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getMatchResults = async () => {
  try {
    const matchResults = await colometaMysql.getMatchResults();
    return matchResults;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getCardUse = async () => {
  try {
    const cardUse = await colometaMysql.getCardUse();
    return cardUse;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}

const getVillagerUse = async () => {
  try {
    const villagerUse = await colometaMysql.getVillagerUse();
    return villagerUse;
  } catch (err) {
    console.error(err);
    return { error: err.message };
  }
}


export {
  getVillagerUse,
  getCardUse,
  getMatchResults,
  createVillagerUse,
  createCardUse,
  createPlayerStats,
  createPlayerMatch,
  getCards,
  getDialogues,
  getStats,
  getMatches,
  getVillagers,
  getPlayerTeam,
  getPlayerDeck,
  getPlayerMatches,
  getPlayerStats,
  getAuth,
  createPlayer
};